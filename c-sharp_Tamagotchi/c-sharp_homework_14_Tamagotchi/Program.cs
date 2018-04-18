using System;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using static System.Console;

namespace Tamagotchi
{
    class Program
    {
        public static System.Timers.Timer timer = new System.Timers.Timer { Interval = 2000 };
        public static System.Timers.Timer totalTime = new System.Timers.Timer { Interval = 60000 };

        static void Main(string[] args)
        {
            OutputEncoding = Encoding.Unicode;
            InputEncoding = Encoding.Unicode;
            Title = "Tamagotchi";

            WriteLine("Вітаємо! Ця програма імітує роботу Тамагочі!\n");
            
            Tamagotchi tamagotchi = new Tamagotchi();
            Action action = new Action(tamagotchi.NewAction());
            WriteLine("\nПривіт! Давай дружити!");
            tamagotchi.Show();
            timer.Start();
            totalTime.Start();
            timer.Elapsed += (sender, e) => OnTimer(action, e, tamagotchi);
            totalTime.Elapsed += (sender, e) => TotalTimer(tamagotchi, e);
            timer.AutoReset = true;
            totalTime.AutoReset = false;

            ReadKey(true);
        }

        public static void OnTimer(Action action, ElapsedEventArgs e, Tamagotchi tamagotchi)
        {
            action = new Action(tamagotchi.NewAction());
            timer.Stop();
            if (MessageBox.Show($"{action.Invoke()}", "Нове прохання", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                WriteLine("\nЯ засмучений!");
                tamagotchi.Failures++;
            }
            else
            {
                WriteLine("\nДякую!");
                if (tamagotchi.Failures > 0)
                    tamagotchi.Failures--;
            }

            if (tamagotchi.Failures == 3 && MessageBox.Show($"{tamagotchi.NeedTreatment()}", "Нове прохання", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                WriteLine("\n\nДякую!");
                tamagotchi.Failures = 0;
            }
            tamagotchi.Show();
            if (timer.AutoReset == true)
                timer.Start();

            if (tamagotchi.Failures == 3)
                End(tamagotchi.Failures);
        }

        public static void TotalTimer(Tamagotchi tamagotchi, ElapsedEventArgs e)
        {
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine("\nЧас гри закінчився!");
            ResetColor();
            timer.AutoReset = false;
            End(tamagotchi.Failures);
        }

        public static void End(int i)
        {
            if (i == 3)
            {
                ForegroundColor = ConsoleColor.DarkRed;
                WriteLine("\nЯ ображений! Прощавай!");
            }
            else
            {
                ForegroundColor = ConsoleColor.DarkGreen;
                WriteLine("\nМи стали справжніми друзями!");
            }
            ResetColor();
            timer.Stop();
        }
    }
}