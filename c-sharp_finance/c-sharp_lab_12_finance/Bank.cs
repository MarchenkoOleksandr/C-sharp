using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using static System.Console;

namespace finance
{
    class Bank
    {
        public string BankName { get; set; }
        public string USDbuy { get; set; }
        public string USDsale { get; set; }
        
        public override string ToString()
        {
            return $"{BankName.PadRight(30)} {USDbuy}     {USDsale}";
        }

        public static void Save(List<Bank> banks)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter($"output.xml", Encoding.Unicode))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("banks");
                    foreach (Bank item in banks)
                    {
                        writer.WriteStartElement("bank");
                        writer.WriteElementString("BankName", item.BankName);
                        writer.WriteElementString("USDbuy", item.USDbuy);
                        writer.WriteElementString("USDsale", item.USDsale);

                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
                ForegroundColor = ConsoleColor.DarkGreen;
                WriteLine($"\n\nДані збережені у файлі \"output.xml\"!");
            }
            catch (Exception e)
            {
                ForegroundColor = ConsoleColor.DarkRed;
                WriteLine(e.Message);
            }
            ResetColor();
        }
    }
}