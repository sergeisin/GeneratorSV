﻿using System;
using System.Globalization;

namespace GeneratorSV
{
    /// <summary>
    /// Stores SV control block parameters
    /// </summary>
    public class SVCBConfig
    {
        /// <summary>
        /// Destination MAC-address (last two octets in range 0x0000 .. 0x01FF)
        /// </summary>
        public ushort DstMAC
        {
            get { return dstMac_; }
            set
            {
                dstMac_ = value;
                Changed?.Invoke();
            }
        }
        private ushort dstMac_;

        /// <summary>
        /// Adding VLan tag to SV frame
        /// </summary>
        public bool HasVlan
        {
            get { return hasVlan_; }
            set
            {
                hasVlan_ = value;
                Changed?.Invoke();
            }
        }
        private bool hasVlan_;

        /// <summary>
        /// Virtual lan ID in range 0x000 - 0xFFF
        /// </summary>
        public ushort VlanID
        {
            get { return vlanID_; }
            set
            {
                vlanID_ = value;
                Changed?.Invoke();
            }
        }
        private ushort vlanID_;

        /// <summary>
        /// Application ID in range 0x4000 - 0x7FFF
        /// </summary>
        public ushort AppID
        {
            get { return appID_; }
            set
            {
                appID_ = value;
                Changed?.Invoke();
            }
        }
        private ushort appID_;

        /// <summary>
        /// Set simulation bit in Reserved 1
        /// </summary>
        public bool Simulated
        {
            get { return simulated_; }
            set
            { 
                simulated_ = value;
                Changed?.Invoke();
            }
        }
        private bool simulated_;

        /// <summary>
        /// Sampled values stream ID
        /// </summary>
        public string SvID
        {
            get { return svID_; }
            set
            {
                svID_ = value;
                Changed?.Invoke();
            }
        }
        private string svID_;

        /// <summary>
        /// Configuration revision
        /// </summary>
        public uint ConfRev
        {
            get { return confRev_; }
            set
            {
                confRev_ = value;
                Changed?.Invoke();
            }
        }
        private uint confRev_;

        /// <summary>
        /// Stream time synchronization type
        /// </summary>
        public byte SmpSynch
        {
            get { return smpSynch_; }
            set
            {
                smpSynch_ = value;
                Changed?.Invoke();
            }
        }
        private byte smpSynch_;


        public static bool Validate_DstMAC(string str, out ushort dstMac)
        {
            // Two hex octets string XX-XX

            if (ushort.TryParse(str.Replace("-", ""), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out dstMac))
            {
                if (dstMac <= 0x01FF)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool Validate_VlanID()
        {
            // Decimal or hexadecimal number
            // In range from 0 to 0x0FFF
            // Output type - ushort

            throw new NotImplementedException();
        }

        public static bool Validate_AppID()
        {
            // Decimal or hexadecimal number
            // In range from 0x4000 to 0x7FFF
            // Output type - ushort

            throw new NotImplementedException();
        }

        public static bool Validate_ConfRev()
        {
            // Decimal or hexadecimal number
            // In range from 0 to uint.Max
            // Output type - uint

            throw new NotImplementedException();
        }
        public static bool Validate_SmpSynch()
        {
            // Decimal or hexadecimal number
            // In range from 0 to 0xFF
            // Output type - byte

            throw new NotImplementedException();
        }

        public delegate void ChangedEventHandler();
        public event ChangedEventHandler Changed;
    }
}
