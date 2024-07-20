namespace GeneratorSV
{
    internal class SVConfig
    {
        /// <summary>
        /// Destination MAC-addres (12 hex digits)
        /// </summary>
        public string dstMac;

        /// <summary>
        /// Source MAC-addres (12 hex digits)
        /// </summary>
        public string srcMac;

        /// <summary>
        /// Adding VLan tag to SV frame
        /// </summary>
        public bool hasVlan;

        /// <summary>
        /// VLan ID (3 hex digits)
        /// </summary>
        public string vlanID;

        /// <summary>
        /// Application ID is range 0x4000 - 0x7FFF
        /// </summary>
        public ushort appID;

        /// <summary>
        /// Set simulation bit in Reserved 1
        /// </summary>
        public bool simulated;

        /// <summary>
        /// Sampled values stream ID
        /// </summary>
        public string svID;

        /// <summary>
        /// Configuration revision
        /// </summary>
        public uint confRev;

        /// <summary>
        /// Stream time synchronization type
        /// </summary>
        public byte smpSynch;

        #region Three-phase system configuration

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

        #endregion
    }
}
