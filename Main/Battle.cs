using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main
{
    public class Battle
    {
        public static Map map = new Map();
    }
    public class Square
    {
        public const string heroOn = "hasHero";
        public const string heroNone = "notHasHero";
        public readonly double x;
        public readonly double y;
        public readonly int squareId;
        public Hero hero;
        public string hasHero = heroNone;
        public Square(int id)
        {
            squareId = id;
            int x = id % 7;
            int y = id / 7;
            double MapX, MapY;
            if (y % 2 == 0)
            {
                MapX = x;
                MapY = y * Math.Sqrt(3);
            }
            else
            {
                MapX = x + (1 / 2);
                MapY = (y * Math.Sqrt(3)) + (Math.Sqrt(3) / 2);
            }
            this.x = MapX;
            this.y = MapY;
        }
        public void SetHero(Hero hero)
        {
            this.hero = hero;
            this.hero.SetSquare(this);
        }
        public static double Distance(Hero hero1,Hero hero2)
        {
            double distance = Math.Sqrt(Math.Pow(hero1.square.x-hero2.square.x,2)
                + Math.Pow(hero1.square.y - hero2.square.y, 2));
            return distance;
        }
        public Hero GetTarget()
        {
            Hero target;
            List<Hero> targets;
            if(hero.color == Hero.Blue)
            {
                targets = Battle.map.redHeros;
            }
            else
            {
                targets = Battle.map.blueHeros;
            }
            if (targets.Any(hero => hero.isLive()))
            {
                int i = 0;
                target = targets[0];
                for (; i < targets.Count; i++)
                {
                    if (targets[i].isLive())
                    {
                        target = targets[i];
                        break;
                    }
                }
                for (;i<targets.Count;i++)
                {
                    if ((Distance(hero, targets[i]) < Distance(hero, target)) && targets[i].isLive())
                    {
                        target = targets[i];
                    }
                }
                return target;
            }
            return new Hero();
        }
    }
    public class Map
    {
        public List<Hero> blueHeros = new List<Hero>();
        public List<Hero> redHeros = new List<Hero>();
        List<Task> tasks = new List<Task>();
        List<Square> squares = new List<Square>();
        public Map()
        {
            for(int i = 0; i < 56; i++)
            {
                squares.Add(new Square(i));
            }
        }
        public void SetHeros(List<HeroInf> blueHeroList, List<HeroInf> redHeroList)
        {
            blueHeros.Clear();
            redHeros.Clear();
            for(int i = 0; i < blueHeroList.Count; i++)
            {
                HeroInf heroInf = blueHeroList[i];
                Hero hero = heroInf.ToHero();
                blueHeros.Add(hero);
                squares[heroInf.GetId()].SetHero(hero);
            }
            for (int i = 0; i < redHeroList.Count; i++)
            {
                HeroInf heroInf = redHeroList[i];
                Hero hero = heroInf.ToHero();
                redHeros.Add(hero);
                squares[heroInf.GetId()].SetHero(hero);
            }
        }
        public void run()
        {
            tasks.Clear();
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
            result();
        }
        public void stop()
        {
            for(int i = 0; i < blueHeros.Count; i++)
            {
                blueHeros[i].stop();
            }
            for (int i = 0; i < redHeros.Count; i++)
            {
                redHeros[i].stop();
            }
        }
        private void result()
        {
            int damage = 0;
            string name = "未知";
            string color = "green";
            for(int i = 0; i < blueHeros.Count; i++)
            {
                if (blueHeros[i].totaldamage > damage)
                {
                    damage = blueHeros[i].totaldamage;
                    name = blueHeros[i].heroName;
                }
            }
            for (int i = 0; i < redHeros.Count; i++)
            {
                if (redHeros[i].totaldamage > damage)
                {
                    damage = redHeros[i].totaldamage;
                    name = redHeros[i].heroName;
                }
            }
            if (!blueHeros.Any(hero => hero.isLive()))
            {
                Console.WriteLine("红方胜利!");
                color = "red";
            }
            else if(!redHeros.Any(hero => hero.isLive()))
            {
                Console.WriteLine("蓝方胜利!");
                color = "blue";
            }
            LinkToClient.SendCommand("result "+color+" " + name + " " + damage);
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
}