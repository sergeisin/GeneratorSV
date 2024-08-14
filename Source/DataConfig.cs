using System;

namespace GeneratorSV
{
    /// <summary>
    /// Stores parameters of three-phase system
    /// </summary>
    public class DataConfig
    {
        /// <summary>
        /// Default generator configuration
        /// </summary>
        public DataConfig()
        {
            mag_I1_ = 100;      ang_I1_ =  30;
            mag_Ia_ = 100;      ang_Ia_ =  30;
            mag_Ib_ = 100;      ang_Ib_ = 270;
            mag_Ic_ = 100;      ang_Ic_ = 150;

            mag_U1_ = 10_000;   ang_U1_ =   0;
            mag_Ua_ = 10_000;   ang_Ua_ =   0;
            mag_Ub_ = 10_000;   ang_Ub_ = 240;
            mag_Uc_ = 10_000;   ang_Uc_ = 120;
        }

        /// <summary>
        /// Minimum possible change if magnitude
        /// </summary>
        public static double Epsilon { get; } = 0.1;

        /// <summary>
        /// RMS value of positive sequence current
        /// </summary>
        public double I1_Magnitude
        {
            get { return mag_I1_; }
            set
            {
                if (Math.Abs(value - mag_I1_) > Epsilon)
                {
                    mag_I1_ = value;
                    ang_I1_ = (value < Epsilon) ? 0 : ang_I1_;
                    ComputeCurrentsFromSequences();
                }
            }
        }
        private double mag_I1_;

        /// <summary>
        /// RMS value of negative sequence current
        /// </summary>
        public double I2_Magnitude
        {
            get { return mag_I2_; }
            set
            {
                if (Math.Abs(value - mag_I2_) > Epsilon)
                {
                    mag_I2_ = value;
                    ang_I2_ = (value < Epsilon) ? 0 : ang_I2_;
                    ComputeCurrentsFromSequences();
                }
            }
        }
        private double mag_I2_;

        /// <summary>
        /// RMS value of zero sequence current
        /// </summary>
        public double I0_Magnitude
        {
            get { return mag_I0_; }
            set
            {
                if (Math.Abs(value - mag_I0_) > Epsilon)
                {
                    mag_I0_ = value;
                    ang_I0_ = (value < Epsilon) ? 0 : ang_I0_;
                    ComputeCurrentsFromSequences();
                }
            }
        }
        private double mag_I0_;

        /// <summary>
        /// Phase of positive sequence current
        /// </summary>
        public int I1_Angle
        {
            get { return ang_I1_; }
            set
            {
                if (value >= 0 && value < 360 && value != ang_I1_)
                {
                    ang_I1_ = value;
                    ComputeCurrentsFromSequences();
                }
            }
        }
        private int ang_I1_;

        /// <summary>
        /// Phase of negative sequence current
        /// </summary>
        public int I2_Angle
        {
            get { return ang_I2_; }
            set
            {
                if (value >= 0 && value < 360 && value != ang_I2_)
                {
                    ang_I2_ = value;
                    ComputeCurrentsFromSequences();
                }
            }
        }
        private int ang_I2_;

        /// <summary>
        /// Phase of zero sequence current
        /// </summary>
        public int I0_Angle
        {
            get { return ang_I0_; }
            set
            {
                if (value >= 0 && value < 360 && value != ang_I0_)
                {
                    ang_I0_ = value;
                    ComputeCurrentsFromSequences();
                }
            }
        }
        private int ang_I0_;

        /// <summary>
        /// RMS value of phase A current
        /// </summary>
        public double Ia_Magnitude
        {
            get { return mag_Ia_; }
            set
            {
                if (Math.Abs(value - mag_Ia_) > Epsilon)
                {
                    mag_Ia_ = value;
                    ang_Ia_ = (value < Epsilon) ? 0 : ang_Ia_;
                    ComputeCurrentsFromPhasors();
                }
            }
        }
        private double mag_Ia_;

        /// <summary>
        /// RMS value of phase B current
        /// </summary>
        public double Ib_Magnitude
        {
            get { return mag_Ib_; }
            set
            {
                if (Math.Abs(value - mag_Ib_) > Epsilon)
                {
                    mag_Ib_ = value;
                    ang_Ib_ = (value < Epsilon) ? 0 : ang_Ib_;
                    ComputeCurrentsFromPhasors();
                }
            }
        }
        private double mag_Ib_;

