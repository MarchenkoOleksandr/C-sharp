using System;
using System.Text;
using static System.Console;

namespace class_TryPassword
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputEncoding = Encoding.Unicode;
            InputEncoding = Encoding.Unicode;
            Title = "Class TryPassword";

            WriteLine("Вітаємо! Ця програма перевіряє ступінь захищеності пароля!\n");

            TryPassword pw = new TryPassword();

            ReadKey();
        }
    }
}