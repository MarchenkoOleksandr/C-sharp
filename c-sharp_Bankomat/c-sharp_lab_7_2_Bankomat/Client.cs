using System;
using classBank;
using classAccount;
using static System.Console;

namespace classClient
{
    class Client : Bank
    {
        int id;
        string name;
        string surname;
        Account account;

        public Client()
        {
            id = totalClients;
            Write("\nВведіть Ваше ім\'я: ");
            name = ReadLine();
            Write("Введіть Ваше прізвище: ");
            surname = ReadLine();
            account = new Account();
        }

        public bool GetPassword()
        {
            if (!account.GetPassword())
            {
                ForegroundColor = ConsoleColor.DarkRed;
                WriteLine("\n\nПароль не прийнятий! Програма буде закрита\n");
                ResetColor();
                return false;
            }
            else
            {
                ForegroundColor = ConsoleColor.DarkGreen;
                WriteLine("\n\nПароль прийнятий!\n");
                ResetColor();
                return true;
            }
        }

        public void CurrentSum()
        {
            WriteLine($"\n\nСтан рахунку: { account.GetSum() } гривень");
        }

        public void AddMoney()
        {
            account.SetSum();
            CurrentSum();
        }

        public void GetMoney()
        {
            account.MinusMoney();
            CurrentSum();
        }

        public override string ToString()
        {
            return base.ToString() + $"\nПIБ клієнта: {surname} {name}\nНа рахунку: {account.GetSum()} гривень";
        }
    }
}
