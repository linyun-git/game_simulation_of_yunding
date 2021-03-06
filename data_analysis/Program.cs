using System;
using System.Xml;

namespace data_analysis
{

    class Program
    {

        static void Main(string[] args)
        {
           String data = null;
            //data = XMLjiexi.GetDetail("奥恩", 2, "hp");

            // data = XMLjiexi.GetRace("奥恩");

            // data = XMLjiexi.GetCareer("奥恩");

            /*String[] name = XMLjiexi.GetName();
            for(int i=0;i<100; i++)
            {
                Console.WriteLine(name[i]);
            }*/

            data = XMLjiexi.GetSkillname("弗拉基米尔");


            Console.WriteLine(data);
            Console.ReadLine();
        }
    }
    public class XMLjiexi
        {
        //  获取英雄不同等级的，护甲(adr)，生命值(hp)，攻击力(ad)  输入参数为（英雄的名字，等级，所需内容）
        public static string GetDetail(string name, int lv, string detail)
        {
            string informationNeeded = "/HeroList/hero[@name='" + name + "']/detail/LV" + lv + "/" + detail;
            XmlDocument dom = new XmlDocument();
            dom.Load(@"..\..\..\..\src\hero_attribute.xml");
            XmlElement root = dom.DocumentElement;
            XmlElement node = (XmlElement)root.SelectSingleNode(informationNeeded);
            return node.InnerText;
        }
        // 获取英雄的种族  输入参数为（英雄的名字）
        public static string GetRace(string name)
        {
            string informationNeeded = "/HeroList/hero[@name='" + name + "']/race";
            XmlDocument dom = new XmlDocument();
            dom.Load(@"..\..\..\..\src\hero_attribute.xml");
            XmlElement root = dom.DocumentElement;
            XmlElement node = (XmlElement)root.SelectSingleNode(informationNeeded);
            return node.InnerText;
        }
        // 获取英雄的职业  输入参数为（英雄的名字）
        public static string GetCareer(string name)
        {
            string informationNeeded = "/HeroList/hero[@name='" + name + "']/career";
            XmlDocument dom = new XmlDocument();
            dom.Load(@"..\..\..\..\src\hero_attribute.xml");
            XmlElement root = dom.DocumentElement;
            XmlElement node = (XmlElement)root.SelectSingleNode(informationNeeded);
            return node.InnerText;
        }

        // 获取英雄的技能名字  输入参数为（英雄的名字）
        public static string GetSkillname(string name)
        {
            string informationNeeded = "/HeroList/hero[@name='" + name + "']/skillname";
            XmlDocument dom = new XmlDocument();
            dom.Load(@"..\..\..\..\src\hero_attribute.xml");
            XmlElement root = dom.DocumentElement;
            XmlElement node = (XmlElement)root.SelectSingleNode(informationNeeded);
            return node.InnerText;
        }

        // 获取英雄的技能  输入参数为（英雄的名字）
        public static string GetSkill(string name)
        {
            string informationNeeded = "/HeroList/hero[@name='" + name + "']/skill";
            XmlDocument dom = new XmlDocument();
            dom.Load(@"..\..\..\..\src\hero_attribute.xml");
            XmlElement root = dom.DocumentElement;
            XmlElement node = (XmlElement)root.SelectSingleNode(informationNeeded);
            return node.InnerText;
        }
        
        //获取所有的英雄名字
        public static String[] GetName()
        {
            string name;
            XmlDocument dom = new XmlDocument();
            dom.Load(@"..\..\..\..\src\hero_attribute.xml");
            XmlNode cNodes = dom.SelectSingleNode("HeroList");
            string[] allname = new string[cNodes.ChildNodes.Count];
            for (int i = 0; i < cNodes.ChildNodes.Count; i++)
            {
                XmlNode node = cNodes.ChildNodes[i];
                name = node.Attributes["name"].Value; //这里就取到name的值
                allname[i] = name;
            }
            return allname;
        }

    }

}
