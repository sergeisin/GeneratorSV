namespace GeneratorSV
{
    /// <summary>
    /// Stores sampler values control block parameters
    /// </summary>
    internal class SVConfig
    {
        /// <summary>
        /// Destination MAC-addres (12 hex digits)
        /// </summary>
        public string dstMac;

        /// <summary>
        /// Adding VLan tag to SV frame
        /// </summary>
        public bool hasVlan;

        /// <summary>
        /// Virtual lan ID in range 0x000 - 0xFFF
        /// </summary>
        public ushort vlanID;

        /// <summary>
        /// Application ID in range 0x4000 - 0x7FFF
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
