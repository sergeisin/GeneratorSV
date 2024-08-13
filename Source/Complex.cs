using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorSV.Source
{
    public class Complex
    {
        public Complex(double re, double im)
        {
            re_ = re;
            im_ = im;

            mag_ = Math.Sqrt(re * re + im * im);
            ang_ = Math.Atan2(im, re);
        }

        public Complex(double mag, int ang)
        {
            mag_ = mag;
            ang_ = ang;

            throw new NotImplementedException();
        }

        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.Re + b.Re, a.Im + b.Im);
        }

        public double Re
        {
            get { return re_; }
            set { re_ = value; }
        }

        public double Im
        {
            get { return im_; }
            set { im_ = value; }
        }

        public double Mag
        {
            get { return mag_; }
            set { mag_ = value; }
        }

        public double Ang
        {
            get { return ang_; }
            set { ang_ = value; }
        }

        // Cartesian coordinates
        private double re_;
        private double im_;

        // Polar coordinates
        private double mag_;
        private double ang_;
    }
}
