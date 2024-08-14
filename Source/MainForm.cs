using System;
using System.Windows.Forms;
using System.Globalization;
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

            InitializeEventHandlers();

            foreach (var device in LibPcapLiveDeviceList.Instance)
            {
                if (device.Interface.MacAddress != null)
                {
                    cmBox_Device.Items.Add(device.Interface.FriendlyName);
                }
            }

            svcbConfig = new SVCBConfig();
            dataConfig = new DataConfig();

            UpdateDataView(rButton_Mode1.Checked);
        }

        private void InitializeEventHandlers()
        {
            Click += FinishEditing;

            // Select text by mouse click

            tBox_DstMAC.Click   += SelectText;
            tBox_VlanID.Click   += SelectText;
            tBox_AppID.Click    += SelectText;
            tBox_ConfRev.Click  += SelectText;
            tBox_SmpSynch.Click += SelectText;
            tBox_SvID.Click     += SelectText;
            tBox_I1.Click       += SelectText;
            tBox_I2.Click       += SelectText;
            tBox_I3.Click       += SelectText;
            tBox_I4.Click       += SelectText;
            tBox_I1a.Click      += SelectText;
            tBox_I2a.Click      += SelectText;
            tBox_I3a.Click      += SelectText;
            tBox_I4a.Click      += SelectText;
            tBox_kI.Click       += SelectText;
            tBox_kU.Click       += SelectText;

            // Finish editing by pressing enter

            tBox_DstMAC.KeyDown     += CheckFinishEditing;
            tBox_VlanID.KeyDown     += CheckFinishEditing;
            tBox_AppID.KeyDown      += CheckFinishEditing;
            tBox_ConfRev.KeyDown    += CheckFinishEditing;
            tBox_SmpSynch.KeyDown   += CheckFinishEditing;
            tBox_SvID.KeyDown       += CheckFinishEditing;
            tBox_I1.KeyDown         += CheckFinishEditing;
            tBox_I2.KeyDown         += CheckFinishEditing;
            tBox_I3.KeyDown         += CheckFinishEditing;
            tBox_I4.KeyDown         += CheckFinishEditing;
            tBox_I1a.KeyDown        += CheckFinishEditing;
            tBox_I2a.KeyDown        += CheckFinishEditing;
            tBox_I3a.KeyDown        += CheckFinishEditing;
            tBox_I4a.KeyDown        += CheckFinishEditing;
            tBox_kI.KeyDown         += CheckFinishEditing;
            tBox_kU.KeyDown         += CheckFinishEditing;

            // Edit generator settings

            tBox_I1.Validated       += TryEditMag;
            tBox_I2.Validated       += TryEditMag;
            tBox_I3.Validated       += TryEditMag;
            tBox_I4.Validated       += TryEditMag;

            tBox_I1a.Validated      += TryEditAng;
            tBox_I2a.Validated      += TryEditAng;
            tBox_I3a.Validated      += TryEditAng;
            tBox_I4a.Validated      += TryEditAng;
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

            string error = Validator.GetFormatError_DstMAC(tBox.Text, out ushort dstMac);

            if (error is null)
            {
                svcbConfig.DstMAC = dstMac;
            }
            else
            {
                ShowFormatMessage(error);
            }

            tBox.Text = svcbConfig.DstMAC.ToString("X4").Insert(2, "-");
        }

        private void TBox_VlanID_Validated(object sender, EventArgs e)
        {
            TextBox tBox = sender as TextBox;

            string error = Validator.GetFormatError_VlanID(tBox.Text, out ushort vlanID);

            if (error is null)
            {
                svcbConfig.VlanID = vlanID;
            }
            else
            {
                ShowFormatMessage(error);
            }

            tBox.Text = svcbConfig.VlanID.ToString("X3");
        }

        private void TBox_AppID_Validated(object sender, EventArgs e)
        {
            TextBox tBox = sender as TextBox;

            string error = Validator.GetFormatError_AppID(tBox.Text, out ushort appID);

            if (error is null)
            {
                svcbConfig.AppID = appID;
            }
            else
            {
                ShowFormatMessage(error);
            }

            tBox.Text = svcbConfig.AppID.ToString("X4");
        }

        private void TBox_ConfRev_Validated(object sender, EventArgs e)
        {
            TextBox tBox = sender as TextBox;

            string error = Validator.GetFormatError_ConfRev(tBox.Text, out uint confRev);

            if (error is null)
            {
                svcbConfig.ConfRev = confRev;
            }
            else
            {
                ShowFormatMessage(error);
            }

            tBox.Text = svcbConfig.ConfRev.ToString();
        }

        private void TBox_SmpSynch_Validated(object sender, EventArgs e)
        {
            TextBox tBox = sender as TextBox;

            string error = Validator.GetFormatError_SmpSynch(tBox.Text, out byte smpSynch);

            if (error is null)
            {
               svcbConfig.SmpSynch = smpSynch;
            }
            else
            {
                ShowFormatMessage(error);
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
                // Suppresses unwanted sound
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

        private void ChangeDataViewMode(object sender, EventArgs e)
        {
            var rButton = sender as RadioButton;

            if (rButton.Checked)
            {
                label_I1.Text = "Ia";
                label_I2.Text = "Ib";
                label_I3.Text = "Ic";

                label_I4.Visible = true;
                tBox_I4. Visible = true;
                tBox_I4a.Visible = true;
            }
            else
            {
                label_I1.Text = "I1";
                label_I2.Text = "I2";
                label_I3.Text = "I0";

                label_I4.Visible = false;
                tBox_I4. Visible = false;
                tBox_I4a.Visible = false;
            }

            UpdateDataView(rButton.Checked);
        }

        private void TryEditMag(object sender, EventArgs e)
        {
            TextBox tBox = sender as TextBox;

            bool phaseViewMode = rButton_Mode1.Checked;

            string error = Validator.GetFormatError_Magnitude(tBox.Text, out double mag);

            if (error is null)
            {
                if (phaseViewMode)
                {
                    switch (tBox.Tag as string)
                    {
                        case "I1m": dataConfig.Ia_Magnitude = mag; break;
                        case "I2m": dataConfig.Ib_Magnitude = mag; break;
                        case "I3m": dataConfig.Ic_Magnitude = mag; break;
                        case "I4m": dataConfig.In_Magnitude = mag; break;

                        case "U1m": break;
                        case "U2m": break;
                        case "U3m": break;
                        case "U4m": break;
                    }
                }
                else
                {
                    switch (tBox.Tag as string)
                    {
                        case "I1m": dataConfig.I1_Magnitude = mag; break;
                        case "I2m": dataConfig.I2_Magnitude = mag; break;
                        case "I3m": dataConfig.I0_Magnitude = mag; break;

                        case "U1m": break;
                        case "U2m": break;
                        case "U3m": break;
                    }
                }
            }
            else
            {
                ShowFormatMessage(error);
            }

            UpdateDataView(phaseViewMode);
        }

        private void TryEditAng(object sender, EventArgs e)
        {
            TextBox tBox = sender as TextBox;

            bool phaseViewMode = rButton_Mode1.Checked;

            string error = Validator.GetFormatError_Angle(tBox.Text, out int ang);

            if (error is null)
            {
                if (phaseViewMode)
                {
                    switch (tBox.Tag as string)
                    {
                        case "I1a": dataConfig.Ia_Angle = ang; break;
                        case "I2a": dataConfig.Ib_Angle = ang; break;
                        case "I3a": dataConfig.Ic_Angle = ang; break;
                        case "I4a": dataConfig.In_Angle = ang; break;

                        case "U1a": break;
                        case "U2a": break;
                        case "U3a": break;
                        case "U4a": break;
                    }
                }
                else
                {
                    switch (tBox.Tag as string)
                    {
                        case "I1a": dataConfig.I1_Angle = ang; break;
                        case "I2a": dataConfig.I2_Angle = ang; break;
                        case "I3a": dataConfig.I0_Angle = ang; break;

                        case "U1a": break;
                        case "U2a": break;
                        case "U3a": break;
                    }
                }
            }
            else
            {
                ShowFormatMessage(error);
            }

            UpdateDataView(phaseViewMode);
        }

        private void UpdateDataView(bool phaseViewMode)
        {
            string format = "f1";
            var cultureInfo = CultureInfo.InvariantCulture;

            if (phaseViewMode)
            {
                tBox_I1.Text = dataConfig.Ia_Magnitude.ToString(format, cultureInfo);
                tBox_I2.Text = dataConfig.Ib_Magnitude.ToString(format, cultureInfo);
                tBox_I3.Text = dataConfig.Ic_Magnitude.ToString(format, cultureInfo);
                tBox_I4.Text = dataConfig.In_Magnitude.ToString(format, cultureInfo);

                tBox_I1a.Text = dataConfig.Ia_Angle.ToString();
                tBox_I2a.Text = dataConfig.Ib_Angle.ToString();
                tBox_I3a.Text = dataConfig.Ic_Angle.ToString();
                tBox_I4a.Text = dataConfig.In_Angle.ToString();
            }
            else
            {
                tBox_I1.Text = dataConfig.I1_Magnitude.ToString(format, cultureInfo);
                tBox_I2.Text = dataConfig.I2_Magnitude.ToString(format, cultureInfo);
                tBox_I3.Text = dataConfig.I0_Magnitude.ToString(format, cultureInfo);

                tBox_I1a.Text = dataConfig.I1_Angle.ToString();
                tBox_I2a.Text = dataConfig.I2_Angle.ToString();
                tBox_I3a.Text = dataConfig.I0_Angle.ToString();
            }
        }
    }
}
