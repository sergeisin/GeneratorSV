using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace GeneratorSV
{
    internal static class Program
    {
        /*   TO-DO
         * 
         *   1. Добавить ToolTip к основным элементам конфигурирования SvCB
         *   2. Добавить возможность выбора фломата SV 80-1 или 96-2
         *   3. Добавить возможность выбора типа управления генератором
         *   -- Независимые каналы
         *   -- Зависимый нулевой канал
         *   -- Только прямая последовательность
         *   4. Добавить перерасчёт из фазных составляющих в симметричные 
         *   5. Добавить элементы TextBox для ввода напряжений
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
