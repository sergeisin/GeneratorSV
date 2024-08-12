using System;
using System.Globalization;

namespace GeneratorSV.Source
{
    public static class Validator
    {
        public static string GetFormatError_DstMAC(string str, out ushort dstMac)
        {
            // Two hex octets string XX-XX
            if (ushort.TryParse(str.Replace("-", ""), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out dstMac))
            {
                if (dstMac <= 0x03FF)
                {
                    return null;
                }
            }

            return "The valid range is from 00-00 to 03-FF";
        }

        public static string GetFormatError_VlanID(string str, out ushort vlanID)
        {
            string text = str.Replace(" ", "").Replace("0x", "");

            if (ushort.TryParse(text, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out vlanID))
            {
                if (vlanID <= 0x0FFF)
                {
                    return null;
                }
            }

            return "The valid range is from 0x000 to 0xFFF";
        }

        public static string GetFormatError_AppID(string str, out ushort appID)
        {
            string text = str.Replace(" ", "").Replace("0x", "");

            if (ushort.TryParse(text, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out appID))
            {
                if (appID <= 0x7FFF && appID >= 0x4000)
                {
                    return null;
                }
            }

            return "The valid range is from 0x4000 to 0x7FFF";
        }

        public static string GetFormatError_ConfRev(string str, out uint confRev)
        {
            if (uint.TryParse(str, out confRev))
            {
                return null;
            }

            return "This value must be a decimal number";
        }

        public static string GetFormatError_SmpSynch(string str, out byte smpSynch)
        {
            var sArr = str.Split('-');

            if (byte.TryParse(sArr[0], out smpSynch))
            {
                if (smpSynch <= 0x7F)
                {
                    return null;
                }
            }

            return "The valid range is from 0 to 127";
        }

        public static string GetFormatError_Magnitude(string str, out double magnitude)
        {
            throw new NotImplementedException();
        }

        public static string GetFormatError_Angle(string str, out int angle)
        {
            throw new NotImplementedException();
        }
    }
}
