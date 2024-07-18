
namespace GeneratorSV
{
    class SV_Settings
    {
        public string interfaceName;    // Interface short name
        public string dstMac;           // Destination MAC-addres (12 hex digits)
        public string srcMac;           // Source MAC-addres      (12 hex digits)
        public string vlanID;           // VLanID                 ( 3 hex digits)
        public bool hasVlan;            // Adding VLan tag to SV message
        public ushort appID;            // Application Id
        public int passRate = 1;        // Delay limit (periods)

        public double Ia_mag;
        public double Ia_ang;

        public double Ib_mag;
        public double Ib_ang;

        public double Ic_mag;
        public double Ic_ang;

        public double I0_mag;
        public double I0_ang;

        public double Ua_mag;
        public double Ua_ang;

        public double Ub_mag;
        public double Ub_ang;

        public double Uc_mag;
        public double Uc_ang;

        public double U0_mag;
        public double U0_ang;
    }
}