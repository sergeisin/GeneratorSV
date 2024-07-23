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
    }
}
