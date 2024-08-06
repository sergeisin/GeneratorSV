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
            this.textBox_SvID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(12, 12);
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
            this.vlanBox.Location = new System.Drawing.Point(12, 50);
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
            this.simBox.Location = new System.Drawing.Point(12, 73);
            this.simBox.Name = "simBox";
            this.simBox.Size = new System.Drawing.Size(72, 17);
            this.simBox.TabIndex = 4;
            this.simBox.Text = "Simulated";
            this.simBox.UseVisualStyleBackColor = true;
            this.simBox.CheckedChanged += new System.EventHandler(this.SimBox_CheckedChanged);
            // 
            // textBox_SvID
            // 
            this.textBox_SvID.Location = new System.Drawing.Point(12, 96);
            this.textBox_SvID.MaxLength = 35;
            this.textBox_SvID.Name = "textBox_SvID";
            this.textBox_SvID.Size = new System.Drawing.Size(150, 20);
            this.textBox_SvID.TabIndex = 5;
            this.textBox_SvID.Text = "GENERATOR_SV";
            this.textBox_SvID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_SvID.Validated += new System.EventHandler(this.TextBox_SvID_Validated);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.textBox_SvID);
            this.Controls.Add(this.simBox);
            this.Controls.Add(this.vlanBox);
            this.Controls.Add(this.runButton);
            this.MinimumSize = new System.Drawing.Size(400, 300);
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
        private System.Windows.Forms.TextBox textBox_SvID;
    }
}