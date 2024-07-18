using System;
using System.Windows.Forms;

namespace GeneratorSV
{
    public partial class MainForm : Form
    {
        SV_Settings settings;
        SV_Publisher publisher;

        public MainForm()
        {
            InitializeComponent();

            settings = new SV_Settings()
            {
                interfaceName = "Ethernet",
                dstMac = "01-0c-cd-04-00-01",
                appID = 0x4000,
                vlanID = "005",
                hasVlan = false,

                Ia_mag = 100,
                Ia_ang = 30,
                Ib_mag = 100,
                Ib_ang = 210,
                Ic_mag = 100,
                Ic_ang = 90,

                Ua_mag = 10000,
                Ua_ang = 0,
                Ub_mag = 10000,
                Ub_ang = 240,
                Uc_mag = 10000,
                Uc_ang = 120,

                passRate = 2
            };

            publisher = new SV_Publisher(settings);
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            Enabled = false;
            publisher.Run(useSandQueue: true);
            Enabled = true;
            MessageBox.Show("Done!", "SV_Publisher.Run()", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
