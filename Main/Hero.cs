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
        protected int ad;//攻击力
        protected int adr;//护甲
        protected int MP;
        protected int MAXMP;
        protected double MAXHP;
        protected double HP;
        protected double ASD;//攻速
        protected int heroLevel;
        public string heroName;
        protected 攻击类型 type = 攻击类型.近战;
        public Square square;

        protected readonly object HPlock= new object();
        protected readonly object MPlock = new object();

        protected Hero target;

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
        protected void init()
        {
            ad = int.Parse(GetInf("ad"));
            MAXHP = int.Parse(GetInf("hp"));
            adr = int.Parse(GetInf("adr"));
            ASD = double.Parse(GetInf("asd"));
            HP = MAXHP;
            MP = int.Parse(GetInf("mp"));
            MAXMP = int.Parse(GetInf("mmp"));
        }
        public void delHP(int hp, Hero hero)
        {
            AddMP();
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
        protected void Skill()
        {
            switch (this.heroName)
            {
                case "茂凯":
                    lock (HPlock) 
                    this.HP += 100;
                    LinkToClient.SendCommand("fightLog " + square.squareId + " " + "发动了技能");
                    break;
                case "弗拉基米尔":
                    lock (HPlock)
                        this.HP += 200;
                    target.delHP(200, this);
                    LinkToClient.SendCommand("fightLog " + square.squareId + " " + "发动了技能");
                    break;
            }
            
        }
        protected void AddMP()
        {
            lock (MPlock)
            {
                if (MAXMP - MP < 10)
                    MP = MAXMP;
                else
                    MP += 10;
            }
            LinkToClient.SendCommand("setHeroInf " + square.squareId + " MP-" + MP);
        }
        protected void Attack()
        {
            int damage;
            while (HP > 0)
            {
                if (MP == MAXMP)
                {
                    Skill();
                    lock (MPlock)
                    {
                        MP = 0;
                    }
                    LinkToClient.SendCommand("setHeroInf " + square.squareId + " MP-" + MP);
                }
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
                    AddMP();
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
        protected void getTarget()
        {
            target = square.GetTarget();
        }

        ///<summary>读取英雄数据</summary>
        protected string GetInf(string heroInf)
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
        protected void message(string mes)
        {
            Battle.map.message(mes);
        }
        protected enum 攻击类型 { 近战, 远程 }

    }
}
