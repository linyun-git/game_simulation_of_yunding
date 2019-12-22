using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main
{
    class Main
    {
        private List<HeroInf> redHeroList = new List<HeroInf>();
        private List<HeroInf> blueHeroList = new List<HeroInf>();
        private LinkToClient LinkToClient;
        private int maxNum = 10;
        public Main()
        {
            LinkToClient = new LinkToClient();
            Task runCodeTask = new Task(() => {
                LinkToClient.ReadData(RunCode);
            });
            runCodeTask.Start();
            runCodeTask.Wait();
        }

        ///<summary>执行一条命令</summary>
        ///<param name="code">传入的命令</param>
        private void RunCode(string codes)
        {
            string[] code = codes.Split(" ");
            switch (code[0])
            {
                case "end":
                    end();
                    break;
                case "init":
                    init();
                    break;
                case "exit":
                    exit();
                    break;
                case "reset":
                    reset();
                    break;
                case "setHeroPlace":
                    setHeroPlace(code);
                    break;
                case "changeHeroLevel":
                    changeHeroLevel(code);
                    break;
                case "start":
                    start();
                    break;
                case "ready":
                    ready();
                    break;
                case "delHero":
                    delHero(code);
                    break;
            }
            Console.WriteLine("执行了一条命令：" + string.Join("_", code));
        }
        //命令操作
        private void end()
        {
            Battle.map.stop();
        }
        private void ready()
        {
            Battle.map.SetHeros(blueHeroList, redHeroList);
        }
        private void start()
        {
            Battle.map.run();
        }
        private void exit()
        {
            LinkToClient.TaskBreak();
        }
        private void init()
        {
            string heros = string.Join(" ", Program.heros);
            LinkToClient.SendCommand("init " + heros);
        }
        private void reset()
        {
            blueHeroList.Clear();
            LinkToClient.SendCommand("setHeroNum blueNum " + blueHeroList.Count.ToString());
            redHeroList.Clear();
            LinkToClient.SendCommand("setHeroNum redNum " + redHeroList.Count.ToString());
        }
        private void setHeroPlace(string[] code)
        {
            try
            {
                HeroInf hero;
                int heroSquareID = Int32.Parse(code[1]);
                List<HeroInf> heroList;
                string heroColor;
                if (heroSquareID <= 27)
                {
                    heroList = blueHeroList;
                    heroColor = "blue";
                }
                else
                {
                    heroList = redHeroList;
                    heroColor = "red";
                }
                if (heroList.Any(hero => hero.IdEquals(heroSquareID)))
                {
                    hero = heroList.FirstOrDefault(hero => hero.IdEquals(heroSquareID));
                    heroList.Remove(hero);
                    hero = new HeroInf(code[2], heroSquareID);
                    heroList.Add(hero);
                    LinkToClient.SendCommand("setHeroNum " + heroColor + "Num " + heroList.Count.ToString());
                    LinkToClient.SendCommand("setHeroInf " + heroSquareID + " " + hero.GetHeroInf());
                }
                else if (heroList.Count < maxNum)
                {
                    hero = new HeroInf(code[2], heroSquareID);
                    heroList.Add(hero);
                    LinkToClient.SendCommand("setHeroNum " + heroColor + "Num " + heroList.Count.ToString());
                    LinkToClient.SendCommand("setHeroInf " + heroSquareID + " " + hero.GetHeroInf());
                }
                else if (heroList.Count == maxNum)
                {
                    LinkToClient.SendCommand("setInit " + heroSquareID);
                    LinkToClient.Error("已达上限");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        private void changeHeroLevel(string[] code)
        {
            HeroInf hero;
            try
            {
                int heroSquareID = Int32.Parse(code[1]);
                if (heroSquareID <= 27)
                {
                    hero = blueHeroList.FirstOrDefault(hero => hero.IdEquals(heroSquareID));
                }
                else
                {
                    hero = redHeroList.FirstOrDefault(hero => hero.IdEquals(heroSquareID));
                }
                hero.ChangeLevel();
                LinkToClient.SendCommand("setHeroInf " + heroSquareID + " " + hero.GetHeroInf());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        private void delHero(string[] codes)
        {
            try
            {
                int heroSquareID = int.Parse(codes[1]);
                if (heroSquareID <= 27)
                {
                    HeroInf heroInf = blueHeroList.FirstOrDefault(hero => hero.IdEquals(heroSquareID));
                    blueHeroList.Remove(heroInf);
                    LinkToClient.SendCommand("setHeroNum blueNum " + blueHeroList.Count);
                }
                else
                {
                    HeroInf heroInf = redHeroList.FirstOrDefault(hero => hero.IdEquals(heroSquareID));
                    redHeroList.Remove(heroInf);
                    LinkToClient.SendCommand("setHeroNum redNum " + redHeroList.Count);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
