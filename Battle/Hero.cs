using System;
using System.Threading;
using data_analysis;


namespace Main
{
    public class Hero
    {
        public int id;
        private int ad;//攻击力
        private int adr;//护甲
        private double MAXHP;
        private double HP;
        private double ASD;//攻速
        private int heroLevel;
        public string heroName;
        private 攻击类型 type = 攻击类型.近战;
        public Square square;

        Hero target;
        Map map;

        public Hero()
        {
            id = -1;
        }
        public void SetSquare(Square square)
        {
            this.square = square;
        }
        public Hero(string heroName, int level, int id)
        {
            this.heroName = heroName;
            heroLevel = level;
            this.id = id;
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
            getTarget();
            Attack();
        }
        private void init()
        {
            ad = int.Parse(GetInf("ad"));
            HP = int.Parse(GetInf("hp"));
            adr = int.Parse(GetInf("adr"));
            ASD = double.Parse(GetInf("asd"));
        }
        public void delHP(int hp, Hero hero)
        {
            int delhp = hp * adr / 100;
            HP = HP - delhp;
            //message(heroName + "受到" + hero.heroName + "发动攻击，造成" +delhp + "点伤害!");
            if (HP <= 0)
            {
                message(heroName + "已经死亡！");
                HP = 0;
            }
            else message(heroName + "生命值变为" + HP);
        }
        private void Attack()
        {
            int damage;
            while (this.HP > 0)
            {
                Random rd = new Random();
                int baoji = rd.Next(1, 5);
                if (baoji == 1)
                {
                    damage = this.ad * 2;
                }
                else
                {
                    damage = this.ad;
                }
                if (target.HP > 0)
                {
                    target.delHP(damage, this);
                    message(heroName + "向" + target.heroName + "发动攻击，造成" + damage + "点伤害!");
                }
                else
                {
                    getTarget();
                    if (target.id == -1)
                        break;
                }
                Thread.Sleep(TimeSpan.FromSeconds(1 / ASD));
                //System.Threading.Thread.Sleep(100);
            }
        }

        ///<summary>获取目标</summary>
        private void getTarget()
        {
            target = map.getTarget(this);
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
                map.error("获取" + heroName + "的" + heroInf + "错误");
                Console.WriteLine(e);
            }
            return inf;
        }

        ///<summary>产生信息</summary>
        private void message(string mes)
        {
            map.message(mes);
        }
        enum 攻击类型 { 近战, 远程 }
    }
}
