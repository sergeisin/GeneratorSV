namespace GeneratorSV
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
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
            this.MinimumSize = new System.Drawing.Size(400, 300);
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
    }
}