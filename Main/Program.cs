using System;
using System.Diagnostics;
using System.Threading;
using data_analysis;
using Main;

namespace Main
{
    class Program
    {
        /*public static string[] heros = {"阿兹尔", "艾翁",
            "黛安娜", "劫", "拉克丝", "乐芙兰", "雷克顿",
            "娜美", "千珏", "辛德拉" };*/
        public static string[] heros = {"弗拉基米尔", "克格莫",
            "乐芙兰", "雷克顿", "茂凯", "薇恩", "维迦",
            "沃里克", "沃利贝尔", "辛德拉" };
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
            Main main = new Main();
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
    public class HeroInf
    {
        private string heroName;
        private int heroSquareId;
        private int heroLevel;
        private Ability ability;

        public HeroInf(string heroName, int heroSquareId)
        {
            this.heroName = heroName;
            this.heroSquareId = heroSquareId;
            heroLevel = 1;
            ability = new Ability();
            Init();
        }
        public int GetId()
        {
            return heroSquareId;
        }
        private void Init()
        {
            ability.ad = int.Parse(GetInf("ad"));
            //ability.ap = Int32.Parse(getInf("ap"));
            ability.adr = int.Parse(GetInf("adr"));
            ability.apr = int.Parse(GetInf("apr"));
            ability.MP = int.Parse(GetInf("mp"));
            ability.maxHP = int.Parse(GetInf("hp"));
            ability.maxMP = int.Parse(GetInf("mmp"));
            ability.heroSkill = GetSkill();
        }
        private string GetSkill()
        {
            string inf = "0";
            try
            {
                inf = XMLjiexi.GetSkill(heroName);
            }
            catch (Exception)
            {
                Console.WriteLine("获取" +heroName+ "的skill" + "错误");
            }
            return inf;
        }
        private string GetInf(string heroInf)
        {
            string inf = "0";
            try
            {
                inf = XMLjiexi.GetDetail(heroName, heroLevel, heroInf);
            }
            catch (Exception)
            {
                Console.WriteLine("获取"+ heroInf+"错误");
            }
            return inf;
        }
        ///<summary>修改英雄等级</summary>
        public void ChangeLevel()
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
                default:
                    break;
            }
            Init();
        }
        ///<summary>返回设置英雄信息命令的字符串</summary>
        public string GetHeroInf()
        {
            return "ad-"+ability.ad+" ap-"+ability.ap+" adr-"+ability.adr+" apr-"+ability.apr
                +" MP-"+ability.MP+" maxHP-"+ability.maxHP+" maxMP-"+ability.maxMP+" level-"+ heroLevel+" skill-"+ability.heroSkill;
        }
        public bool IdEquals(int heroSquareId)
        {
            if(this.heroSquareId == heroSquareId)
            {
                return true;
            }
            else return false;
        }

        public Hero ToHero()
        {
            return new Hero(heroName,heroLevel,heroSquareId);
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