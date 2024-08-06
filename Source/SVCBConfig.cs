using System;
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

        public static bool Validate_VlanID(string str, out ushort vlanID)
        {
            string text = str.Replace(" ", "").Replace("0x", "");

            if (ushort.TryParse(text, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out vlanID))
            {
                if (vlanID <= 0x0FFF)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool Validate_AppID(string str, out ushort appID)
        {
            string text = str.Replace(" ", "").Replace("0x", "");

            if (ushort.TryParse(text, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out appID))
            {
                if (appID <= 0x7FFF && appID >= 0x4000)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool Validate_ConfRev(string str, out uint confRev)
        {
            if (uint.TryParse(str, out confRev))
            {
                return true;
            }
            return false;
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
