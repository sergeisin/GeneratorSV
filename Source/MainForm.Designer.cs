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
            this.testField = new System.Windows.Forms.NumericUpDown();
            this.tBox_DstMAC = new System.Windows.Forms.TextBox();
            this.label_dstMac = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.testField)).BeginInit();
            this.SuspendLayout();
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(281, 203);
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
            this.vlanBox.Location = new System.Drawing.Point(281, 131);
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
            this.simBox.Location = new System.Drawing.Point(281, 154);
            this.simBox.Name = "simBox";
            this.simBox.Size = new System.Drawing.Size(72, 17);
            this.simBox.TabIndex = 4;
            this.simBox.Text = "Simulated";
            this.simBox.UseVisualStyleBackColor = true;
            this.simBox.CheckedChanged += new System.EventHandler(this.SimBox_CheckedChanged);
            // 
            // tBox_SvID
            // 
            this.tBox_SvID.Location = new System.Drawing.Point(110, 191);
            this.tBox_SvID.MaxLength = 35;
            this.tBox_SvID.Name = "tBox_SvID";
            this.tBox_SvID.Size = new System.Drawing.Size(150, 20);
            this.tBox_SvID.TabIndex = 5;
            this.tBox_SvID.Text = "GENERATOR_SV";
            this.tBox_SvID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBox_SvID.Validated += new System.EventHandler(this.tBox_SvID_Validated);
            // 
            // testField
            // 
            this.testField.Hexadecimal = true;
            this.testField.Location = new System.Drawing.Point(110, 154);
            this.testField.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.testField.Minimum = new decimal(new int[] {
            16384,
            0,
            0,
            0});
            this.testField.Name = "testField";
            this.testField.Size = new System.Drawing.Size(120, 20);
            this.testField.TabIndex = 6;
            this.testField.Tag = "";
            this.testField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.testField.Value = new decimal(new int[] {
            16384,
            0,
            0,
            0});
            this.testField.Validated += new System.EventHandler(this.testField_Validated);
            // 
            // tBox_DstMAC
            // 
            this.tBox_DstMAC.Location = new System.Drawing.Point(67, 6);
            this.tBox_DstMAC.MaxLength = 5;
            this.tBox_DstMAC.Name = "tBox_DstMAC";
            this.tBox_DstMAC.Size = new System.Drawing.Size(80, 20);
            this.tBox_DstMAC.TabIndex = 7;
            this.tBox_DstMAC.Text = "00-01";
            this.tBox_DstMAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBox_DstMAC.Validated += new System.EventHandler(this.tBox_DstMAC_Validated);
            // 
            // label_dstMac
            // 
            this.label_dstMac.AutoSize = true;
            this.label_dstMac.Location = new System.Drawing.Point(12, 9);
            this.label_dstMac.Name = "label_dstMac";
            this.label_dstMac.Size = new System.Drawing.Size(52, 13);
            this.label_dstMac.TabIndex = 8;
            this.label_dstMac.Text = "DstMAC :";
            this.label_dstMac.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.label_dstMac);
            this.Controls.Add(this.tBox_DstMAC);
            this.Controls.Add(this.testField);
            this.Controls.Add(this.tBox_SvID);
            this.Controls.Add(this.simBox);
            this.Controls.Add(this.vlanBox);
            this.Controls.Add(this.runButton);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generator SV";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Click += new System.EventHandler(this.MainForm_Click);
            ((System.ComponentModel.ISupportInitialize)(this.testField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.CheckBox vlanBox;
        private System.Windows.Forms.CheckBox simBox;
        private System.Windows.Forms.TextBox tBox_SvID;
        private System.Windows.Forms.NumericUpDown testField;
        private System.Windows.Forms.TextBox tBox_DstMAC;
        private System.Windows.Forms.Label label_dstMac;
    }
}