
namespace GeneratorSV
{
    /// <summary>
    /// Stores data set values - 4 currents and 4 voltages
    /// </summary>
    public class DataSetValues
    {
        public double Ia_mag { get; set; }
        public double Ia_ang { get; set; }
        public double Ib_mag { get; set; }
        public double Ib_ang { get; set; }
        public double Ic_mag { get; set; }
        public double Ic_ang { get; set; }
        public double I0_mag { get; set; }
        public double I0_ang { get; set; }

        public double Ua_mag { get; set; }
        public double Ua_ang { get; set; }
        public double Ub_mag { get; set; }
        public double Ub_ang { get; set; }
        public double Uc_mag { get; set; }
        public double Uc_ang { get; set; }
        public double U0_mag { get; set; }
        public double U0_ang { get; set; }
    }
}
