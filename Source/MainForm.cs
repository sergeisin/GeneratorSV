using System;
using System.Windows.Forms;

namespace GeneratorSV
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click", "Action", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
