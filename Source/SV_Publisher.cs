using System;
using System.Collections.Generic;
using System.Diagnostics;
using SharpPcap;
using SharpPcap.LibPcap;

namespace GeneratorSV
{
    class SV_Publisher
    {
        private byte[] template;
        private byte[][] frames;

        private int offset_SmpCounter;
        private int offset_DataValues;

        private int frameLength;

        private LibPcapLiveDevice device;
        private SV_Settings sets;

        public SV_Publisher(SV_Settings settings)
        {
            sets = settings;

            InitDevice();
            MakeTemplate();
            MakeFrames();

            GC.Collect();
            GC.GetTotalMemory(true);
        }

        private void InitDevice()
        {
            foreach (var liveDevice in LibPcapLiveDeviceList.Instance)
            {
                if (liveDevice.Interface.FriendlyName == sets.interfaceName)
                {
                    device = liveDevice;
                    device.Open();
                    break;
                }
            }

            if (device == null)
                throw new FormatException($"Interface \'{sets.interfaceName}\' not found!");
        }

        private void MakeTemplate()
        {
            if (sets.srcMac is null) sets.srcMac = device.MacAddress.ToString();
            if (sets.dstMac is null) sets.dstMac = "01-0C-CD-04-00-00";

            // MAC-s
            string eHeader = (sets.dstMac + sets.srcMac).Replace("-", "").Replace(":", "").Replace(" ", "");

            // Vlan tag
            if (sets.hasVlan)
                eHeader += "8100" + "8" + sets.vlanID;

            // SV ethertype
            eHeader += "88ba";

            frameLength = sets.hasVlan ? 132 : 128;
            template = new byte[frameLength];

            byte[] rawEthernetHeader = Encoder.StringToByteArray(eHeader);

            rawEthernetHeader.CopyTo(template, 0);
            int offset = rawEthernetHeader.Length;

            // AppID
            template[offset++] = (byte)(sets.appID >> 8);
            template[offset++] = (byte)(sets.appID & 0xFF);

            // Length = 114
            template[offset++] = 0x00;
            template[offset++] = 0x72;

            // Reserved
            offset += 4;

            // savPdu
            template[offset++] = 0x60;
            template[offset++] = 0x68;

            // noASDU = 1
            template[offset++] = 0x80;
            template[offset++] = 0x01;
            template[offset++] = 0x01;

            // Sequence of ASDU
            template[offset++] = 0xA2;
            template[offset++] = 0x63;

            // ASDU 1
            template[offset++] = 0x30;
            template[offset++] = 0x61;

            // svID = "GENERATOR_SV"
            template[offset++] = 0x80;
            template[offset++] = 0x0c;
            template[offset++] = 0x47;
            template[offset++] = 0x45;
            template[offset++] = 0x4e;
            template[offset++] = 0x45;
            template[offset++] = 0x52;
            template[offset++] = 0x41;
            template[offset++] = 0x54;
            template[offset++] = 0x4f;
            template[offset++] = 0x52;
            template[offset++] = 0x5f;
            template[offset++] = 0x53;
            template[offset++] = 0x56;

            // smpCnt
            template[offset++] = 0x82;
            template[offset++] = 0x02;

            offset_SmpCounter = offset;
            offset += 2;

            // confRev = 1
            template[offset++] = 0x83;
            template[offset++] = 0x04;
            template[offset++] = 0x00;
            template[offset++] = 0x00;
            template[offset++] = 0x00;
            template[offset++] = 0x01;

            // smpSynch = 2
            template[offset++] = 0x85;
            template[offset++] = 0x01;
            template[offset++] = 0x02;

            // smpRate = 4000
            template[offset++] = 0x86;
            template[offset++] = 0x02;
            template[offset++] = 0x00;
            template[offset++] = 0x50;

            // Sequence of Data
            template[offset++] = 0x87;
            template[offset++] = 0x40;

            offset_DataValues = offset;
        }

        private void MakeFrames()
        {
            var framesList = new List<byte[]>(4000);

            for (int i = 0; i < 4000; i++)
            {
                byte[] buffer = new byte[frameLength];
                template.CopyTo(buffer, 0);

                ushort smpCnt = (ushort)i;

                buffer[offset_SmpCounter + 0] = (byte)(smpCnt >> 8);
                buffer[offset_SmpCounter + 1] = (byte)(smpCnt & 0xFF);

                Encoder.EncodeDataSetValues(sets.Ia_mag, sets.Ia_ang, i, buffer, offset_DataValues +  0);
                Encoder.EncodeDataSetValues(sets.Ib_mag, sets.Ib_ang, i, buffer, offset_DataValues +  8);
                Encoder.EncodeDataSetValues(sets.Ic_mag, sets.Ic_ang, i, buffer, offset_DataValues + 16);
                Encoder.EncodeDataSetValues(sets.I0_mag, sets.I0_ang, i, buffer, offset_DataValues + 24);

                Encoder.EncodeDataSetValues(sets.Ua_mag, sets.Ua_ang, i, buffer, offset_DataValues + 32, isVoltage: true);
                Encoder.EncodeDataSetValues(sets.Ub_mag, sets.Ub_ang, i, buffer, offset_DataValues + 40, isVoltage: true);
                Encoder.EncodeDataSetValues(sets.Uc_mag, sets.Uc_ang, i, buffer, offset_DataValues + 48, isVoltage: true);
                Encoder.EncodeDataSetValues(sets.U0_mag, sets.U0_ang, i, buffer, offset_DataValues + 56, isVoltage: true);

                framesList.Add(buffer);
            }

            frames = framesList.ToArray();
        }

        public void Run(bool useSandQueue = false)
        {
            if (useSandQueue)
            {
                RunQueue();
                return;
            }

            const long SampleTicks = 2_500;
            long passRate = sets.passRate;

            long smpCnt = 0;
            long lostFrames = 0;

            var sw = Stopwatch.StartNew();
            while (true)
            {
                device.SendPacket(frames[smpCnt % 4000], frameLength);
                smpCnt++;

            waitNext:

                long nextFrameTime = SampleTicks * smpCnt;
                long DelayLimit = nextFrameTime + SampleTicks * passRate;

                while (sw.ElapsedTicks < nextFrameTime)
                { /* Spin lock */ }

                if (sw.ElapsedTicks > DelayLimit)
                {
                    long realCnt = (sw.ElapsedTicks / SampleTicks);
                    lostFrames += (realCnt - smpCnt);
                    Console.WriteLine(lostFrames);
                    smpCnt = realCnt;

                    goto waitNext;
                }
            }
        }

        private void RunQueue()
        {
            using (var squeue = new SendQueue(5000 * frameLength, TimestampResolution.Microsecond))
            {
                for (int i = 0; i < 4000; i++)
                    squeue.Add(frames[i], 0, i * 250);
                squeue.Transmit(device, SendQueueTransmitModes.Synchronized);
            }
        }
    }
}
