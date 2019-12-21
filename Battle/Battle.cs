using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Main
{
    public class Battle
    {
        public static Map map = new Map();
        static void Main()
        {
            map.run();
        }
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
        public static double Distance(Hero hero1,Hero hero2)
        {
            double distance = Math.Sqrt(Math.Pow(hero1.square.x-hero2.square.x,2)
                + Math.Pow(hero1.square.y - hero2.square.y, 2));
            return distance;
        }
    }
    public class Map
    {
        List<Hero> blueHeros = new List<Hero>();
        List<Hero> redHeros = new List<Hero>();
        List<Task> tasks = new List<Task>();
        List<Square> squares = new List<Square>();
        public Map()
        {
            for(int i = 0; i < 56; i++)
            {
                squares.Add(new Square(i));
            }
        }
        public void SetHeros(List<HeroInf> redHeroList, List<HeroInf> blueHeroList)
        {

        }
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
            for (int i = 0; i < heroList.Count; i++)
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
}
