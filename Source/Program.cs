using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace GeneratorSV
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
