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
        public int heroLevel;
        public string heroSkill = "对单个个体造成1000点伤害";
        public string setHeroInf()
        {
            return "setHeroInf "+heroSquareId.ToString()+" skill-"+heroSkill;
        }
    }
}