using System;
using classBank;
using static System.Console;

namespace classAccount
{
    class Account
    {
        int accountId;
        byte[] password;
        double sum = 0.0;

        public Account() { CreateAccount(); }

        protected void CreateAccount()
        {
            char symbol;
            Write("\nВведіть новий пароль (4 цифри): ");
            password = new byte[4];
            for (int i = 0; i < password.Length; i++)
            {
                symbol = ReadKey().KeyChar;
                if (Char.IsDigit(symbol))
                {
                    password[i] = (byte)Char.GetNumericValue(symbol);
                    Write("\bX");
                }
                else
                {
                    Write("\bX");
                    ForegroundColor = ConsoleColor.DarkRed;
                    WriteLine("\n\nЦе не число! Спробуйте ще раз!\n");
                    ResetColor();
                    Write("\nВведіть новий пароль (4 цифри): ");
                    i = -1;
                }
            }
            Write("\nВведіть новий пароль ще раз (4 цифри): ");
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] == (byte)Char.GetNumericValue(ReadKey().KeyChar))
                    Write("\bX");
                else
                {
                    Write("\bX");
                    ForegroundColor = ConsoleColor.DarkRed;
                    WriteLine("\n\nПароль не співпадає!\n");
                    ResetColor();
                    Write("\nВведіть новий пароль ще раз (4 цифри): ");
                    i = -1;
                }
            }
            SetSum();
            accountId = Bank.totalClients;
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine("\nАккаунт створений!\n");
            ResetColor();
        }

        public void SetSum()
        {
            bool test;
            do
            {
                test = false;
                Write("\n\nЯку суму Ви бажаєте покласти на рахунок? ");
                if (Double.TryParse(ReadLine(), out double tempSum))
                {
                    if (tempSum < 0)
                    {
                        ForegroundColor = ConsoleColor.DarkRed;
                        WriteLine("\nПомилка: сума не може мати від\'ємне значення! Спробуйте ще раз!");
                        ResetColor();
                        test = true;
                    }
                    else
                        sum += tempSum;
                }
                else
                {
                    ForegroundColor = ConsoleColor.DarkRed;
                    WriteLine("\n\nЦе не число! Спробуйте ще раз!");
                    ResetColor();
                    test = true;
                }
            } while (test);
        }

        public double GetSum() { return sum; }

        public void MinusMoney()
        {
            bool test;
            do
            {
                test = false;
                Write("\n\nЯку суму Ви бажаєте зняти з рахунка? ");
                if (Double.TryParse(ReadLine(), out double tempSum))
                {
                    if (tempSum < 0)
                    {
                        ForegroundColor = ConsoleColor.DarkRed;
                        WriteLine("\nПомилка: сума не може мати від\'ємне значення! Спробуйте ще раз!");
                        ResetColor();
                        test = true;
                    }
                    else if (tempSum >= sum)
                    {
                        ForegroundColor = ConsoleColor.DarkRed;
                        WriteLine("\nПомилка: недостатньо грошей на рахунку!");
                        WriteLine($"Ви можете зняти суму не більшу за {sum} гривень!");
                        ResetColor();
                        test = true;
                    }
                    else
                        sum -= tempSum;
                }
                else
                {
                    ForegroundColor = ConsoleColor.DarkRed;
                    WriteLine("\n\nЦе не число! Спробуйте ще раз!");
                    ResetColor();
                    test = true;
                }
            } while (test);
        }

        public bool GetPassword()
        {
            if (DateTime.Now.Hour >= 6 && DateTime.Now.Hour <= 10)
                WriteLine("\n\nДоброго ранку!");
            else if (DateTime.Now.Hour >= 11 && DateTime.Now.Hour <= 18)
                WriteLine("\n\nДоброго дня!");
            else if (DateTime.Now.Hour >= 19 && DateTime.Now.Hour <= 23)
                WriteLine("\n\nДоброго вечора!");
            else
                WriteLine("\n\nДоброї ночі!");
            
            bool test = true;
            Write("Введіть пароль: ");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < password.Length; j++)
                {
                    if (password[j] == (byte)Char.GetNumericValue(ReadKey().KeyChar))
                    {
                        Write("\bX");
                        continue;
                    }
                    else
                    {
                        test = false;
                        Write("\bX");
                        continue;
                    }
                }

                if (!test)
                {
                    ForegroundColor = ConsoleColor.DarkRed;
                    WriteLine($"\n\nПароль неправильний! Залишилось спроб: {2 - i}\n");
                    ResetColor();
                    Write("Введіть пароль ще раз: ");
                    test = true;
                    continue;
                }
                else
                    return true;
            }
            return false;
        }
    }
}