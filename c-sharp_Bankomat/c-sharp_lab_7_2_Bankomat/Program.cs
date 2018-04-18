using System;
using System.Text;
using classClient;
using static System.Console;

namespace bankomat
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputEncoding = Encoding.Unicode;
            InputEncoding = Encoding.Unicode;
            Title = "Bankomat";

            WriteLine("Вітаємо! Ця програма імітує роботу банкомата!\n");

            Client client = new Client();
            WriteLine(client);

            if (!client.GetPassword())
            {
                ReadKey();
                Environment.Exit(0);
            }

            char choice = ' ';
            do
            {
                ForegroundColor = ConsoleColor.DarkGreen;
                WriteLine("\n\nПерелік доступних дій:");
                WriteLine("1 - вивести баланс на екран");
                WriteLine("2 - поповнити рахунок");
                WriteLine("3 - зняти гроші з рахунку");
                WriteLine("0 - вихід");
                Write("\nОберіть дію: ");
                choice = ReadKey().KeyChar;
                ResetColor();
                switch (choice)
                {
                    case '1':
                        client.CurrentSum();
                        break;
                    case '2':
                        client.AddMoney();
                        break;
                    case '3':
                        client.GetMoney();
                        break;
                    case '0':
                        break;
                    default:
                        ForegroundColor = ConsoleColor.DarkRed;
                        WriteLine("\nВибір невірний! Спробуйте ще раз!");
                        ResetColor();
                        break;
                }
            } while (choice != '0');
        }
    }
}