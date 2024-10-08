﻿namespace GeneratorSV
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.runButton = new System.Windows.Forms.Button();
            this.cBox_Vlan = new System.Windows.Forms.CheckBox();
            this.cBox_Sim = new System.Windows.Forms.CheckBox();
            this.tBox_SvID = new System.Windows.Forms.TextBox();
            this.tBox_DstMAC = new System.Windows.Forms.TextBox();
            this.label_dstMac = new System.Windows.Forms.Label();
            this.label_VlanID = new System.Windows.Forms.Label();
            this.tBox_VlanID = new System.Windows.Forms.TextBox();
            this.label_AppID = new System.Windows.Forms.Label();
            this.tBox_AppID = new System.Windows.Forms.TextBox();
            this.label_ConfRev = new System.Windows.Forms.Label();
            this.tBox_ConfRev = new System.Windows.Forms.TextBox();
            this.label_SmpSynch = new System.Windows.Forms.Label();
            this.tBox_SmpSynch = new System.Windows.Forms.TextBox();
            this.dummyLabel = new System.Windows.Forms.Label();
            this.label_SvID = new System.Windows.Forms.Label();
            this.cmBox_Device = new System.Windows.Forms.ComboBox();
            this.label_Interface = new System.Windows.Forms.Label();
            this.tBox_I1 = new System.Windows.Forms.TextBox();
            this.tBox_I2 = new System.Windows.Forms.TextBox();
            this.tBox_I3 = new System.Windows.Forms.TextBox();
            this.tBox_I4 = new System.Windows.Forms.TextBox();
            this.tBox_I1a = new System.Windows.Forms.TextBox();
            this.tBox_I2a = new System.Windows.Forms.TextBox();
            this.tBox_I3a = new System.Windows.Forms.TextBox();
            this.tBox_I4a = new System.Windows.Forms.TextBox();
            this.tBox_kI = new System.Windows.Forms.TextBox();
            this.label_kI = new System.Windows.Forms.Label();
            this.tBox_kU = new System.Windows.Forms.TextBox();
            this.label_kU = new System.Windows.Forms.Label();
            this.label_I1 = new System.Windows.Forms.Label();
            this.label_I2 = new System.Windows.Forms.Label();
            this.label_I3 = new System.Windows.Forms.Label();
            this.label_I4 = new System.Windows.Forms.Label();
            this.label_Mag = new System.Windows.Forms.Label();
            this.label_Ang = new System.Windows.Forms.Label();
            this.rButton_Mode1 = new System.Windows.Forms.RadioButton();
            this.rButton_Mode2 = new System.Windows.Forms.RadioButton();
            this.tBox_U1 = new System.Windows.Forms.TextBox();
            this.tBox_U2 = new System.Windows.Forms.TextBox();
            this.tBox_U3 = new System.Windows.Forms.TextBox();
            this.tBox_U4 = new System.Windows.Forms.TextBox();
            this.tBox_U1a = new System.Windows.Forms.TextBox();
            this.tBox_U2a = new System.Windows.Forms.TextBox();
            this.tBox_U3a = new System.Windows.Forms.TextBox();
            this.tBox_U4a = new System.Windows.Forms.TextBox();
            this.label_U1 = new System.Windows.Forms.Label();
            this.label_U2 = new System.Windows.Forms.Label();
            this.label_U3 = new System.Windows.Forms.Label();
            this.label_U4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // runButton
            // 
            this.runButton.Enabled = false;
            this.runButton.Location = new System.Drawing.Point(109, 207);
            this.runButton.MaximumSize = new System.Drawing.Size(80, 25);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(80, 23);
            this.runButton.TabIndex = 0;
            this.runButton.TabStop = false;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // cBox_Vlan
            // 
            this.cBox_Vlan.AutoSize = true;
            this.cBox_Vlan.Checked = true;
            this.cBox_Vlan.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBox_Vlan.Location = new System.Drawing.Point(202, 40);
            this.cBox_Vlan.Name = "cBox_Vlan";
            this.cBox_Vlan.Size = new System.Drawing.Size(73, 17);
            this.cBox_Vlan.TabIndex = 3;
            this.cBox_Vlan.TabStop = false;
            this.cBox_Vlan.Text = "Use VLan";
            this.cBox_Vlan.UseVisualStyleBackColor = true;
            this.cBox_Vlan.CheckedChanged += new System.EventHandler(this.CBox_Vlan_CheckedChanged);
            // 
            // cBox_Sim
            // 
            this.cBox_Sim.AutoSize = true;
            this.cBox_Sim.Location = new System.Drawing.Point(202, 12);
            this.cBox_Sim.Name = "cBox_Sim";
            this.cBox_Sim.Size = new System.Drawing.Size(72, 17);
            this.cBox_Sim.TabIndex = 4;
            this.cBox_Sim.TabStop = false;
            this.cBox_Sim.Text = "Simulated";
            this.cBox_Sim.UseVisualStyleBackColor = true;
            this.cBox_Sim.CheckedChanged += new System.EventHandler(this.CBox_Sim_CheckedChanged);
            // 
            // tBox_SvID
            // 
            this.tBox_SvID.Location = new System.Drawing.Point(110, 150);
            this.tBox_SvID.MaxLength = 35;
            this.tBox_SvID.Name = "tBox_SvID";
            this.tBox_SvID.Size = new System.Drawing.Size(160, 20);
            this.tBox_SvID.TabIndex = 5;
            this.tBox_SvID.TabStop = false;
            this.tBox_SvID.Text = "GENERATOR_SV";
            this.tBox_SvID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBox_SvID.Validated += new System.EventHandler(this.TBox_SvID_Validated);
            // 
            // tBox_DstMAC
            // 
            this.tBox_DstMAC.Location = new System.Drawing.Point(110, 10);
            this.tBox_DstMAC.MaxLength = 5;
            this.tBox_DstMAC.Name = "tBox_DstMAC";
            this.tBox_DstMAC.Size = new System.Drawing.Size(80, 20);
            this.tBox_DstMAC.TabIndex = 7;
            this.tBox_DstMAC.TabStop = false;
            this.tBox_DstMAC.Text = "00-01";
            this.tBox_DstMAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBox_DstMAC.Validated += new System.EventHandler(this.TBox_DstMAC_Validated);
            // 
            // label_dstMac
            // 
            this.label_dstMac.Location = new System.Drawing.Point(20, 8);
            this.label_dstMac.Name = "label_dstMac";
            this.label_dstMac.Size = new System.Drawing.Size(90, 20);
            this.label_dstMac.TabIndex = 8;
            this.label_dstMac.Text = "DstMAC ( hex ) :";
            this.label_dstMac.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_VlanID
            // 
            this.label_VlanID.Location = new System.Drawing.Point(20, 36);
            this.label_VlanID.Name = "label_VlanID";
            this.label_VlanID.Size = new System.Drawing.Size(90, 20);
            this.label_VlanID.TabIndex = 9;
            this.label_VlanID.Text = "VlanID ( hex ) :";
            this.label_VlanID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tBox_VlanID
            // 
            this.tBox_VlanID.Location = new System.Drawing.Point(110, 38);
            this.tBox_VlanID.MaxLength = 5;
            this.tBox_VlanID.Name = "tBox_VlanID";
            this.tBox_VlanID.Size = new System.Drawing.Size(80, 20);
            this.tBox_VlanID.TabIndex = 10;
            this.tBox_VlanID.TabStop = false;
            this.tBox_VlanID.Text = "005";
            this.tBox_VlanID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBox_VlanID.Validated += new System.EventHandler(this.TBox_VlanID_Validated);
            // 
            // label_AppID
            // 
            this.label_AppID.Location = new System.Drawing.Point(20, 64);
            this.label_AppID.Name = "label_AppID";
            this.label_AppID.Size = new System.Drawing.Size(90, 20);
            this.label_AppID.TabIndex = 11;
            this.label_AppID.Text = "AppID ( hex ) :";
            this.label_AppID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tBox_AppID
            // 
            this.tBox_AppID.Location = new System.Drawing.Point(110, 66);
            this.tBox_AppID.MaxLength = 6;
            this.tBox_AppID.Name = "tBox_AppID";
            this.tBox_AppID.Size = new System.Drawing.Size(80, 20);
            this.tBox_AppID.TabIndex = 12;
            this.tBox_AppID.TabStop = false;
            this.tBox_AppID.Text = "4000";
            this.tBox_AppID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBox_AppID.Validated += new System.EventHandler(this.TBox_AppID_Validated);
            // 
            // label_ConfRev
            // 
            this.label_ConfRev.Location = new System.Drawing.Point(20, 92);
            this.label_ConfRev.Name = "label_ConfRev";
            this.label_ConfRev.Size = new System.Drawing.Size(90, 20);
            this.label_ConfRev.TabIndex = 13;
            this.label_ConfRev.Text = "ConfRev ( dec ) :";
            this.label_ConfRev.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tBox_ConfRev
            // 
            this.tBox_ConfRev.Location = new System.Drawing.Point(110, 94);
            this.tBox_ConfRev.MaxLength = 9;
            this.tBox_ConfRev.Name = "tBox_ConfRev";
            this.tBox_ConfRev.Size = new System.Drawing.Size(80, 20);
            this.tBox_ConfRev.TabIndex = 14;
            this.tBox_ConfRev.TabStop = false;
            this.tBox_ConfRev.Text = "1000";
            this.tBox_ConfRev.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBox_ConfRev.Validated += new System.EventHandler(this.TBox_ConfRev_Validated);
            // 
            // label_SmpSynch
            // 
            this.label_SmpSynch.Location = new System.Drawing.Point(10, 120);
            this.label_SmpSynch.Name = "label_SmpSynch";
            this.label_SmpSynch.Size = new System.Drawing.Size(100, 20);
            this.label_SmpSynch.TabIndex = 15;
            this.label_SmpSynch.Text = "SmpSynch ( dec ) :";
            this.label_SmpSynch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tBox_SmpSynch
            // 
            this.tBox_SmpSynch.Location = new System.Drawing.Point(110, 122);
            this.tBox_SmpSynch.MaxLength = 3;
            this.tBox_SmpSynch.Name = "tBox_SmpSynch";
            this.tBox_SmpSynch.Size = new System.Drawing.Size(80, 20);
            this.tBox_SmpSynch.TabIndex = 16;
            this.tBox_SmpSynch.TabStop = false;
            this.tBox_SmpSynch.Text = "2 - global";
            this.tBox_SmpSynch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBox_SmpSynch.Validated += new System.EventHandler(this.TBox_SmpSynch_Validated);
            // 
            // dummyLabel
            // 
            this.dummyLabel.AutoSize = true;
            this.dummyLabel.Location = new System.Drawing.Point(12, 10);
            this.dummyLabel.Name = "dummyLabel";
            this.dummyLabel.Size = new System.Drawing.Size(0, 13);
            this.dummyLabel.TabIndex = 17;
            // 
            // label_SvID
            // 
            this.label_SvID.Location = new System.Drawing.Point(20, 148);
            this.label_SvID.Name = "label_SvID";
            this.label_SvID.Size = new System.Drawing.Size(90, 20);
            this.label_SvID.TabIndex = 18;
            this.label_SvID.Text = "svID :";
            this.label_SvID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmBox_Device
            // 
            this.cmBox_Device.FormattingEnabled = true;
            this.cmBox_Device.Location = new System.Drawing.Point(110, 178);
            this.cmBox_Device.Name = "cmBox_Device";
            this.cmBox_Device.Size = new System.Drawing.Size(160, 21);
            this.cmBox_Device.TabIndex = 19;
            this.cmBox_Device.TabStop = false;
            this.cmBox_Device.SelectedIndexChanged += new System.EventHandler(this.CMBox_Device_SelectedIndexChanged);
            // 
            // label_Interface
            // 
            this.label_Interface.Location = new System.Drawing.Point(20, 176);
            this.label_Interface.Name = "label_Interface";
            this.label_Interface.Size = new System.Drawing.Size(90, 20);
            this.label_Interface.TabIndex = 20;
            this.label_Interface.Text = "Interface :";
            this.label_Interface.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tBox_I1
            // 
            this.tBox_I1.Location = new System.Drawing.Point(440, 38);
            this.tBox_I1.MaxLength = 10;
            this.tBox_I1.Name = "tBox_I1";
            this.tBox_I1.Size = new System.Drawing.Size(80, 20);
            this.tBox_I1.TabIndex = 21;
            this.tBox_I1.TabStop = false;
            this.tBox_I1.Tag = "I1m";
            this.tBox_I1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tBox_I2
            // 
            this.tBox_I2.Location = new System.Drawing.Point(440, 66);
            this.tBox_I2.MaxLength = 10;
            this.tBox_I2.Name = "tBox_I2";
            this.tBox_I2.Size = new System.Drawing.Size(80, 20);
            this.tBox_I2.TabIndex = 22;
            this.tBox_I2.TabStop = false;
            this.tBox_I2.Tag = "I2m";
            this.tBox_I2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tBox_I3
            // 
            this.tBox_I3.Location = new System.Drawing.Point(440, 94);
            this.tBox_I3.MaxLength = 10;
            this.tBox_I3.Name = "tBox_I3";
            this.tBox_I3.Size = new System.Drawing.Size(80, 20);
            this.tBox_I3.TabIndex = 23;
            this.tBox_I3.TabStop = false;
            this.tBox_I3.Tag = "I3m";
            this.tBox_I3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tBox_I4
            // 
            this.tBox_I4.Location = new System.Drawing.Point(440, 122);
            this.tBox_I4.MaxLength = 10;
            this.tBox_I4.Name = "tBox_I4";
            this.tBox_I4.Size = new System.Drawing.Size(80, 20);
            this.tBox_I4.TabIndex = 24;
            this.tBox_I4.TabStop = false;
            this.tBox_I4.Tag = "I4m";
            this.tBox_I4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tBox_I1a
            // 
            this.tBox_I1a.Location = new System.Drawing.Point(530, 38);
            this.tBox_I1a.MaxLength = 4;
            this.tBox_I1a.Name = "tBox_I1a";
            this.tBox_I1a.Size = new System.Drawing.Size(80, 20);
            this.tBox_I1a.TabIndex = 25;
            this.tBox_I1a.TabStop = false;
            this.tBox_I1a.Tag = "I1a";
            this.tBox_I1a.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tBox_I2a
            // 
            this.tBox_I2a.Location = new System.Drawing.Point(530, 66);
            this.tBox_I2a.MaxLength = 4;
            this.tBox_I2a.Name = "tBox_I2a";
            this.tBox_I2a.Size = new System.Drawing.Size(80, 20);
            this.tBox_I2a.TabIndex = 26;
            this.tBox_I2a.TabStop = false;
            this.tBox_I2a.Tag = "I2a";
            this.tBox_I2a.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tBox_I3a
            // 
            this.tBox_I3a.Location = new System.Drawing.Point(530, 94);
            this.tBox_I3a.MaxLength = 4;
            this.tBox_I3a.Name = "tBox_I3a";
            this.tBox_I3a.Size = new System.Drawing.Size(80, 20);
            this.tBox_I3a.TabIndex = 27;
            this.tBox_I3a.TabStop = false;
            this.tBox_I3a.Tag = "I3a";
            this.tBox_I3a.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tBox_I4a
            // 
            this.tBox_I4a.Location = new System.Drawing.Point(530, 122);
            this.tBox_I4a.MaxLength = 4;
            this.tBox_I4a.Name = "tBox_I4a";
            this.tBox_I4a.Size = new System.Drawing.Size(80, 20);
            this.tBox_I4a.TabIndex = 28;
            this.tBox_I4a.TabStop = false;
            this.tBox_I4a.Tag = "I4a";
            this.tBox_I4a.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tBox_kI
            // 
            this.tBox_kI.Location = new System.Drawing.Point(128, 322);
            this.tBox_kI.MaxLength = 10;
            this.tBox_kI.Name = "tBox_kI";
            this.tBox_kI.Size = new System.Drawing.Size(80, 20);
            this.tBox_kI.TabIndex = 29;
            this.tBox_kI.TabStop = false;
            this.tBox_kI.Text = "1000";
            this.tBox_kI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_kI
            // 
            this.label_kI.Location = new System.Drawing.Point(73, 322);
            this.label_kI.Name = "label_kI";
            this.label_kI.Size = new System.Drawing.Size(50, 20);
            this.label_kI.TabIndex = 30;
            this.label_kI.Text = "kI";
            this.label_kI.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tBox_kU
            // 
            this.tBox_kU.Location = new System.Drawing.Point(128, 348);
            this.tBox_kU.MaxLength = 10;
            this.tBox_kU.Name = "tBox_kU";
            this.tBox_kU.Size = new System.Drawing.Size(80, 20);
            this.tBox_kU.TabIndex = 31;
            this.tBox_kU.TabStop = false;
            this.tBox_kU.Text = "100";
            this.tBox_kU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_kU
            // 
            this.label_kU.Location = new System.Drawing.Point(73, 348);
            this.label_kU.Name = "label_kU";
            this.label_kU.Size = new System.Drawing.Size(50, 20);
            this.label_kU.TabIndex = 32;
            this.label_kU.Text = "kU";
            this.label_kU.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_I1
            // 
            this.label_I1.Location = new System.Drawing.Point(385, 37);
            this.label_I1.Name = "label_I1";
            this.label_I1.Size = new System.Drawing.Size(50, 20);
            this.label_I1.TabIndex = 33;
            this.label_I1.Text = "Ia";
            this.label_I1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_I2
            // 
            this.label_I2.Location = new System.Drawing.Point(385, 65);
            this.label_I2.Name = "label_I2";
            this.label_I2.Size = new System.Drawing.Size(50, 20);
            this.label_I2.TabIndex = 34;
            this.label_I2.Text = "Ib";
            this.label_I2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_I3
            // 
            this.label_I3.Location = new System.Drawing.Point(385, 93);
            this.label_I3.Name = "label_I3";
            this.label_I3.Size = new System.Drawing.Size(50, 20);
            this.label_I3.TabIndex = 35;
            this.label_I3.Text = "Ic";
            this.label_I3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_I4
            // 
            this.label_I4.Location = new System.Drawing.Point(385, 121);
            this.label_I4.Name = "label_I4";
            this.label_I4.Size = new System.Drawing.Size(50, 20);
            this.label_I4.TabIndex = 36;
            this.label_I4.Text = "In";
            this.label_I4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Mag
            // 
            this.label_Mag.Location = new System.Drawing.Point(440, 12);
            this.label_Mag.Name = "label_Mag";
            this.label_Mag.Size = new System.Drawing.Size(80, 20);
            this.label_Mag.TabIndex = 37;
            this.label_Mag.Text = "Mag";
            this.label_Mag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Ang
            // 
            this.label_Ang.Location = new System.Drawing.Point(530, 12);
            this.label_Ang.Name = "label_Ang";
            this.label_Ang.Size = new System.Drawing.Size(80, 20);
            this.label_Ang.TabIndex = 38;
            this.label_Ang.Text = "Angle";
            this.label_Ang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rButton_Mode1
            // 
            this.rButton_Mode1.AutoSize = true;
            this.rButton_Mode1.Checked = true;
            this.rButton_Mode1.Location = new System.Drawing.Point(221, 323);
            this.rButton_Mode1.Name = "rButton_Mode1";
            this.rButton_Mode1.Size = new System.Drawing.Size(60, 17);
            this.rButton_Mode1.TabIndex = 39;
            this.rButton_Mode1.TabStop = true;
            this.rButton_Mode1.Text = "Phases";
            this.rButton_Mode1.UseVisualStyleBackColor = true;
            this.rButton_Mode1.CheckedChanged += new System.EventHandler(this.ChangeDataViewMode);
            // 
            // rButton_Mode2
            // 
            this.rButton_Mode2.AutoSize = true;
            this.rButton_Mode2.Location = new System.Drawing.Point(221, 349);
            this.rButton_Mode2.Name = "rButton_Mode2";
            this.rButton_Mode2.Size = new System.Drawing.Size(79, 17);
            this.rButton_Mode2.TabIndex = 40;
            this.rButton_Mode2.Text = "Sequences";
            this.rButton_Mode2.UseVisualStyleBackColor = true;
            // 
            // tBox_U1
            // 
            this.tBox_U1.Location = new System.Drawing.Point(440, 178);
            this.tBox_U1.MaxLength = 10;
            this.tBox_U1.Name = "tBox_U1";
            this.tBox_U1.Size = new System.Drawing.Size(80, 20);
            this.tBox_U1.TabIndex = 41;
            this.tBox_U1.TabStop = false;
            this.tBox_U1.Tag = "U1m";
            this.tBox_U1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tBox_U2
            // 
            this.tBox_U2.Location = new System.Drawing.Point(440, 206);
            this.tBox_U2.MaxLength = 10;
            this.tBox_U2.Name = "tBox_U2";
            this.tBox_U2.Size = new System.Drawing.Size(80, 20);
            this.tBox_U2.TabIndex = 42;
            this.tBox_U2.TabStop = false;
            this.tBox_U2.Tag = "U2m";
            this.tBox_U2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tBox_U3
            // 
            this.tBox_U3.Location = new System.Drawing.Point(440, 234);
            this.tBox_U3.MaxLength = 10;
            this.tBox_U3.Name = "tBox_U3";
            this.tBox_U3.Size = new System.Drawing.Size(80, 20);
            this.tBox_U3.TabIndex = 43;
            this.tBox_U3.TabStop = false;
            this.tBox_U3.Tag = "U3m";
            this.tBox_U3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tBox_U4
            // 
            this.tBox_U4.Location = new System.Drawing.Point(440, 262);
            this.tBox_U4.MaxLength = 10;
            this.tBox_U4.Name = "tBox_U4";
            this.tBox_U4.Size = new System.Drawing.Size(80, 20);
            this.tBox_U4.TabIndex = 44;
            this.tBox_U4.TabStop = false;
            this.tBox_U4.Tag = "U4m";
            this.tBox_U4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tBox_U1a
            // 
            this.tBox_U1a.Location = new System.Drawing.Point(530, 178);
            this.tBox_U1a.MaxLength = 4;
            this.tBox_U1a.Name = "tBox_U1a";
            this.tBox_U1a.Size = new System.Drawing.Size(80, 20);
            this.tBox_U1a.TabIndex = 45;
            this.tBox_U1a.TabStop = false;
            this.tBox_U1a.Tag = "U1a";
            this.tBox_U1a.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tBox_U2a
            // 
            this.tBox_U2a.Location = new System.Drawing.Point(530, 206);
            this.tBox_U2a.MaxLength = 4;
            this.tBox_U2a.Name = "tBox_U2a";
            this.tBox_U2a.Size = new System.Drawing.Size(80, 20);
            this.tBox_U2a.TabIndex = 46;
            this.tBox_U2a.TabStop = false;
            this.tBox_U2a.Tag = "U2a";
            this.tBox_U2a.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tBox_U3a
            // 
            this.tBox_U3a.Location = new System.Drawing.Point(530, 234);
            this.tBox_U3a.MaxLength = 4;
            this.tBox_U3a.Name = "tBox_U3a";
            this.tBox_U3a.Size = new System.Drawing.Size(80, 20);
            this.tBox_U3a.TabIndex = 47;
            this.tBox_U3a.TabStop = false;
            this.tBox_U3a.Tag = "U3a";
            this.tBox_U3a.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tBox_U4a
            // 
            this.tBox_U4a.Location = new System.Drawing.Point(530, 262);
            this.tBox_U4a.MaxLength = 4;
            this.tBox_U4a.Name = "tBox_U4a";
            this.tBox_U4a.Size = new System.Drawing.Size(80, 20);
            this.tBox_U4a.TabIndex = 48;
            this.tBox_U4a.TabStop = false;
            this.tBox_U4a.Tag = "U4a";
            this.tBox_U4a.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_U1
            // 
            this.label_U1.Location = new System.Drawing.Point(385, 177);
            this.label_U1.Name = "label_U1";
            this.label_U1.Size = new System.Drawing.Size(50, 20);
            this.label_U1.TabIndex = 49;
            this.label_U1.Text = "Ua";
            this.label_U1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_U2
            // 
            this.label_U2.Location = new System.Drawing.Point(385, 205);
            this.label_U2.Name = "label_U2";
            this.label_U2.Size = new System.Drawing.Size(50, 20);
            this.label_U2.TabIndex = 50;
            this.label_U2.Text = "Ub";
            this.label_U2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_U3
            // 
            this.label_U3.Location = new System.Drawing.Point(385, 233);
            this.label_U3.Name = "label_U3";
            this.label_U3.Size = new System.Drawing.Size(50, 20);
            this.label_U3.TabIndex = 51;
            this.label_U3.Text = "Uc";
            this.label_U3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_U4
            // 
            this.label_U4.Location = new System.Drawing.Point(385, 261);
            this.label_U4.Name = "label_U4";
            this.label_U4.Size = new System.Drawing.Size(50, 20);
            this.label_U4.TabIndex = 52;
            this.label_U4.Text = "Un";
            this.label_U4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.label_U4);
            this.Controls.Add(this.label_U3);
            this.Controls.Add(this.label_U2);
            this.Controls.Add(this.label_U1);
            this.Controls.Add(this.tBox_U4a);
            this.Controls.Add(this.tBox_U3a);
            this.Controls.Add(this.tBox_U2a);
            this.Controls.Add(this.tBox_U1a);
            this.Controls.Add(this.tBox_U4);
            this.Controls.Add(this.tBox_U3);
            this.Controls.Add(this.tBox_U2);
            this.Controls.Add(this.tBox_U1);
            this.Controls.Add(this.rButton_Mode2);
            this.Controls.Add(this.rButton_Mode1);
            this.Controls.Add(this.label_Ang);
            this.Controls.Add(this.label_Mag);
            this.Controls.Add(this.label_I4);
            this.Controls.Add(this.label_I3);
            this.Controls.Add(this.label_I2);
            this.Controls.Add(this.label_I1);
            this.Controls.Add(this.label_kU);
            this.Controls.Add(this.tBox_kU);
            this.Controls.Add(this.label_kI);
            this.Controls.Add(this.tBox_kI);
            this.Controls.Add(this.tBox_I4a);
            this.Controls.Add(this.tBox_I3a);
            this.Controls.Add(this.tBox_I2a);
            this.Controls.Add(this.tBox_I1a);
            this.Controls.Add(this.tBox_I4);
            this.Controls.Add(this.tBox_I3);
            this.Controls.Add(this.tBox_I2);
            this.Controls.Add(this.tBox_I1);
            this.Controls.Add(this.label_Interface);
            this.Controls.Add(this.cmBox_Device);
            this.Controls.Add(this.label_SvID);
            this.Controls.Add(this.dummyLabel);
            this.Controls.Add(this.tBox_SmpSynch);
            this.Controls.Add(this.label_SmpSynch);
            this.Controls.Add(this.tBox_ConfRev);
            this.Controls.Add(this.label_ConfRev);
            this.Controls.Add(this.tBox_AppID);
            this.Controls.Add(this.label_AppID);
            this.Controls.Add(this.tBox_VlanID);
            this.Controls.Add(this.label_VlanID);
            this.Controls.Add(this.label_dstMac);
            this.Controls.Add(this.tBox_DstMAC);
            this.Controls.Add(this.tBox_SvID);
            this.Controls.Add(this.cBox_Sim);
            this.Controls.Add(this.cBox_Vlan);
            this.Controls.Add(this.runButton);
            this.MinimumSize = new System.Drawing.Size(800, 499);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generator SV";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.CheckBox cBox_Vlan;
        private System.Windows.Forms.CheckBox cBox_Sim;
        private System.Windows.Forms.TextBox tBox_SvID;
        private System.Windows.Forms.TextBox tBox_DstMAC;
        private System.Windows.Forms.Label label_dstMac;
        private System.Windows.Forms.Label label_VlanID;
        private System.Windows.Forms.TextBox tBox_VlanID;
        private System.Windows.Forms.Label label_AppID;
        private System.Windows.Forms.TextBox tBox_AppID;
        private System.Windows.Forms.Label label_ConfRev;
        private System.Windows.Forms.TextBox tBox_ConfRev;
        private System.Windows.Forms.Label label_SmpSynch;
        private System.Windows.Forms.TextBox tBox_SmpSynch;
        private System.Windows.Forms.Label dummyLabel;
        private System.Windows.Forms.Label label_SvID;
        private System.Windows.Forms.ComboBox cmBox_Device;
        private System.Windows.Forms.Label label_Interface;
        private System.Windows.Forms.TextBox tBox_I1;
        private System.Windows.Forms.TextBox tBox_I2;
        private System.Windows.Forms.TextBox tBox_I3;
        private System.Windows.Forms.TextBox tBox_I4;
        private System.Windows.Forms.TextBox tBox_I1a;
        private System.Windows.Forms.TextBox tBox_I2a;
        private System.Windows.Forms.TextBox tBox_I3a;
        private System.Windows.Forms.TextBox tBox_I4a;
        private System.Windows.Forms.TextBox tBox_kI;
        private System.Windows.Forms.Label label_kI;
        private System.Windows.Forms.TextBox tBox_kU;
        private System.Windows.Forms.Label label_kU;
        private System.Windows.Forms.Label label_I1;
        private System.Windows.Forms.Label label_I2;
        private System.Windows.Forms.Label label_I3;
        private System.Windows.Forms.Label label_I4;
        private System.Windows.Forms.Label label_Mag;
        private System.Windows.Forms.Label label_Ang;
        private System.Windows.Forms.RadioButton rButton_Mode1;
        private System.Windows.Forms.RadioButton rButton_Mode2;
        private System.Windows.Forms.TextBox tBox_U1;
        private System.Windows.Forms.TextBox tBox_U2;
        private System.Windows.Forms.TextBox tBox_U3;
        private System.Windows.Forms.TextBox tBox_U4;
        private System.Windows.Forms.TextBox tBox_U1a;
        private System.Windows.Forms.TextBox tBox_U2a;
        private System.Windows.Forms.TextBox tBox_U3a;
        private System.Windows.Forms.TextBox tBox_U4a;
        private System.Windows.Forms.Label label_U1;
        private System.Windows.Forms.Label label_U2;
        private System.Windows.Forms.Label label_U3;
        private System.Windows.Forms.Label label_U4;
    }
}