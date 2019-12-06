using System;
using System.Xml;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {

            XMLjiexi.Get("s", "s", "s");
            
        }
    }
    class XMLjiexi
    {
        public static string Get(string name, string lv ,string detail)
        {
            string text = null;
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\fengruoling\Desktop\yunding\game_simulation_of_yunding\lib\Hero\hero_attribute.xml");

            XmlElement root = null;
            root = doc.DocumentElement;

            XmlNodeList listNodes = null;
            listNodes = root.SelectNodes("/HeroList/hero/name");

             foreach (XmlNode node in listNodes)
            {
                text += node.InnerText + "\n";
            }
            Console.WriteLine(text);
            Console.ReadLine();
            return text;
        }
    }
}
