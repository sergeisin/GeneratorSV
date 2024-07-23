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
            this.testButton = new System.Windows.Forms.Button();
            this.lable = new System.Windows.Forms.Label();
            this.vlanBox = new System.Windows.Forms.CheckBox();
            this.simBox = new System.Windows.Forms.CheckBox();
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
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(12, 43);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(80, 25);
            this.testButton.TabIndex = 1;
            this.testButton.Text = "Run Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // lable
            // 
            this.lable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lable.Location = new System.Drawing.Point(0, 236);
            this.lable.Margin = new System.Windows.Forms.Padding(1);
            this.lable.Name = "lable";
            this.lable.Padding = new System.Windows.Forms.Padding(5);
            this.lable.Size = new System.Drawing.Size(384, 25);
            this.lable.TabIndex = 2;
            this.lable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // vlanBox
            // 
            this.vlanBox.AutoSize = true;
            this.vlanBox.Location = new System.Drawing.Point(180, 19);
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
            this.simBox.Location = new System.Drawing.Point(180, 50);
            this.simBox.Name = "simBox";
            this.simBox.Size = new System.Drawing.Size(72, 17);
            this.simBox.TabIndex = 4;
            this.simBox.Text = "Simulated";
            this.simBox.UseVisualStyleBackColor = true;
            this.simBox.CheckedChanged += new System.EventHandler(this.SimBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.simBox);
            this.Controls.Add(this.vlanBox);
            this.Controls.Add(this.lable);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.runButton);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generator SV";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Label lable;
        private System.Windows.Forms.CheckBox vlanBox;
        private System.Windows.Forms.CheckBox simBox;
    }
}