        /// <summary>
        /// RMS value of phase C current
        /// </summary>
        public double Ic_Magnitude
        {
            get { return mag_Ic_; }
            set
            {
                if (Math.Abs(value - mag_Ic_) > Epsilon)
                {
                    mag_Ic_ = value;
                    ang_Ic_ = (value < Epsilon) ? 0 : ang_Ic_;
                    ComputeCurrentsFromPhasors();
                }
            }
        }
        private double mag_Ic_;

        /// <summary>
        /// RMS value of neutral current
        /// </summary>
        public double In_Magnitude
        {
            get { return mag_In_; }
            set
            {
                if (Math.Abs(value - mag_In_) > Epsilon)
                {
                    mag_In_ = value;
                    ang_In_ = (value < Epsilon) ? 0 : ang_In_;
                    ComputeCurrentsFromPhasors();
                }
            }
        }
        private double mag_In_;

        /// <summary>
        /// Angle of phase A current
        /// </summary>
        public int Ia_Angle
        {
            get { return ang_Ia_; }
            set
            {
                if (value >= 0 && value < 360 && value != ang_Ia_)
                {
                    ang_Ia_ = value;
                    ComputeCurrentsFromPhasors();
                }
            }
        }
        private int ang_Ia_;

        /// <summary>
        /// Angle of phase B current
        /// </summary>
        public int Ib_Angle
        {
            get { return ang_Ib_; }
            set
            {
                if (value >= 0 && value < 360 && value != ang_Ib_)
                {
                    ang_Ib_ = value;
                    ComputeCurrentsFromPhasors();
                }
            }
        }
        private int ang_Ib_;

        /// <summary>
        /// Angle of phase C current
        /// </summary>
        public int Ic_Angle
        {
            get { return ang_Ic_; }
            set
            {
                if (value >= 0 && value < 360 && value != ang_Ic_)
                {
                    ang_Ic_ = value;
                    ComputeCurrentsFromPhasors();
                }
            }
        }
        private int ang_Ic_;

        /// <summary>
        /// Angle of neutral current
        /// </summary>
        public int In_Angle
        {
            get { return ang_In_; }
            set
            {
                if (value >= 0 && value < 360 && value != ang_In_)
                {
                    ang_In_ = value;
                    ComputeCurrentsFromPhasors();
                }
            }
        }
        private int ang_In_;

        /// <summary>
        /// RMS value of positive sequence voltage
        /// </summary>
        public double U1_Magnitude
        {
            get { return mag_U1_; }
            set
            {
                if (Math.Abs(value - mag_U1_) > Epsilon)
                {
                    mag_U1_ = value;
                    ComputeVoltagesFromSequences();
                }
            }
        }
        private double mag_U1_;

        /// <summary>
        /// RMS value of negative sequence voltage
        /// </summary>
        public double U2_Magnitude
        {
            get { return mag_U2_; }
            set
            {
                if (Math.Abs(value - mag_U2_) > Epsilon)
                {
                    mag_U2_ = value;
                    ComputeVoltagesFromSequences();
                }
            }
        }
        private double mag_U2_;

        /// <summary>
        /// RMS value of zero sequence voltage
        /// </summary>
        public double U0_Magnitude
        {
            get { return mag_U0_; }
            set
            {
                if (Math.Abs(value - mag_U0_) > Epsilon)
                {
                    mag_U0_ = value;
                    ComputeVoltagesFromSequences();
                }
            }
        }
        private double mag_U0_;

        /// <summary>
        /// Phase of positive sequence voltage
        /// </summary>
        public int U1_Angle
        {
            get { return ang_U1_; }
            set
            {
                if (value >= 0 && value < 360 && value != ang_U1_)
                {
                    ang_U1_ = value;
                    ComputeVoltagesFromSequences();
                }
            }
        }
        private int ang_U1_;

        /// <summary>
        /// Phase of negative sequence voltage
        /// </summary>
        public int U2_Angle
        {
            get { return ang_U2_; }
            set
            {
                if (value >= 0 && value < 360 && value != ang_U2_)
                {
                    ang_U2_ = value;
                    ComputeVoltagesFromSequences();
                }
            }
        }
        private int ang_U2_;

        /// <summary>
        /// Phase of zero sequence voltage
        /// </summary>
        public int U0_Angle
        {
            get { return ang_U0_; }
            set
            {
                if (value >= 0 && value < 360 && value != ang_U0_)
                {
                    ang_U0_ = value;
                    ComputeVoltagesFromSequences();
                }
            }
        }
        private int ang_U0_;

        /// <summary>
        /// RMS value of phase A voltage
        /// </summary>
        public double Ua_Magnitude
        {
            get { return mag_Ua_; }
            set
            {
                if (Math.Abs(value - mag_Ua_) > Epsilon)
                {
                    mag_Ua_ = value;
                    ComputeVoltagesFromPhasors();
                }
            }
        }
        private double mag_Ua_;

