using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using static System.Console;

namespace finance
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputEncoding = Encoding.Unicode;
            InputEncoding = Encoding.Unicode;
            Title = "Get exchange rates";

            WriteLine("Вітаємо! Це програма-парсер, яка виводить курс долара з сайту finance.i.ua\n");

            WebClient client = new WebClient { Encoding = Encoding.UTF8 };
            string link = "https://finance.i.ua/";
            string siteText = client.DownloadString(link);

            Regex regex = new Regex("<a href=\"/bank/\\d+/\">[\\w\\s-]*</a><time></time></th><td class=\"buy_rate\"><span class=\"[\\w\\s-]*\"><span>\\d+\\.\\d+</span></span></td><td class=\"sell_rate\"><span class=\"[\\w\\s-]*\"><span>\\d+\\.\\d+</span>");
            MatchCollection matches = regex.Matches(siteText.Remove(siteText.LastIndexOf("bank_rates_eur")));

            if (matches.Count > 0)
            {
                string[] bankName = new string[matches.Count];
                List<Bank> banks = new List<Bank>(matches.Count);
                foreach (Match match in matches)
                {
                    banks.Add(new Bank());
                    banks[banks.Count - 1].BankName = Regex.Replace(Regex.Replace(match.Value, "<a href=\"/bank/\\d+/\">", String.Empty), "</a><time></time></th><td class=\"buy_rate\"><span class=\"[\\w\\s-]*\"><span>\\d+\\.\\d+</span></span></td><td class=\"sell_rate\"><span class=\"[\\w\\s-]*\"><span>\\d+\\.\\d+</span>", String.Empty);
                    banks[banks.Count - 1].USDbuy = Regex.Replace(Regex.Replace(match.Value, "<a href=\"/bank/\\d+/\">[\\w\\s-]*</a><time></time></th><td class=\"buy_rate\"><span class=\"[\\w\\s-]*\"><span>", String.Empty), "</span></span></td><td class=\"sell_rate\"><span class=\"[\\w\\s-]*\"><span>\\d+\\.\\d+</span>", String.Empty);
                    banks[banks.Count - 1].USDsale = Regex.Replace(Regex.Replace(match.Value, "<a href=\"/bank/\\d+/\">[\\w\\s-]*</a><time></time></th><td class=\"buy_rate\"><span class=\"[\\w\\s-]*\"><span>\\d+\\.\\d+</span></span></td><td class=\"sell_rate\"><span class=\"[\\w\\s-]*\"><span>", String.Empty), "</span>", String.Empty);
                }
                ForegroundColor = ConsoleColor.DarkGreen;
                WriteLine($"{"Назва банку".PadRight(30)} покупка/продаж (долар)");
                ResetColor();
                foreach (Bank item in banks)
                    WriteLine(item);
                Bank.Save(banks);
            }
            else
            {
                ForegroundColor = ConsoleColor.DarkRed;
                WriteLine($"\nПомилка отримання даних з сайту finance.i.ua!");
                ResetColor();
            }
            ReadKey(true);
        }
    }
}