using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace GeneratorSV
{
    public partial class MainForm : Form
    {
        SVPublisher publisher;
        Stopwatch stopwatch;
        
        public MainForm()
        {
            InitializeComponent();
            
            stopwatch = new Stopwatch();
            publisher = new SVPublisher(interfaceName: "Ethernet 3", new SVConfig()
            {
                dstMac = "01-0c-cd-04-00-01",
                vlanID = "005",
                appID = 0x4000,
                svID = "GENERATOR_SV",
                confRev = 10000,
                smpSynch = 2,

                Ia_mag = 100,
                Ia_ang = 30,
                Ib_mag = 100,
                Ib_ang = 210,
                Ic_mag = 100,
                Ic_ang = 90,

                Ua_mag = 10000,
                Ua_ang = 0,
                Ub_mag = 10000,
                Ub_ang = 240,
                Uc_mag = 10000,
                Uc_ang = 120,
            });
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            stopwatch.Restart();

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

            stopwatch.Stop();
            lable.Text = $"Elapsed: {stopwatch.ElapsedMilliseconds} ms";
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            stopwatch.Restart();

            publisher.ConfigurationChg();

            stopwatch.Stop();
            lable.Text = $"Elapsed: {stopwatch.ElapsedMilliseconds} ms";
        }

        private void VlanBox_CheckedChanged(object sender, EventArgs e)
        {
            stopwatch.Restart();

            publisher.HasVlan = (sender as CheckBox).Checked;

            stopwatch.Stop();
            lable.Text = $"Elapsed: {stopwatch.ElapsedMilliseconds} ms";
        }

        private void SimBox_CheckedChanged(object sender, EventArgs e)
        {
            stopwatch.Restart();

            publisher.Simulated = (sender as CheckBox).Checked;
            
            stopwatch.Stop();
            lable.Text = $"Elapsed: {stopwatch.ElapsedMilliseconds} ms";
        }
    }
}
