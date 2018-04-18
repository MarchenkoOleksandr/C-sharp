using System;
using static System.Console;

namespace Tamagotchi
{
    public delegate string Action();

    class Tamagotchi
    {
        int choise = new Random().Next(0, 4);
        public int Failures { get; set; } = 0;

        public string WantEat() { return "Хочу їсти! Погодуєш мене?"; }

        public string WantWalk() { return "Хочу гуляти! Вигуляєш мене?"; }

        public string WantSleep() { return "Хочу спати! Вкладеш мене спати?"; }

        public string NeedTreatment() { return "Я хворію! Полікуєш мене?"; }

        public string WantPlay() { return "Хочу грати! Пограєш зі мною?"; }

        public Action NewAction()
        {
            switch ((choise++) % 5)
            {
                case 0:
                    return WantEat;
                case 1:
                    return WantWalk;
                case 2:
                    return WantSleep;
                case 3:
                    return NeedTreatment;
                default:
                    return WantPlay;
            }
        }

        public void Show()
        {
            switch (Failures)
            {
                case 0:
                    ForegroundColor = ConsoleColor.DarkGreen;
                    WriteLine("\n  ___\n /. .\\\n|  _  |\n \\___/\n /   \\\n");
                    ResetColor();
                    break;
                case 1:
                    ForegroundColor = ConsoleColor.DarkYellow;
                    WriteLine("\n  ___\n /. .\\\n|  o  |\n \\___/\n /   \\\n");
                    ResetColor();
                    break;
                default:
                    ForegroundColor = ConsoleColor.DarkRed;
                    WriteLine("\n  ___\n /. .\\\n|  ~  |\n \\___/\n /   \\\n");
                    ResetColor();
                    break;
            }
        }
    }
}