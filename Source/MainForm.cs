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
                DstMAC   = 0x0001,
                VlanID   = 0x0005,
                AppID    = 0x4000,
                SvID     = "GENERATOR_SV",
                ConfRev  =   1000,
                SmpSynch =      2,
                HasVlan  = true
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

        private void MainForm_Click(object sender, EventArgs e)
        {
            // Removes text selection from all form elements
            dummyLabel.Focus();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            publisher.Dispose();
        }

        #region SvCB settings entering

        private void CBox_Vlan_CheckedChanged(object sender, EventArgs e)
        {
            publisher.SVCBConfig.HasVlan = (sender as CheckBox).Checked;
        }

        private void CBox_Sim_CheckedChanged(object sender, EventArgs e)
        {
            publisher.SVCBConfig.Simulated = (sender as CheckBox).Checked;
        }

        private void TBox_SvID_Validated(object sender, EventArgs e)
        {
            publisher.SVCBConfig.SvID = tBox_SvID.Text;
        }

        private void TBox_DstMAC_Click(object sender, EventArgs e)
        {
            TextBox tBox = sender as TextBox;
            tBox.Select(0, tBox.TextLength);
        }

        private void TBox_DstMAC_Validated(object sender, EventArgs e)
        {
            TextBox tBox = sender as TextBox;

            if (SVCBConfig.Validate_DstMAC(tBox.Text, out ushort dstMac))
            {
                publisher.SVCBConfig.DstMAC = dstMac;
            }
            else
            {
                string msg  = "The valid range is from 00-00 to 01-FF";
                MessageBox.Show(msg, "Format error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            tBox.Text = publisher.SVCBConfig.DstMAC.ToString("X4").Insert(2, "-");
        }

        private void TBox_VlanID_Click(object sender, EventArgs e)
        {
            TextBox tBox = sender as TextBox;
            tBox.Select(0, tBox.TextLength);
        }

        private void TBox_VlanID_Validated(object sender, EventArgs e)
        {
            TextBox tBox = sender as TextBox;

            if (SVCBConfig.Validate_VlanID(tBox.Text, out ushort vlanID))
            {
                publisher.SVCBConfig.VlanID = vlanID;
            }
            else
            {
                string msg = "The valid range is from 0x000 to 0xFFF";
                MessageBox.Show(msg, "Format error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            tBox.Text = publisher.SVCBConfig.VlanID.ToString("X3");
        }

        private void TBox_AppID_Click(object sender, EventArgs e)
        {
            TextBox tBox = sender as TextBox;
            tBox.Select(0, tBox.TextLength);
        }

        private void TBox_AppID_Validated(object sender, EventArgs e)
        {
            TextBox tBox = sender as TextBox;

            if (SVCBConfig.Validate_AppID(tBox.Text, out ushort appID))
            {
                publisher.SVCBConfig.AppID = appID;
            }
            else
            {
                string msg = "The valid range is from 0x4000 to 0x7FFF";
                MessageBox.Show(msg, "Format error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            tBox.Text = publisher.SVCBConfig.AppID.ToString("X4");
        }

        private void TBox_ConfRev_Click(object sender, EventArgs e)
        {
            TextBox tBox = sender as TextBox;
            tBox.Select(0, tBox.TextLength);
        }

        private void TBox_ConfRev_Validated(object sender, EventArgs e)
        {
            TextBox tBox = sender as TextBox;

            if (uint.TryParse(tBox.Text, out uint confRev))
            {
                publisher.SVCBConfig.ConfRev = confRev;
            }
            else
            {
                string msg = "This value must be a number";
                MessageBox.Show(msg, "Format error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            tBox.Text = publisher.SVCBConfig.ConfRev.ToString();
        }

        private void TBox_SmpSynch_Click(object sender, EventArgs e)
        {
            TextBox tBox = sender as TextBox;
            tBox.Select(0, tBox.TextLength);
        }

        private void TBox_SmpSynch_Validated(object sender, EventArgs e)
        {
            TextBox tBox = sender as TextBox;

            if (SVCBConfig.Validate_SmpSynch(tBox.Text, out byte smpSynch))
            {
                publisher.SVCBConfig.SmpSynch = smpSynch;
            }
            else
            {
                string msg = "The valid range is from 0 to 127";
                MessageBox.Show(msg, "Format error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            string synchType = "local";
            switch (publisher.SVCBConfig.SmpSynch)
            {
                case 0:   synchType = "none";     break;
                case 2:   synchType = "global";   break;
                case 3:   synchType = "reserved"; break;
                case 4:   synchType = "reserved"; break;
                case 255: synchType = "reserved"; break;
            }

            tBox.Text = $"{publisher.SVCBConfig.SmpSynch} - {synchType}";
        }

        #endregion
    }
}
