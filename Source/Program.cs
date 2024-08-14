using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace GeneratorSV
{
    internal static class Program
    {
        /*   TO-DO
         * 
         *   1. Добавить два чекбокса для выбора зависимого/независимого режима управления In / Un
         *   2. Добавить элементы для ввода kI и kU
         *   3. Добавить возможность выбирать первичные или вторичные величины
         *   4. Добавить событие при прокрутке колёсиком мышки токов и напряжений
         *   5. Добавить ToolTip к основным элементам конфигурирования SvCB
         *   6. Поправить макет UI
         *   7. Добавить возможность диначического задания частоты 40 - 60 Гц
         *   8. Добавить возможность выбора формата SV 80-1 или 96-2
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
