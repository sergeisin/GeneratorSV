using System;
using System.Linq;

namespace GeneratorSV.Source
{
    public static class Encoder
    {
        public static byte[] StringToByteArray(string hexString)
        {
            return Enumerable.Range(0, hexString.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hexString.Substring(x, 2), 16))
                             .ToArray();
        }

        internal static void EncodeDataSetValues(double mag, double ang, int sampleNumber, byte[] buffer, int bufPos, bool isVoltage = false)
        {
            double instVal = (isVoltage ? kU : kI) * mag * Math.Sin(W * DT * sampleNumber + ang * DegToRad);

            int value = (int)Math.Round(instVal);

            buffer[bufPos++] = (byte)(0xFF & value >> 24);
            buffer[bufPos++] = (byte)(0xFF & value >> 16);
            buffer[bufPos++] = (byte)(0xFF & value >>  8);
            buffer[bufPos++] = (byte)(0xFF & value >>  0);
        }

        const double DT = 1.0 / 4000;
        const double W = 100 * Math.PI;
        const double DegToRad = Math.PI / 180.0;

        private static double kI = 1000 * Math.Sqrt(2);
        private static double kU =  100 * Math.Sqrt(2);
    }
}
