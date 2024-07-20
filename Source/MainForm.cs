using System;
using System.Windows.Forms;

namespace GeneratorSV
{
    public partial class MainForm : Form
    {
        SVPublisher publisher;
        
        public MainForm()
        {
            InitializeComponent();

            publisher = new SVPublisher(interfaceName: "Ethernet", new SVConfig()
            {
                dstMac = "01-0c-cd-04-00-01",
                srcMac = null,

                hasVlan = true,
                vlanID = "005",

                appID = 0x4242,
                simulated = false,
                svID = "Sampled values generator STREAM_111",
                confRev = 10000,
                smpSynch = 2,

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
            });
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            if (publisher.IsRunning)
            {
                publisher.Stop();
                runButton.Text = "Run";
            }
            else
            {
                publisher.Start();
                runButton.Text = "Stop";
            }
        }
    }
}
