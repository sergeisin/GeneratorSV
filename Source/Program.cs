using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace GeneratorSV
{
    internal static class Program
    {
        /* ToDo
         * 
         * - Добавить формироване кадра в соответствии с КП ФСК 96/2
         * 
         * - Добавить валидацию поля DstMac - 0x0000 .. 0x01FF  
         * - Добавить валидацию поля vlanID - 0x0000 .. 0x0FFF
         * - Добавить валидацию поля appID  - 0x4000 .. 0x7FFF
         * - Добавить валидацию поля smpSynch - 0x00 .. 0xFF
         * 
         * - Проверить, что один значащий бит тока - 0.1 мА
         * - Проверить, что один значащий бит напряжения - 10 мВ
         * 
         */

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
