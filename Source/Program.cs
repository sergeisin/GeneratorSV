using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GeneratorSV
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }

            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
