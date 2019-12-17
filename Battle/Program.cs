using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
            blueHeros.Add(new Hero(map, "茂凯", 1, 2));
            redHeros.Add(new Hero(map, "塔莉垭", 1, 28));
            redHeros.Add(new Hero(map, "薇恩", 1, 29));
            map.MapList(blueHeros, redHeros);
            map.run();
        }
    }
    class Map
    {
        List<Hero> blueHeros = new List<Hero>();
        List<Hero> redHeros = new List<Hero>();
        List<Task> tasks = new List<Task>();
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
            return new Hero();
        }
        public void run()
        {
            for (int i = 0; i < blueHeros.Count; i++)
            {
                Hero hero = blueHeros[i];
                Task task = new Task(() => {
                    hero.run();
                });
                tasks.Add(task);
                task.Start();
            }
            for (int i = 0; i < redHeros.Count; i++)
            {
                Hero hero = redHeros[i];
                Task task = new Task(() => {
                    hero.run();
                });
                tasks.Add(task);
                task.Start();
            }
            for (int i = 0; i < tasks.Count; i++)
            {
                tasks[i].Wait();
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
        private double MAXHP;
        private double HP;
        private double ASD;//攻速
        private double Dead;
        private int heroLevel;
        public string heroName;

        Hero target;
        Map map;

        public Hero()
        {
            this.id = -1;
        }
        public Hero(Map map,string heroName,int level,int id)
        {
            this.heroName = heroName;
            heroLevel = level;
            this.id = id;
            this.map = map;
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
            Console.WriteLine(heroName+"run");
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
        public void delHP(int hp,Hero hero)
        {
            int delhp = hp * adr / 100;
            HP = HP - delhp;
            //message(heroName + "受到" + hero.heroName + "发动攻击，造成" +delhp + "点伤害!");
            message(heroName+ "生命值变为"+HP);
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
                Thread.Sleep(TimeSpan.FromSeconds(1 / ASD));
                //System.Threading.Thread.Sleep(100);
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
