using System;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkToClient linkToClient = new LinkToClient();
            Console.WriteLine("Hello World!");
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