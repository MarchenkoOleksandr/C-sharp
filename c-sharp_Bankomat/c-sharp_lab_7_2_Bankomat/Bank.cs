using System;
using classClient;
using static System.Console;

namespace classBank
{
    abstract class Bank
    {
        public static int totalClients = 0;
        public static Client[] client = new Client[1000];

        protected Bank()
        {
            if (totalClients < 1000)
                totalClients++;
            else
            {
                ForegroundColor = ConsoleColor.DarkRed;
                WriteLine("\nКлієнта не було додано. Недостатньо місця!");
                ResetColor();
            }
        }

        public override string ToString()
        {
            return $"Номер рахунка: {totalClients.ToString("D5")}";
        }
    }
}
