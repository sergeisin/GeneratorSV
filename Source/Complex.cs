using System;

namespace GeneratorSV
{
    public class Complex
    {
        public Complex(double re, double im)
        {
            Re = re;
            Im = im;

            Mag = Math.Sqrt(re * re + im * im);
            Rad = Math.Atan2(im, re);
            Deg = Rad * RadToDeg;
            
            if (Deg < 0)
                Deg += 360.0;
        }

        public static Complex FromPolars(double mag, double rad)
        {
            double re = mag * Math.Cos(rad);
            double im = mag * Math.Sin(rad);

            return new Complex(re, im);
        }

        public static Complex Rotate(Complex c, double angRads)
        {
            return FromPolars(c.Mag, c.Rad + angRads);
        }

        public static Complex operator + (Complex a, Complex b)
        {
            return new Complex(a.Re + b.Re, a.Im + b.Im);
        }

        public static Complex operator * (Complex c, double v)
        {
            return new Complex(c.Re * v, c.Im * v);
        }

        public static Complex operator / (Complex c, double v)
        {
            return new Complex(c.Re / v, c.Im / v);
        }

        public double Re  { get; }
        public double Im  { get; }
        public double Mag { get; }
        public double Rad { get; }
        public double Deg { get; }

        public const double RadToDeg = 180.0 / Math.PI;
        public const double DegToRad = Math.PI / 180.0;
    }
}
