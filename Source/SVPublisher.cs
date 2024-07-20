using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SharpPcap;
using SharpPcap.LibPcap;

namespace GeneratorSV
{
    class SVPublisher
    {
        private byte[] template;
        private byte[][] frames;

        private int offset_SmpCounter;
        private int offset_DataValues;

        private int frameLength;

        private LibPcapLiveDevice device;
        private SVConfig config;

        private Task publishingTask;

        public SVPublisher(string interfaceName, SVConfig configuration)
        {
            InitDevice(interfaceName);

            config = configuration;

            InitTemplate();
            InitFrames();

            GC.Collect();
            GC.GetTotalMemory(true);
        }

        private void InitDevice(string interfaceName)
        {
            foreach (var liveDevice in LibPcapLiveDeviceList.Instance)
            {
                if (liveDevice.Interface.FriendlyName == interfaceName)
                {
                    device = liveDevice;
                    device.Open();
                    break;
                }
            }

            if (device == null)
                throw new FormatException($"Interface \'{interfaceName}\' not found!");
        }

        private void InitTemplate()
        {
            if (config.svID is null) config.svID = "GENERATOR_SV";
            if (config.svID.Length > 35)
                throw new FormatException("Max svID length is 35 characters!");

            if (config.srcMac is null) config.srcMac = device.MacAddress.ToString();
            if (config.dstMac is null) config.dstMac = "01-0C-CD-04-00-00";
            
            // MAC
            string eHeader = (config.dstMac + config.srcMac).Replace("-", "").Replace(":", "").Replace(" ", "");

            // Vlan tag
            if (config.hasVlan) 
                eHeader += "8100" + "8" + config.vlanID;

            // SV ethertype
            eHeader += "88ba";

            // Lengths calculating
            int length_svID = config.svID.Length;
            int length_ASDU = length_svID +  85;
            int length_SEQ  = length_svID +  87;
            int length_PDU  = length_svID +  92;
            int length_SV   = length_svID + 102;

            frameLength = length_SV + 14;
            if (config.hasVlan)
                frameLength += 4;

            template = new byte[frameLength];

            byte[] rawEthernetHeader = Encoder.StringToByteArray(eHeader);

            rawEthernetHeader.CopyTo(template, 0);
            int offset = rawEthernetHeader.Length;

            // AppID
            template[offset++] = (byte)(config.appID >> 8);
            template[offset++] = (byte)(config.appID & 0xFF);

            // Length
            template[offset++] = (byte)(length_SV >> 8);
            template[offset++] = (byte)(length_SV & 0xFF);

            // Reserved
            template[offset++] = (byte)(config.simulated ? 0x80 : 0x00);
            offset += 3;

            // savPdu
            template[offset++] = 0x60;
            template[offset++] = (byte)(length_PDU);

            // noASDU = 1
            template[offset++] = 0x80;
            template[offset++] = 0x01;
            template[offset++] = 0x01;

            // Sequence of ASDU
            template[offset++] = 0xA2;
            template[offset++] = (byte)(length_SEQ);

            // ASDU 1
            template[offset++] = 0x30;
            template[offset++] = (byte)(length_ASDU);

            // svID
            template[offset++] = 0x80;
            template[offset++] = (byte)length_svID;
            Encoding.ASCII.GetBytes(config.svID).CopyTo(template, offset);
            offset += length_svID;

            // smpCnt
            template[offset++] = 0x82;
            template[offset++] = 0x02;

            offset_SmpCounter = offset;
            offset += 2;

            // confRev
            template[offset++] = 0x83;
            template[offset++] = 0x04;
            template[offset++] = (byte)(0xFF & config.confRev >> 24);
            template[offset++] = (byte)(0xFF & config.confRev >> 16);
            template[offset++] = (byte)(0xFF & config.confRev >>  8);
            template[offset++] = (byte)(0xFF & config.confRev);

            // smpSynch
            template[offset++] = 0x85;
            template[offset++] = 0x01;
            template[offset++] = config.smpSynch;

            // smpRate = 80
            template[offset++] = 0x86;
            template[offset++] = 0x02;
            template[offset++] = 0x00;
            template[offset++] = 0x50;

            // Sequence of Data - 64 bytes
            template[offset++] = 0x87;
            template[offset++] = 0x40;

            offset_DataValues = offset;
        }

        private void InitFrames()
        {
            var framesList = new List<byte[]>(4000);

            for (int i = 0; i < 4000; i++)
            {
                byte[] buffer = new byte[frameLength];
                template.CopyTo(buffer, 0);

                ushort smpCnt = (ushort)i;

                buffer[offset_SmpCounter + 0] = (byte)(smpCnt >> 8);
                buffer[offset_SmpCounter + 1] = (byte)(smpCnt & 0xFF);

                Encoder.EncodeDataSetValues(config.Ia_mag, config.Ia_ang, i, buffer, offset_DataValues +  0);
                Encoder.EncodeDataSetValues(config.Ib_mag, config.Ib_ang, i, buffer, offset_DataValues +  8);
                Encoder.EncodeDataSetValues(config.Ic_mag, config.Ic_ang, i, buffer, offset_DataValues + 16);
                Encoder.EncodeDataSetValues(config.I0_mag, config.I0_ang, i, buffer, offset_DataValues + 24);

                Encoder.EncodeDataSetValues(config.Ua_mag, config.Ua_ang, i, buffer, offset_DataValues + 32, isVoltage: true);
                Encoder.EncodeDataSetValues(config.Ub_mag, config.Ub_ang, i, buffer, offset_DataValues + 40, isVoltage: true);
                Encoder.EncodeDataSetValues(config.Uc_mag, config.Uc_ang, i, buffer, offset_DataValues + 48, isVoltage: true);
                Encoder.EncodeDataSetValues(config.U0_mag, config.U0_ang, i, buffer, offset_DataValues + 56, isVoltage: true);

                framesList.Add(buffer);
            }

            frames = framesList.ToArray();
        }

        #region API

        public void Start()
        {
            IsRunning = true;

            publishingTask = Task.Run(() =>
            {
                using (var squeue = new SendQueue(5000 * frameLength, TimestampResolution.Microsecond))
                {
                    for (int i = 0; i < 4000; i++)
                        squeue.Add(frames[i], 0, i * 250);

                    while (IsRunning)
                        squeue.Transmit(device, SendQueueTransmitModes.Synchronized);
                }
            });
        }

        public void Stop()
        {
            IsRunning = false;
            publishingTask.Wait();
        }

        public bool IsRunning { get; private set; }

        #endregion
    }
}

