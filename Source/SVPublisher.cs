﻿using System;
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

        private SVCBConfig conf;
        private DataConfig data;

        public SVCBConfig SVCBConfig { get { return conf; } }
        public DataConfig DataConfig { get { return data; } }

        public SVPublisher(string interfaceName, SVCBConfig svcbConfig, DataConfig dataConfig)
        {
            Interface = interfaceName;

            conf = svcbConfig;
            data = dataConfig;

            conf.Changed += ResetFrames;
            data.Changed += ResetFrames;

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
            if (conf.SvID.Length > 35)
                throw new FormatException("Max svID length is 35 characters!");

            // Lengths calculating
            int length_svID = conf.SvID.Length;
            int length_ASDU = length_svID +  85;
            int length_SEQ  = length_svID +  87;
            int length_PDU  = length_svID +  92;
            int length_SV   = length_svID + 102;
            int frameLength = length_SV + (conf.HasVlan ? 18 : 14);

            // These magic numbers are only applicable for the 9-2LE format with svID length <= 35
            // This solution avoids 'long form' TLV length encoding (if L > 127)

            byte[] frame = new byte[frameLength];
            int offset = 0;

            // DstMAC
            frame[offset++] = 0x01;
            frame[offset++] = 0x0C;
            frame[offset++] = 0xCD;
            frame[offset++] = 0x04;
            frame[offset++] = (byte)(conf.DstMAC >> 8);
            frame[offset++] = (byte)(conf.DstMAC & 0xFF);

            // SrcMAC
            device.MacAddress.GetAddressBytes().CopyTo(frame, offset);
            offset += 6;

            if (conf.HasVlan)
            {
                // VLan ethertype
                frame[offset++] = 0x81;
                frame[offset++] = 0x00;

                uint vlanID = conf.VlanID + 0x8000u;
                frame[offset++] = (byte)(vlanID >> 8);
                frame[offset++] = (byte)(vlanID & 0xFF);
            }

            // Sampled values ethertype
            frame[offset++] = 0x88;
            frame[offset++] = 0xba;

            // AppID
            frame[offset++] = (byte)(conf.AppID >> 8);
            frame[offset++] = (byte)(conf.AppID & 0xFF);

            // Length
            frame[offset++] = (byte)(length_SV >> 8);
            frame[offset++] = (byte)(length_SV & 0xFF);

            // Reserved
            frame[offset++] = (byte)(conf.Simulated ? 0x80 : 0x00);
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
            Encoding.ASCII.GetBytes(conf.SvID).CopyTo(frame, offset);
            offset += length_svID;

            // smpCnt
            frame[offset++] = 0x82;
            frame[offset++] = 0x02;

            int smpCntPos = offset;
            offset += 2;

            // confRev
            frame[offset++] = 0x83;
            frame[offset++] = 0x04;
            frame[offset++] = (byte)(0xFF & conf.ConfRev >> 24);
            frame[offset++] = (byte)(0xFF & conf.ConfRev >> 16);
            frame[offset++] = (byte)(0xFF & conf.ConfRev >>  8);
            frame[offset++] = (byte)(0xFF & conf.ConfRev);

            // smpSynch
            frame[offset++] = 0x85;
            frame[offset++] = 0x01;
            frame[offset++] = conf.SmpSynch;

            // smpRate = 80
            frame[offset++] = 0x86;
            frame[offset++] = 0x02;
            frame[offset++] = 0x00;
            frame[offset++] = 0x50;

            // Sequence of Data - 64 bytes
            frame[offset++] = 0x87;
            frame[offset++] = 0x40;
            
            SendQueue newQueue = new SendQueue(5000 * frameLength, TimestampResolution.Microsecond);

            for (int i = 0; i < 4000; i++)
            {
                int bufPos = offset;

                // smpCnt
                frame[smpCntPos + 0] = (byte)(i >> 8);
                frame[smpCntPos + 1] = (byte)(i & 0xFF);

                // Currents
                EncodeDataSetValues(data.Ia_mag, data.Ia_ang, i, frame, ref bufPos);
                EncodeDataSetValues(data.Ib_mag, data.Ib_ang, i, frame, ref bufPos);
                EncodeDataSetValues(data.Ic_mag, data.Ic_ang, i, frame, ref bufPos);
                EncodeDataSetValues(data.I0_mag, data.I0_ang, i, frame, ref bufPos);

                // Voltages
                EncodeDataSetValues(data.Ua_mag, data.Ua_ang, i, frame, ref bufPos, isVoltage: true);
                EncodeDataSetValues(data.Ub_mag, data.Ub_ang, i, frame, ref bufPos, isVoltage: true);
                EncodeDataSetValues(data.Uc_mag, data.Uc_ang, i, frame, ref bufPos, isVoltage: true);
                EncodeDataSetValues(data.U0_mag, data.U0_ang, i, frame, ref bufPos, isVoltage: true);

                newQueue.Add(frame, 0, i * 250);
            }

            // Swap send queues
            SendQueue toDispose = squeue;
            squeue = newQueue;

            toDispose?.Dispose();
        }

        private void EncodeDataSetValues(double mag, double ang, int sampleNumber, byte[] frame, ref int offset, bool isVoltage = false)
        {
            const double DT = 1.0 / 4000;
            const double W = 100 * Math.PI;
            const double DegToRad = Math.PI / 180.0;

            const double kI = 1414.2135623730951;   // 1000 * sqrt(2)
            const double kU = 141.42135623730951;   //  100 * sqrt(2)

            double instVal = (isVoltage ? kU : kI) * mag * Math.Sin(W * DT * sampleNumber + ang * DegToRad);

            int value = (int)Math.Round(instVal);

            frame[offset++] = (byte)(0xFF & value >> 24);
            frame[offset++] = (byte)(0xFF & value >> 16);
            frame[offset++] = (byte)(0xFF & value >>  8);
            frame[offset++] = (byte)(0xFF & value);

            // Quality
            offset += 4;
        }

        public string Interface { get; }

        public bool IsRunning { get; private set; }

        public void Start()
        {
            IsRunning = true;

            sendingTask = Task.Run(() =>
            {
                while (IsRunning)
                {
                    squeue.Transmit(device, SendQueueTransmitModes.Synchronized);
                }
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

        public void Dispose()
        {
            if (IsRunning)
            {
                IsRunning = false;
                sendingTask.Wait();
            }

            conf.Changed -= ResetFrames;
            data.Changed -= ResetFrames;

            squeue.Dispose();
            device.Dispose();
        }
    }
}