        /// <summary>
        /// RMS value of phase B voltage
        /// </summary>
        public double Ub_Magnitude
        {
            get { return mag_Ub_; }
            set
            {
                if (Math.Abs(value - mag_Ub_) > Epsilon)
                {
                    mag_Ub_ = value;
                    ComputeVoltagesFromPhasors();
                }
            }
        }
        private double mag_Ub_;

        /// <summary>
        /// RMS value of phase C voltage
        /// </summary>
        public double Uc_Magnitude
        {
            get { return mag_Uc_; }
            set
            {
                if (Math.Abs(value - mag_Uc_) > Epsilon)
                {
                    mag_Uc_ = value;
                    ComputeVoltagesFromPhasors();
                }
            }
        }
        private double mag_Uc_;

        /// <summary>
        /// RMS value of neutral voltage
        /// </summary>
        public double Un_Magnitude
        {
            get { return mag_Un_; }
            set
            {
                if (Math.Abs(value - mag_Un_) > Epsilon)
                {
                    mag_Un_ = value;
                    ComputeVoltagesFromPhasors();
                }
            }
        }
        private double mag_Un_;

        /// <summary>
        /// Angle of phase A voltage
        /// </summary>
        public int Ua_Angle
        {
            get { return ang_Ua_; }
            set
            {
                if (value >= 0 && value < 360 && value != ang_Ua_)
                {
                    ang_Ua_ = value;
                    ComputeVoltagesFromPhasors();
                }
            }
        }
        private int ang_Ua_;

        /// <summary>
        /// Angle of phase B voltage
        /// </summary>
        public int Ub_Angle
        {
            get { return ang_Ub_; }
            set
            {
                if (value >= 0 && value < 360 && value != ang_Ub_)
                {
                    ang_Ub_ = value;
                    ComputeVoltagesFromPhasors();
                }
            }
        }
        private int ang_Ub_;

        /// <summary>
        /// Angle of phase C voltage
        /// </summary>
        public int Uc_Angle
        {
            get { return ang_Uc_; }
            set
            {
                if (value >= 0 && value < 360 && value != ang_Uc_)
                {
                    ang_Uc_ = value;
                    ComputeVoltagesFromPhasors();
                }
            }
        }
        private int ang_Uc_;

        /// <summary>
        /// Angle of neutral voltage
        /// </summary>
        public int Un_Angle
        {
            get { return ang_Un_; }
            set
            {
                if (value >= 0 && value < 360 && value != ang_Un_)
                {
                    ang_Un_ = value;
                    ComputeVoltagesFromPhasors();
                }
            }
        }
        private int ang_Un_;

        private void ComputeCurrentsFromSequences()
        {
            var I0 = Complex.FromPolars(mag_I0_, Complex.DegToRad * ang_I0_);
            var I1 = Complex.FromPolars(mag_I1_, Complex.DegToRad * ang_I1_);
            var I2 = Complex.FromPolars(mag_I2_, Complex.DegToRad * ang_I2_);

            var I1_a1 = Complex.Rotate(I1, Complex.DegToRad * 120);
            var I1_a2 = Complex.Rotate(I1, Complex.DegToRad * 240);

            var I2_a1 = Complex.Rotate(I2, Complex.DegToRad * 120);
            var I2_a2 = Complex.Rotate(I2, Complex.DegToRad * 240);

            var Ia = I1    + I2    + I0;
            var Ib = I1_a2 + I2_a1 + I0;
            var Ic = I1_a1 + I2_a2 + I0;
            var In = Ia    + Ib    + Ic;

            mag_Ia_ = Ia.Mag;
            ang_Ia_ = (mag_Ia_ < Epsilon) ? 0 : (int)Math.Round(Ia.Deg);

            mag_Ib_ = Ib.Mag;
            ang_Ib_ = (mag_Ib_ < Epsilon) ? 0 : (int)Math.Round(Ib.Deg);

            mag_Ic_ = Ic.Mag;
            ang_Ic_ = (mag_Ic_ < Epsilon) ? 0 : (int)Math.Round(Ic.Deg);

            mag_In_ = In.Mag;
            ang_In_ = (mag_In_ < Epsilon) ? 0 : (int)Math.Round(In.Deg);

            Changed?.Invoke();
        }

