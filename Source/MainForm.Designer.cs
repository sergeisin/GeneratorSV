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
            this.vlanBox = new System.Windows.Forms.CheckBox();
            this.simBox = new System.Windows.Forms.CheckBox();
            this.tBox_SvID = new System.Windows.Forms.TextBox();
            this.tBox_DstMAC = new System.Windows.Forms.TextBox();
            this.label_dstMac = new System.Windows.Forms.Label();
            this.label_VlanID = new System.Windows.Forms.Label();
            this.tBox_VlanID = new System.Windows.Forms.TextBox();
            this.label_AppID = new System.Windows.Forms.Label();
            this.tBox_AppID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(373, 218);
            this.runButton.MaximumSize = new System.Drawing.Size(80, 25);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(80, 25);
            this.runButton.TabIndex = 0;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // vlanBox
            // 
            this.vlanBox.AutoSize = true;
            this.vlanBox.Location = new System.Drawing.Point(373, 195);
            this.vlanBox.Name = "vlanBox";
            this.vlanBox.Size = new System.Drawing.Size(73, 17);
            this.vlanBox.TabIndex = 3;
            this.vlanBox.Text = "Use VLan";
            this.vlanBox.UseVisualStyleBackColor = true;
            this.vlanBox.CheckedChanged += new System.EventHandler(this.VlanBox_CheckedChanged);
            // 
            // simBox
            // 
            this.simBox.AutoSize = true;
            this.simBox.Location = new System.Drawing.Point(373, 172);
            this.simBox.Name = "simBox";
            this.simBox.Size = new System.Drawing.Size(72, 17);
            this.simBox.TabIndex = 4;
            this.simBox.Text = "Simulated";
            this.simBox.UseVisualStyleBackColor = true;
            this.simBox.CheckedChanged += new System.EventHandler(this.SimBox_CheckedChanged);
            // 
            // tBox_SvID
            // 
            this.tBox_SvID.Location = new System.Drawing.Point(163, 304);
            this.tBox_SvID.MaxLength = 35;
            this.tBox_SvID.Name = "tBox_SvID";
            this.tBox_SvID.Size = new System.Drawing.Size(150, 20);
            this.tBox_SvID.TabIndex = 5;
            this.tBox_SvID.Text = "GENERATOR_SV";
            this.tBox_SvID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBox_SvID.Validated += new System.EventHandler(this.TBox_SvID_Validated);
            // 
            // tBox_DstMAC
            // 
            this.tBox_DstMAC.Location = new System.Drawing.Point(102, 6);
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
            this.label_dstMac.AutoSize = true;
            this.label_dstMac.Location = new System.Drawing.Point(12, 9);
            this.label_dstMac.Name = "label_dstMac";
            this.label_dstMac.Size = new System.Drawing.Size(84, 13);
            this.label_dstMac.TabIndex = 8;
            this.label_dstMac.Text = "DstMAC ( hex ) :";
            this.label_dstMac.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_VlanID
            // 
            this.label_VlanID.AutoSize = true;
            this.label_VlanID.Location = new System.Drawing.Point(19, 35);
            this.label_VlanID.Name = "label_VlanID";
            this.label_VlanID.Size = new System.Drawing.Size(77, 13);
            this.label_VlanID.TabIndex = 9;
            this.label_VlanID.Text = "VlanID ( hex ) :";
            this.label_VlanID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tBox_VlanID
            // 
            this.tBox_VlanID.Location = new System.Drawing.Point(102, 33);
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
            this.label_AppID.AutoSize = true;
            this.label_AppID.Location = new System.Drawing.Point(21, 63);
            this.label_AppID.Name = "label_AppID";
            this.label_AppID.Size = new System.Drawing.Size(75, 13);
            this.label_AppID.TabIndex = 11;
            this.label_AppID.Text = "AppID ( hex ) :";
            this.label_AppID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tBox_AppID
            // 
            this.tBox_AppID.Location = new System.Drawing.Point(102, 60);
            this.tBox_AppID.MaxLength = 6;
            this.tBox_AppID.Name = "tBox_AppID";
            this.tBox_AppID.Size = new System.Drawing.Size(80, 20);
            this.tBox_AppID.TabIndex = 12;
            this.tBox_AppID.Text = "4000";
            this.tBox_AppID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBox_AppID.Validated += new System.EventHandler(this.TBox_AppID_Validated);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.tBox_AppID);
            this.Controls.Add(this.label_AppID);
            this.Controls.Add(this.tBox_VlanID);
            this.Controls.Add(this.label_VlanID);
            this.Controls.Add(this.label_dstMac);
            this.Controls.Add(this.tBox_DstMAC);
            this.Controls.Add(this.tBox_SvID);
            this.Controls.Add(this.simBox);
            this.Controls.Add(this.vlanBox);
            this.Controls.Add(this.runButton);
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generator SV";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Click += new System.EventHandler(this.MainForm_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.CheckBox vlanBox;
        private System.Windows.Forms.CheckBox simBox;
        private System.Windows.Forms.TextBox tBox_SvID;
        private System.Windows.Forms.TextBox tBox_DstMAC;
        private System.Windows.Forms.Label label_dstMac;
        private System.Windows.Forms.Label label_VlanID;
        private System.Windows.Forms.TextBox tBox_VlanID;
        private System.Windows.Forms.Label label_AppID;
        private System.Windows.Forms.TextBox tBox_AppID;
    }
}