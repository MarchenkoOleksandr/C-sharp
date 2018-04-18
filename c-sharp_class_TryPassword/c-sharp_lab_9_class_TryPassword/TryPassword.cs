using System;
using System.Linq;
using static System.Console;

namespace class_TryPassword
{
    class TryPassword
    {
        private string password;

        public TryPassword()
        {
            Write("\nВведіть пароль: ");
            password = ReadLine();
            if (CheckPassword(password, 8))
            {
                ForegroundColor = ConsoleColor.DarkGreen;
                WriteLine("Пароль прийнятий!");
            }
            else
            {
                ForegroundColor = ConsoleColor.DarkRed;
                WriteLine("Пароль не прийнятий!");
            }
            ResetColor();
        }

        private bool CheckPassword(string password, byte len)
        {
            byte rating = 0;
            try
            {
                if (password.Length >= len)
                    rating = 20;
                else
                    throw new Exception("довжина пароля має бути за 8 символів та більша!");

                for (char i = 'a'; i <= 'z'; i++)
                {
                    if (password.Contains(i))
                    {
                        rating = 40;
                        break;
                    }
                    else if (i == 'z' && !password.Contains(i))
                        throw new Exception("пароль має містити малі літери англійської абетки!");
                }

                for (char i = 'A'; i <= 'Z'; i++)
                {
                    if (password.Contains(i))
                    {
                        rating = 60;
                        break;
                    }
                    else if (i == 'Z' && !password.Contains(i))
                        throw new Exception("пароль має містити великі літери англійської абетки!");
                }

                for (char i = '0'; i <= '9'; i++)
                {
                    if (password.Contains(i))
                    {
                        rating = 80;
                        break;
                    }
                    else if (i == '9' && !password.Contains(i))
                        throw new Exception("пароль має містити цифри!");
                }

                for (char i = '!'; i <= '~'; i++)
                {
                    if (password.Contains(i))
                    {
                        rating = 100;
                        break;
                    }
                    else if (i == '/' && !password.Contains(i))
                        i = '9';
                    else if (i == '@' && !password.Contains(i))
                        i = 'Z';
                    else if (i == '`' && !password.Contains(i))
                        i = 'z';
                    else if (i == '~' && !password.Contains(i))
                        throw new Exception("пароль має містити спецсимволи!");
                }
            }
            catch (Exception e)
            {
                ForegroundColor = ConsoleColor.DarkRed;
                WriteLine($"\nПомилка: {e.Message}");
                ResetColor();
            }
            finally
            {
                if (rating <= 40)
                    ForegroundColor = ConsoleColor.DarkRed;
                else if (rating <= 80)
                    ForegroundColor = ConsoleColor.DarkYellow;
                else
                    ForegroundColor = ConsoleColor.DarkGreen;

                WriteLine($"\nСтупінь надійності пароля: {rating}%\n");
                ResetColor();
            }
            if (rating == 100)
                return true;
            else
                return false;
        }
    }
}