        private void ComputeVoltagesFromSequences()
        {
            var U1 = Complex.FromPolars(mag_U1_, Complex.DegToRad * ang_U1_);
            var U2 = Complex.FromPolars(mag_U2_, Complex.DegToRad * ang_U2_);
            var U0 = Complex.FromPolars(mag_U0_, Complex.DegToRad * ang_U0_);

            var U1_a1 = Complex.Rotate(U1, Complex.DegToRad * 120);
            var U1_a2 = Complex.Rotate(U1, Complex.DegToRad * 240);

            var U2_a1 = Complex.Rotate(U2, Complex.DegToRad * 120);
            var U2_a2 = Complex.Rotate(U2, Complex.DegToRad * 240);

            var Ua = U1    + U2    + U0;
            var Ub = U1_a2 + U2_a1 + U0;
            var Uc = U1_a1 + U2_a2 + U0;
            var Un = Ua    + Ub    + Uc;

            mag_Ua_ = Ua.Mag;
            ang_Ua_ = (mag_Ua_ < Epsilon) ? 0 : (int)Math.Round(Ua.Deg);

            mag_Ub_ = Ub.Mag;
            ang_Ub_ = (mag_Ub_ < Epsilon) ? 0 : (int)Math.Round(Ub.Deg);

            mag_Uc_ = Uc.Mag;
            ang_Uc_ = (mag_Uc_ < Epsilon) ? 0 : (int)Math.Round(Uc.Deg);

            mag_Un_ = Un.Mag;
            ang_Un_ = (mag_Un_ < Epsilon) ? 0 : (int)Math.Round(Un.Deg);

            Changed?.Invoke();
        }

        private void ComputeCurrentsFromPhasors()
        {
            var Ia = Complex.FromPolars(mag_Ia_, Complex.DegToRad * ang_Ia_);
            var Ib = Complex.FromPolars(mag_Ib_, Complex.DegToRad * ang_Ib_);
            var Ic = Complex.FromPolars(mag_Ic_, Complex.DegToRad * ang_Ic_);

            var Ib_a1 = Complex.Rotate(Ib, Complex.DegToRad * 120);
            var Ib_a2 = Complex.Rotate(Ib, Complex.DegToRad * 240);

            var Ic_a1 = Complex.Rotate(Ic, Complex.DegToRad * 120);
            var Ic_a2 = Complex.Rotate(Ic, Complex.DegToRad * 240);

            var I1 = (Ia + Ib_a1 + Ic_a2) / 3.0;
            var I2 = (Ia + Ib_a2 + Ic_a1) / 3.0;
            var I0 = (Ia + Ib    + Ic)    / 3.0;

            mag_I1_ = I1.Mag;
            ang_I1_ = (mag_I1_ < Epsilon) ? 0 : (int)Math.Round(I1.Deg);

            mag_I2_ = I2.Mag;
            ang_I2_ = (mag_I2_ < Epsilon) ? 0 : (int)Math.Round(I2.Deg);

            mag_I0_ = I0.Mag;
            ang_I0_ = (mag_I0_ < Epsilon) ? 0 : (int)Math.Round(I0.Deg);

            Changed?.Invoke();
        }

        private void ComputeVoltagesFromPhasors()
        {
            var Ua = Complex.FromPolars(mag_Ua_, Complex.DegToRad * ang_Ua_);
            var Ub = Complex.FromPolars(mag_Ub_, Complex.DegToRad * ang_Ub_);
            var Uc = Complex.FromPolars(mag_Uc_, Complex.DegToRad * ang_Uc_);

            var Ub_a1 = Complex.Rotate(Ub, Complex.DegToRad * 120);
            var Ub_a2 = Complex.Rotate(Ub, Complex.DegToRad * 240);

            var Uc_a1 = Complex.Rotate(Uc, Complex.DegToRad * 120);
            var Uc_a2 = Complex.Rotate(Uc, Complex.DegToRad * 240);

            var U1 = (Ua + Ub_a1 + Uc_a2) / 3.0;
            var U2 = (Ua + Ub_a2 + Uc_a1) / 3.0;
            var U0 = (Ua + Ub    + Uc)    / 3.0;

            mag_U1_ = U1.Mag;
            ang_U1_ = (mag_U1_ < Epsilon) ? 0 : (int)Math.Round(U1.Deg);

            mag_U2_ = U2.Mag;
            ang_U2_ = (mag_U2_ < Epsilon) ? 0 : (int)Math.Round(U2.Deg);

            mag_U0_ = U0.Mag;
            ang_U0_ = (mag_U0_ < Epsilon) ? 0 : (int)Math.Round(U0.Deg);

            Changed?.Invoke();
        }

        public int KI { get; set; } = 1000;
        public int KU { get; set; } =  100;

        public delegate void ChangedEventHandler();
        public event ChangedEventHandler Changed;
    }
}
