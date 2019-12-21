using System;
using System.Threading;
using data_analysis;


namespace Main
{
    public class Hero
    {
        public const string Red = "red";
        public const string Blue = "blue";
        public const string unKnow = "unKnow";
        public string color;
        private int ad;//攻击力
        private int adr;//护甲
        private double MAXHP;
        private double HP;
        private double ASD;//攻速
        private int heroLevel;
        public string heroName;
        private 攻击类型 type = 攻击类型.近战;
        public Square square;

        private readonly object HPlock= new object();

        Hero target;

        public Hero()
        {
            color = unKnow;
        }
        public void SetSquare(Square square)
        {
            this.square = square;
        }
        public Hero(string heroName, int level, int id)
        {
            this.heroName = heroName;
            heroLevel = level;
            if (id <= 27)
            {
                color = Blue;
            }
            else
            {
                color = Red;
            }
            init();
        }
        public bool isLive()
        {
            if (HP > 0)
                return true;
            else
                return false;
        }
        public void run()
        {
            Console.WriteLine(heroName + "run");
            LinkToClient.SendCommand("setHeroInf " + square.squareId + " HP-" + HP);
            getTarget();
            Attack();
        }
        private void init()
        {
            ad = int.Parse(GetInf("ad"));
            MAXHP = int.Parse(GetInf("hp"));
            adr = int.Parse(GetInf("adr"));
            ASD = double.Parse(GetInf("asd"));
            HP = MAXHP;
        }
        public void delHP(int hp, Hero hero)
        {
            int delhp = hp * adr / 100;
            lock (HPlock)
            {
                HP -= delhp;
                LinkToClient.SendCommand("fightLog " + square.squareId + " " +
                    heroName + "受到" + hero.heroName + "发动攻击，造成" + delhp + "点伤害!");
            }
            //message(heroName + "受到" + hero.heroName + "发动攻击，造成" +delhp + "点伤害!");
            if (HP <= 0)
            {
                message(heroName + "已经死亡！");
                HP = 0;
            }
            else
            {
                message(heroName + "生命值变为" + HP);
            }
            LinkToClient.SendCommand("setHeroInf " + square.squareId + " HP-" + HP);
        }
        private void Attack()
        {
            int damage;
            while (HP > 0)
            {
                Random rd = new Random();
                int baoji = rd.Next(1, 5);
                if (baoji == 1)
                {
                    damage = ad * 2;
                }
                else
                {
                    damage = ad;
                }
                if (target.HP > 0)
                {
                    target.delHP(damage, this);
                    message(heroName + "向" + target.heroName + "发动攻击，造成" + damage + "点伤害!");
                }
                else
                {
                    getTarget();
                    if (target.color == unKnow)
                        break;
                }
                Thread.Sleep(TimeSpan.FromSeconds(1 / ASD));
                //System.Threading.Thread.Sleep(100);
            }
        }

        ///<summary>获取目标</summary>
        private void getTarget()
        {
            target = square.GetTarget();
        }

        ///<summary>读取英雄数据</summary>
        private string GetInf(string heroInf)
        {
            string inf = "0";
            try
            {
                inf = XMLjiexi.GetDetail(heroName, heroLevel, heroInf);
            }
            catch (Exception e)
            {
                Battle.map.error("获取" + heroName + "的" + heroInf + "错误");
                Console.WriteLine(e);
            }
            return inf;
        }

        ///<summary>产生信息</summary>
        private void message(string mes)
        {
            Battle.map.message(mes);
        }
        enum 攻击类型 { 近战, 远程 }
    }
}
