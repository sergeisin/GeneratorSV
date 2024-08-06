using System;
using System.Windows.Forms;

namespace GeneratorSV
{
    public partial class MainForm : Form
    {
        private SVPublisher publisher;
        
        public MainForm()
        {
            InitializeComponent();

            var svcbConfig = new SVCBConfig()
            {
                DstMac   = 0x0001,
                VlanID   = 0x0005,
                AppID    = 0x4000,
                SvID     = "GENERATOR_SV",
                ConfRev  =   1000,
                SmpSynch =      2
            };

            var dataConfig = new DataConfig()
            {
                Ia_mag = 100,       Ia_ang =  30,
                Ib_mag = 100,       Ib_ang = 210,
                Ic_mag = 100,       Ic_ang =  90,

                Ua_mag = 10_000,    Ua_ang =   0,
                Ub_mag = 10_000,    Ub_ang = 240,
                Uc_mag = 10_000,    Uc_ang =  12,
            };

            publisher = new SVPublisher(interfaceName: "Ethernet 3", svcbConfig, dataConfig);
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
            publisher.SVCBConfig.HasVlan = (sender as CheckBox).Checked;
        }

        private void SimBox_CheckedChanged(object sender, EventArgs e)
        {
            publisher.SVCBConfig.Simulated = (sender as CheckBox).Checked;
        }

        private void TextBox_SvID_Validated(object sender, EventArgs e)
        {
            publisher.SVCBConfig.SvID = textBox_SvID.Text;
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
