using System;
using System.Text;
using System.Threading.Tasks;
using SharpPcap;
using SharpPcap.LibPcap;

namespace GeneratorSV
{
    class SVPublisher : IDisposable
    {
        private LibPcapLiveDevice device;
        private SendQueue squeue;
        private Task sendingTask;

        private SVConfig config;
        private DataSetValues values;

        public SVPublisher(string interfaceName, SVConfig configuration, DataSetValues dataSetValues = null)
        {
            values = dataSetValues ?? new DataSetValues();
            config = configuration ?? new SVConfig();

            OpenDevice(interfaceName);
            ResetFrames();
        }

        private void OpenDevice(string interfaceName)
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

        private void ResetFrames()
        {
            if (config.srcMac is null) config.srcMac = device.MacAddress.ToString();
            if (config.dstMac is null) config.dstMac = "01-0C-CD-04-00-00";

            if (config.svID   is null) config.svID   = "GENERATOR_SV";
            if (config.svID.Length > 35)
                throw new FormatException("Max svID length is 35 characters!");

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

            int offset = config.hasVlan ? 18 : 14;
            int frameLength = length_SV + offset;

            // These magic numbers are only applicable for the 9-2LE format with svID length <= 35
            // This solution avoids 'long form' TLV length encoding (if L > 127)

            byte[] frame = new byte[frameLength];
            
            // Ethernet header + VLan
            Encoder.StringToByteArray(eHeader).CopyTo(frame, 0);

            // AppID
            frame[offset++] = (byte)(config.appID >> 8);
            frame[offset++] = (byte)(config.appID & 0xFF);

            // Length
            frame[offset++] = (byte)(length_SV >> 8);
            frame[offset++] = (byte)(length_SV & 0xFF);

            // Reserved
            frame[offset++] = (byte)(config.simulated ? 0x80 : 0x00);
            offset += 3;

            // savPdu
            frame[offset++] = 0x60;
            frame[offset++] = (byte)(length_PDU);

            // noASDU = 1
            frame[offset++] = 0x80;
            frame[offset++] = 0x01;
            frame[offset++] = 0x01;

            // Sequence of ASDU
            frame[offset++] = 0xA2;
            frame[offset++] = (byte)(length_SEQ);

            // ASDU 1
            frame[offset++] = 0x30;
            frame[offset++] = (byte)(length_ASDU);

            // svID
            frame[offset++] = 0x80;
            frame[offset++] = (byte)length_svID;
            Encoding.ASCII.GetBytes(config.svID).CopyTo(frame, offset);
            offset += length_svID;

            // smpCnt
            frame[offset++] = 0x82;
            frame[offset++] = 0x02;

            int smpCntPos = offset;
            offset += 2;

            // confRev
            frame[offset++] = 0x83;
            frame[offset++] = 0x04;
            frame[offset++] = (byte)(0xFF & config.confRev >> 24);
            frame[offset++] = (byte)(0xFF & config.confRev >> 16);
            frame[offset++] = (byte)(0xFF & config.confRev >>  8);
            frame[offset++] = (byte)(0xFF & config.confRev);

            // smpSynch
            frame[offset++] = 0x85;
            frame[offset++] = 0x01;
            frame[offset++] = config.smpSynch;

            // smpRate = 80
            frame[offset++] = 0x86;
            frame[offset++] = 0x02;
            frame[offset++] = 0x00;
            frame[offset++] = 0x50;

            // Sequence of Data - 64 bytes
            frame[offset++] = 0x87;
            frame[offset++] = 0x40;
            
            SendQueue tmpQueue = new SendQueue(5000 * frameLength, TimestampResolution.Microsecond);

            for (int i = 0; i < 4000; i++)
            {
                int bufPos = offset;

                // smpCnt
                frame[smpCntPos + 0] = (byte)(i >> 8);
                frame[smpCntPos + 1] = (byte)(i & 0xFF);

                // Currents
                Encoder.EncodeDataSetValues(values.Ia_mag, values.Ia_ang, i, frame, ref bufPos);
                Encoder.EncodeDataSetValues(values.Ib_mag, values.Ib_ang, i, frame, ref bufPos);
                Encoder.EncodeDataSetValues(values.Ic_mag, values.Ic_ang, i, frame, ref bufPos);
                Encoder.EncodeDataSetValues(values.I0_mag, values.I0_ang, i, frame, ref bufPos);

                // Voltages
                Encoder.EncodeDataSetValues(values.Ua_mag, values.Ua_ang, i, frame, ref bufPos, isVoltage: true);
                Encoder.EncodeDataSetValues(values.Ub_mag, values.Ub_ang, i, frame, ref bufPos, isVoltage: true);
                Encoder.EncodeDataSetValues(values.Uc_mag, values.Uc_ang, i, frame, ref bufPos, isVoltage: true);
                Encoder.EncodeDataSetValues(values.U0_mag, values.U0_ang, i, frame, ref bufPos, isVoltage: true);

                tmpQueue.Add(frame, 0, i * 250);
            }

            // Swap send queues
            SendQueue toDispose = squeue;
            squeue = tmpQueue;

            toDispose?.Dispose();

            GC.Collect();
            GC.GetTotalMemory(true);
        }
        
        public bool IsRunning { get; private set; }

        public void Start()
        {
            IsRunning = true;

            sendingTask = Task.Run(() =>
            {
                while (IsRunning)
                    squeue.Transmit(device, SendQueueTransmitModes.Synchronized);
            });
        }

        public void Stop()
        {
            IsRunning = false;

            Task.Run(() =>
            {
                sendingTask.Wait();
            });
        }

        public bool HasVlan
        {
            get { return config.hasVlan; }
            set
            { 
                config.hasVlan = value;
                ResetFrames();
            }
        }

        public bool Simulated
        {
            get { return config.simulated; }
            set
            {
                config.simulated = value;
                ResetFrames();
            }
        }

        public uint ConfRev
        {
            get { return config.confRev; }

            set
            {
                config.confRev = value;
                ResetFrames();
            }
        }

        public byte SmpSynch
        {
            get { return config.smpSynch; }
            set
            {
                config.smpSynch = value;
                ResetFrames();
            }
        }

        public DataSetValues DataSet
        {
            get { return values; }

            set
            {
                values = value;
                ResetFrames();
            }
        }

        public void Dispose()
        {
            if (IsRunning)
            {
                IsRunning = false;
                sendingTask.Wait();
            }

            squeue.Dispose();
            device.Dispose();
        }
    }
}
