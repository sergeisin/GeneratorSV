using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace GeneratorSV
{
    public partial class MainForm : Form
    {
        private SVPublisher publisher;
        private SVConfig config;
        private DataConfig data;
        
        public MainForm()
        {
            InitializeComponent();

            config = new SVConfig()
            {
                dstMac   = "01-0c-cd-04-00-01",
                vlanID   = 0x005,
                appID    = 0x4000,
                svID     = "GENERATOR_SV",
                confRev  = 10000,
                smpSynch = 2
            };

            data = new DataConfig()
            {
                Ia_mag = 100,       Ia_ang =  30,
                Ib_mag = 100,       Ib_ang = 210,
                Ic_mag = 100,       Ic_ang =  90,

                Ua_mag = 10_000,    Ua_ang =   0,
                Ub_mag = 10_000,    Ub_ang = 240,
                Uc_mag = 10_000,    Uc_ang =  12,
            };

            publisher = new SVPublisher(interfaceName: "Ethernet 3", config, data);
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

        private void VlanBox_CheckedChanged(object sender, EventArgs e)
        {
            config.hasVlan = (sender as CheckBox).Checked;
            publisher.Config = config;
        }

        private void SimBox_CheckedChanged(object sender, EventArgs e)
        {
            config.simulated = (sender as CheckBox).Checked;
            publisher.Config = config;
        }

        private void TextBox_SvID_Validated(object sender, EventArgs e)
        {
            if (config.svID != textBox_SvID.Text)
            {
                config.svID = textBox_SvID.Text;
                publisher.Config = config;
            }
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            Validate();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            publisher.Dispose();
        }
    }
}
