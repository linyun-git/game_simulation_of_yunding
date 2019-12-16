using System;
using System.Collections.Generic;
using System.Threading;
using data_analysis;


namespace Battle
{
    class Program
    {
        static void Main()
        {
            Map map = new Map();
            List<Hero> blueHeros = new List<Hero>();
            List<Hero> redHeros = new List<Hero>();
            blueHeros.Add(new Hero(map,"奥恩",1,1));
            blueHeros.Add(new Hero(map, "奥恩", 1, 2));
            blueHeros.Add(new Hero(map, "塔莉垭", 1, 28));
            blueHeros.Add(new Hero(map, "塔莉垭", 1, 29));
            map.MapList(blueHeros, redHeros);
            map.run();
        }
    }
    class Map
    {
        List<Hero> blueHeros = new List<Hero>();
        List<Hero> redHeros = new List<Hero>();
        public void MapList(List<Hero> blue, List<Hero> red)
        {
            blueHeros = blue;
            redHeros = red;
        }
        public Hero getTarget(Hero ahero)
        {
            List<Hero> heroList;
            string str = "";
            if (ahero.id > 27)
            {
                heroList = blueHeros;
                str = "红方";
            }
            else
            {
                heroList = redHeros;
            }
            for(int i = 0; i < heroList.Count; i++)
            {
                if (heroList[i].isLive())
                {
                    return heroList[i];
                }
            }
            message(str + "胜利！");
            return new Hero(this,"未知",0,-1);
        }
        public void run()
        {
            for(int i = 0; i < blueHeros.Count; i++)
            {
                blueHeros[i].t.Start();
            }
            for (int i = 0; i < redHeros.Count; i++)
            {
                redHeros[i].t.Start();
            }
            for (int i = 0; i < blueHeros.Count; i++)
            {
                blueHeros[i].t.Join();
            }

            for (int i = 0; i < redHeros.Count; i++)
            {
                blueHeros[i].t.Join();
            }
        }
        public void error(string error)
        {
            Console.WriteLine(error);
        }

        ///<summary>打印信息</summary>
        public void message(string mes)
        {
            Console.WriteLine(mes);
        }
    }

    class Hero
    {
        public int id;
        private int ad;//攻击力
        private int adr;//护甲
        private double MAXHP { get; set; }
        private double HP { get; set; }
        private double ASD { get; set; }//攻速
        private double Dead { get; set; }
        private int heroLevel;
        public string heroName;
        public Thread t;

        Hero target;
        Map map;


        public Hero(Map map,string heroName,int level,int id)
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
        private void init()
        {
            ad = int.Parse(GetInf("ad"));
            HP = int.Parse(GetInf("hp"));
            adr = int.Parse(GetInf("adr"));
            getTarget();
            t = new Thread(new ParameterizedThreadStart(Attack));
        }
        public void delHP(int hp,Hero hero)
        {
            int delhp = hp * adr / 100;
            HP = HP - delhp;
            message(heroName + "受到" + target.heroName + "发动攻击，造成" +delhp + "点伤害!");
            message(heroName+ "生命值变为"+HP);
        }
        public void Attack(object tar)
        {
            int damage;
            while (this.HP > 0)
            {
                Random rd = new Random();
                int baoji = rd.Next(1, 5);
                if (baoji == 1)
                {
                    damage = this.ad  * 2;
                }
                else
                {
                    damage = this.ad;
                }
                if (target.HP > 0)
                {
                    target.delHP(damage,this);
                    message(heroName+"向"+target.heroName+"发动攻击，造成"+damage+"点伤害!");
                }
                else
                {
                    getTarget();
                    if (target.id == -1)
                        break;
                }
                Thread.Sleep(TimeSpan.FromSeconds(1 / (this.ASD)));
            }
            if (HP <= 0)
            {
                message(heroName + "已经死亡！");
                HP = 0;
                Dead = 1;
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
                map.error("获取"+heroName+"的"+heroInf+"错误");
                Console.WriteLine(e);
            }
            return inf;
        }

        ///<summary>产生信息</summary>
        private void message(string mes)
        {
            map.message(mes);
        }
    }


}
