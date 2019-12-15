using System;
using System.Diagnostics;
using System.Threading;
using ConsoleApp1;

namespace Main
{
    class Program
    {
        public static string[] heros = {"阿兹尔", "艾翁",
            "黛安娜", "劫", "拉克丝", "乐芙兰", "雷克顿",
            "娜美", "千珏", "辛德拉" };
        static void Main(string[] args)
        {
            /*注释掉直接打开打包后的electron应用，方便调试
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
            }*/
            LinkToClient linkToClient = new LinkToClient();
            Console.WriteLine("Hello World!");
            /*try
            {
                electron.Kill();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }*/
        }
    }
    class HeroInf
    {
        private string heroName;
        private int heroSquareId;
        private int heroLevel;
        private Ability ability;

        public HeroInf(String heroName,int heroSquareId)
        {
            this.heroName = heroName;
            this.heroSquareId = heroSquareId;
            heroLevel = 1;
            ability = new Ability();
            init();
        }
        private void init()
        {
            try
            {
                ability.ad = Int32.Parse(XMLjiexi.GetDetail(heroName, "LV" + this.heroLevel, "ad"));
                //ability.ap = Int32.Parse(XMLjiexi.GetDetail(heroName, "LV" + this.heroLevel, "ap"));
                ability.adr = Int32.Parse(XMLjiexi.GetDetail(heroName, "LV" + this.heroLevel, "adr"));
                ability.apr = Int32.Parse(XMLjiexi.GetDetail(heroName, "LV" + this.heroLevel, "apr"));
                ability.MP = Int32.Parse(XMLjiexi.GetDetail(heroName, "LV" + this.heroLevel, "mp"));
                ability.maxHP = Int32.Parse(XMLjiexi.GetDetail(heroName, "LV" + this.heroLevel, "hp"));
                ability.maxMP = Int32.Parse(XMLjiexi.GetDetail(heroName, "LV" + this.heroLevel, "mmp"));
                ability.heroSkill = XMLjiexi.GetDetail(heroName, "LV" + this.heroLevel, "skill");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        ///<summary>修改英雄等级</summary>
        public void changeLevel()
        {
            switch (heroLevel)
            {
                case 1:
                    heroLevel = 2;
                    break;
                case 2:
                    heroLevel = 3;
                    break;
                case 3:
                    heroLevel = 1;
                    break;
            }
            init();
        }
        ///<summary>返回设置英雄信息命令的字符串</summary>
        public string getHeroInf()
        {
            return "ad-"+ability.ad+" ap-"+ability.ap+" adr-"+ability.adr+" apr-"+ability.apr
                +" MP-"+ability.MP+" maxHP-"+ability.maxHP+" maxMP-"+ability.maxMP+" heroSkill-"+ability.heroSkill+" level-"+ heroLevel;
        }
        public Boolean idEquals(int heroSquareId)
        {
            if(this.heroSquareId == heroSquareId)
            {
                return true;
            }
            else return false;
        }

        ///<summary>英雄属性</summary>
        private class Ability
        {
            ///<summary>攻击力</summary>
            public int ad;
            ///<summary>法强</summary>
            public int ap = 100;
            ///<summary>护甲</summary>
            public int adr;
            ///<summary>魔抗</summary>
            public int apr;
            ///<summary>初始法力值</summary>
            public int MP;
            ///<summary>最大生命值</summary>
            public int maxHP;
            ///<summary>最大法力值</summary>
            public int maxMP;
            ///<summary>英雄技能文本描述</summary>
            public string heroSkill;
        }
    }
}