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
        public string skillname;
        public string color;
        protected int ad;//攻击力
        protected int adr;//护甲
        protected int MP;
        protected int MAXMP;
        protected double MAXHP;
        protected double HP;
        protected double ASD;//攻速
        protected int totaldamage;
        protected int heroLevel = 0;
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
            this.totaldamage += delhp;
            lock (HPlock)
            {
                HP -= delhp;
                LinkToClient.SendCommand("fightLog " + square.squareId + " " +
                    heroName + "受到" + hero.heroName + "攻击，造成" + delhp + "点伤害!");
                mudaLog("受到" + hero.heroName + "攻击，造成" + delhp + "点伤害!");
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
        public void addHP(int hp, Hero hero)
        {
            AddMP();
            int addhp = hp;
            lock (HPlock)
            {
                if (HP + hp > MAXHP)
                    HP = MAXHP;
                else
                HP += hp;
            }
        }
        protected void Skill()
        {
            switch (this.heroName)
            {
                
                case "弗拉基米尔":
                    target.delHP(200, this);
                    addHP(40, this);
                    break;
                case "克格莫":
                    target.delHP(125, this);
                    break;
                case "沃里克":
                    target.delHP(150, this);
                    break;
                case "薇恩":
                    target.delHP(((int)(0.09*target.MAXHP)), this);
                    break;
                case "雷克塞":
                    target.delHP(250, this);
                    break;
                case "维迦":
                    target.delHP(150, this);
                    break;
                case "辛德拉":
                    target.delHP(175, this);
                    break;
                case "乐芙兰":
                    target.delHP(200, this);
                    break;
                case "沃利贝尔":
                    target.delHP(200, this);
                    break;
                case "茂凯":
                    addHP(50, this);
                    break;

            }
            oulaLog(heroName + "发动了技能");
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
            int count=1;
            while (HP > 0)
            {
                if (MP == MAXMP)
                {
                    if (heroName == "薇恩" || heroName == "茂凯")
                    {
                        if (count == 3)
                        {
                            Skill();
                            count = 1;
                        }
                    }
                    else
                    {
                        Skill();
                        lock (MPlock)
                        {
                            MP = 0;
                        }
                        LinkToClient.SendCommand("setHeroInf " + square.squareId + " MP-" + MP);
                    }
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
                    oulaLog(heroName + "向" + target.heroName + "发动攻击，造成" + damage + "点伤害!");
                    count++;
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

        protected void oulaLog(string log)
        {
            LinkToClient.SendCommand("fightLog " + square.squareId + " oulaLog " + log);
        }
        protected void mudaLog(string log)
        {
            LinkToClient.SendCommand("fightLog " + square.squareId + " mudaLog " + log);
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
