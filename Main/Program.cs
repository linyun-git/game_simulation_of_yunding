using System;
using System.Diagnostics;
using System.Threading;

namespace Main
{
    class Program
    {
        public static string[] heros = {"阿兹尔", "艾翁",
            "黛安娜", "劫", "拉克丝", "乐芙兰", "雷克顿",
            "娜美", "千珏", "辛德拉" };
        static void Main(string[] args)
        {
            Console.WriteLine("Myid："+ Process.GetCurrentProcess().Id);
            Process electron = new Process();
            string elecStr = "cloudTop/cloudTop.exe";
            try
            {
                electron.StartInfo.UseShellExecute = false;
                electron.StartInfo.FileName = elecStr;
                electron.StartInfo.CreateNoWindow = true;
                electron.Start();
                Console.WriteLine("electronID："+electron.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            LinkToClient linkToClient = new LinkToClient();
            Console.WriteLine("Hello World!");
            try
            {
                electron.Kill();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    class Hero
    {
        public string heroName;
        public int heroSquareId;
        public int heroLevel = 1;
        public string heroSkill = "对单个个体造成1000点伤害";

        ///<summary>返回设置英雄信息命令的字符串</summary>
        public string setHeroInf()
        {
            return "setHeroInf "+heroSquareId.ToString()+" skill-"+heroName+"的skill";
        }
    }
}