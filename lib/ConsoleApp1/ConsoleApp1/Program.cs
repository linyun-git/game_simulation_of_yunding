using System;
using System.Xml;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            String data = null;
             data = XMLjiexi.GetDetail("奥恩", "LV2", "hp");

            // data = XMLjiexi.GetRace("奥恩");

            // data = XMLjiexi.GetCareer("奥恩");

            Console.WriteLine(data);
            Console.ReadLine();
        }
    }
    class XMLjiexi
    {
        //  获取英雄不同等级的技能（skill），护甲(adr)，生命值(hp)，攻击力(ad)  输入参数为（英雄的名字，等级，所需内容）
        public static string GetDetail(string name, string lv ,string detail)
        {
            string informationNeeded = "/HeroList/hero[@name='" + name + "']/detail/" + lv + "/" + detail;
            XmlDocument dom = new XmlDocument();
            dom.Load(@"..\..\..\..\Hero\hero_attribute.xml");
            XmlElement root = dom.DocumentElement;
            XmlElement node = (XmlElement)root.SelectSingleNode(informationNeeded);
            return node.InnerText;
        }
        // 获取英雄的种族  输入参数为（英雄的名字）
        public static string GetRace(string name)
        {
            string informationNeeded = "/HeroList/hero[@name='" + name + "']/race";
            XmlDocument dom = new XmlDocument();
            dom.Load(@"..\..\..\..\Hero\hero_attribute.xml");
            XmlElement root = dom.DocumentElement;
            XmlElement node = (XmlElement)root.SelectSingleNode(informationNeeded);
            return node.InnerText;
        }
        // 获取英雄的职业  输入参数为（英雄的名字）
        public static string GetCareer(string name)
        {
            string informationNeeded = "/HeroList/hero[@name='" + name + "']/career";
            XmlDocument dom = new XmlDocument();
            dom.Load(@"..\..\..\..\Hero\hero_attribute.xml");
            XmlElement root = dom.DocumentElement;
            XmlElement node = (XmlElement)root.SelectSingleNode(informationNeeded);
            return node.InnerText;
        }

    }
}
