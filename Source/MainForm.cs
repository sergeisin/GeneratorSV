using System;
using System.Windows.Forms;
using SharpPcap.LibPcap;

namespace GeneratorSV
{
    public partial class MainForm : Form
    {
        private SVPublisher publisher;
        private SVCBConfig svcbConfig;
        private DataConfig dataConfig;

        public MainForm()
        {
            InitializeComponent();

            tBox_DstMAC.KeyDown   += CheckFinishEditing;
            tBox_VlanID.KeyDown   += CheckFinishEditing;
            tBox_AppID.KeyDown    += CheckFinishEditing;
            tBox_ConfRev.KeyDown  += CheckFinishEditing;
            tBox_SmpSynch.KeyDown += CheckFinishEditing;
            tBox_SvID.KeyDown     += CheckFinishEditing;

            tBox_DstMAC.Click     += SelectText;
            tBox_VlanID.Click     += SelectText;
            tBox_AppID.Click      += SelectText;
            tBox_ConfRev.Click    += SelectText;
            tBox_SmpSynch.Click   += SelectText;
            tBox_SvID.Click       += SelectText;

            Click += FinishEditing;

            foreach (var device in LibPcapLiveDeviceList.Instance)
            {
                if (device.Interface.MacAddress != null)
                {
                    cmBox_Device.Items.Add(device.Interface.FriendlyName);
                }
            }

            svcbConfig = new SVCBConfig()
            {
                DstMAC = 0x0001,
                VlanID = 0x0005,
                AppID = 0x4000,
                SvID = "GENERATOR_SV",
                ConfRev = 1000,
                SmpSynch = 2,
                HasVlan = true
            };

            dataConfig = new DataConfig()
            {
                Ia_mag = 100,
                Ia_ang = 30,
                Ib_mag = 100,
                Ib_ang = 210,
                Ic_mag = 100,
                Ic_ang = 90,

                Ua_mag = 10_000,
                Ua_ang = 0,
                Ub_mag = 10_000,
                Ub_ang = 240,
                Uc_mag = 10_000,
                Uc_ang = 12,
            };
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (cmBox_Device.Items.Count == 0)
            {
                MessageBox.Show("Ethernet devices not found!", "Device error!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            publisher?.Dispose();
        }

        private void CMBox_Device_SelectedIndexChanged(object sender, EventArgs e)
        {
            string interfaceName = (sender as ComboBox).SelectedItem.ToString();

            if (publisher is null || publisher.Interface != interfaceName)
            {
                publisher?.Dispose();
                publisher = new SVPublisher(interfaceName, svcbConfig, dataConfig);
            }

            runButton.Enabled = true;
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            if (publisher.IsRunning)
            {
                publisher.Stop();
                cmBox_Device.Enabled = true;
                runButton.Text = "Run";
            }
            else
            {
                publisher.Start();
                cmBox_Device.Enabled = false;
                runButton.Text = "Stop";
            }
        }

        private void CBox_Vlan_CheckedChanged(object sender, EventArgs e)
        {
            svcbConfig.HasVlan = (sender as CheckBox).Checked;
        }

        private void CBox_Sim_CheckedChanged(object sender, EventArgs e)
        {
            svcbConfig.Simulated = (sender as CheckBox).Checked;
        }

        private void TBox_SvID_Validated(object sender, EventArgs e)
        {
            svcbConfig.SvID = tBox_SvID.Text;
        }

        private void TBox_DstMAC_Validated(object sender, EventArgs e)
        {
            TextBox tBox = sender as TextBox;

            if (SVCBConfig.Validate_DstMAC(tBox.Text, out ushort dstMac))
            {
                svcbConfig.DstMAC = dstMac;
            }
            else
            {
                ShowFormatMessage("The valid range is from 00-00 to 03-FF");
            }

            tBox.Text = svcbConfig.DstMAC.ToString("X4").Insert(2, "-");
        }

        private void TBox_VlanID_Validated(object sender, EventArgs e)
        {
            TextBox tBox = sender as TextBox;

            if (SVCBConfig.Validate_VlanID(tBox.Text, out ushort vlanID))
            {
                svcbConfig.VlanID = vlanID;
            }
            else
            {
                ShowFormatMessage("The valid range is from 0x000 to 0xFFF");
            }

            tBox.Text = svcbConfig.VlanID.ToString("X3");
        }

        private void TBox_AppID_Validated(object sender, EventArgs e)
        {
            TextBox tBox = sender as TextBox;

            if (SVCBConfig.Validate_AppID(tBox.Text, out ushort appID))
            {
                svcbConfig.AppID = appID;
            }
            else
            {
                ShowFormatMessage("The valid range is from 0x4000 to 0x7FFF");
            }

            tBox.Text = svcbConfig.AppID.ToString("X4");
        }

        private void TBox_ConfRev_Validated(object sender, EventArgs e)
        {
            TextBox tBox = sender as TextBox;

            if (uint.TryParse(tBox.Text, out uint confRev))
            {
                svcbConfig.ConfRev = confRev;
            }
            else
            {
                ShowFormatMessage("This value must be a decimal number");
            }

            tBox.Text = svcbConfig.ConfRev.ToString();
        }

        private void TBox_SmpSynch_Validated(object sender, EventArgs e)
        {
            TextBox tBox = sender as TextBox;

            if (SVCBConfig.Validate_SmpSynch(tBox.Text, out byte smpSynch))
            {
               svcbConfig.SmpSynch = smpSynch;
            }
            else
            {
                ShowFormatMessage("The valid range is from 0 to 127");
            }

            string synchType = "local";
            switch (svcbConfig.SmpSynch)
            {
                case 0:   synchType = "none";     break;
                case 2:   synchType = "global";   break;
                case 3:   synchType = "reserved"; break;
                case 4:   synchType = "reserved"; break;
                case 255: synchType = "reserved"; break;
            }

            tBox.Text = $"{svcbConfig.SmpSynch} - {synchType}";
        }

        private void ShowFormatMessage(string msg)
        {
            MessageBox.Show(msg, "Format error!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void SelectText(object sender, EventArgs e)
        {
            TextBox tBox = sender as TextBox;
            tBox.Select(0, tBox.TextLength);
        }

        private void CheckFinishEditing(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                FinishEditing();
            }
        }

        private void FinishEditing(object sender = null, EventArgs e = null)
        {
            // Removes text selection
            // Triggers event "Validated"

            dummyLabel.Focus();
        }
    }
}
