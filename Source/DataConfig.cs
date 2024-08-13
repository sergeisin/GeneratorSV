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
            // var I0 = Complex.FromPolar(mag_I0_, ang_I0_);

            // var I1    = Complex.FromPolar(mag_I1_, ang_I1_ + 000);
            // var I1_A  = Complex.FromPolar(mag_I1_, ang_I1_ + 120);
            // var I1_AA = Complex.FromPolar(mag_I1_, ang_I1_ + 240);

            // var I2    = Complex.FromPolar(mag_I2_, ang_I2_ + 000);
            // var I2_A  = Complex.FromPolar(mag_I2_, ang_I2_ + 120);
            // var I2_AA = Complex.FromPolar(mag_I2_, ang_I2_ + 240);

            // var Ia = I1    + I2    + I0;
            // var Ib = I1_AA + I2_A  + I0;
            // var Ic = I1_A  + I2_AA + I0;
            // var In = Ia + Ib + Ic;

            // mag_Ia_ = Ia.Mag;  ang_Ia_ = Ia.Ang;
            // mag_Ib_ = Ib.Mag;  ang_Ib_ = Ib.Ang;
            // mag_Ic_ = Ic.Mag;  ang_Ic_ = Ic.Ang;
            // mag_In_ = In.Mag;  ang_In_ = In.Ang;

            // Оператор A  - "ang + 120"
            // Оператор AA - "ang + 240"

            Changed?.Invoke();
            throw new NotImplementedException();
        }

        private void ComputeVoltagesFromSequences() // U1, U2, U0
        {
            Changed?.Invoke();
            throw new NotImplementedException();
        }

        private void ComputeCurrentsFromPhasors()   // Ia, Ib, Ic, In
        {
            // I1 = (Ia +   a * Ib + a*a * Ic) / 3
            // I2 = (Ia + a*a * Ib +   a * Ic) / 3
            // I0 = (Ia +       Ib +       Ic) / 3

            Changed?.Invoke();
            throw new NotImplementedException();
        }

        private void ComputeVoltagesFromPhasors()   // Ua, Ub, Uc, Un
        {
            Changed?.Invoke();
            throw new NotImplementedException();
        }

        public int KI { get; set; } = 1000;
        public int KU { get; set; } =  100;

        public delegate void ChangedEventHandler();
        public event ChangedEventHandler Changed;
    }
}
