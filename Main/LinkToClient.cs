using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Main
{
    class LinkToClient
    {
        private List<Hero> redHeroList = new List<Hero>();
        private List<Hero> blueHeroList = new List<Hero>();
        private Task readDataTask;
        private CancellationTokenSource readDataCts = new CancellationTokenSource();
        private Task runCodeTask;
        private CancellationTokenSource runCodeCts = new CancellationTokenSource();
        private object acceptCodeListMe = new object();
        private List<String[]> acceptCodeList;//接受命令栈
        private CsharpLinkWebSocket CsharpLinkWebSocket;
        public LinkToClient()
        {
            acceptCodeList = new List<string[]>();
            CsharpLinkWebSocket = new CsharpLinkWebSocket("127.0.0.1", 4430);
            readData();
            runAcceptCode();
            readDataTask.Wait();
            runCodeTask.Wait();
        }
        //每次接收到数据将数据放入接受命令栈
        private void readData(String data)
        {
            lock (acceptCodeListMe)
            {
                acceptCodeList.Add(data.Split(" "));
            }
        }


        //线程操作
        private void readData()
        {
            readDataTask = new Task(() =>
            {
                while (true)
                {
                    if (readDataCts.Token.IsCancellationRequested) break;
                    CsharpLinkWebSocket.ReadData(this.readData);
                }
            });
            readDataTask.Start();
        }
        private void runAcceptCode()
        {
            runCodeTask = new Task(() =>
            {
                while (true)
                {
                    if (runCodeCts.Token.IsCancellationRequested) break;
                    if (acceptCodeList.Count > 0)
                    {
                        runCode(acceptCodeList[0]);
                        lock (acceptCodeListMe)
                        {
                            acceptCodeList.RemoveAt(0);
                        }
                    }
                    System.Threading.Thread.Sleep(100);
                }
            });
            runCodeTask.Start();
        }

        ///<summary>执行一条命令</summary>
        ///<param name="code">传入的命令</param>
        private void runCode(string[] code)
        {
            switch (code[0])
            {
                case "init":
                    init();
                    break;
                case "exit":
                    exit();
                    break;
                case "setHeroPlace":
                    setHeroPlace(code);
                    break;
                case "changeHeroLevel":
                    changeHeroLevel(code);
                    break;
            }
            Console.WriteLine("执行了一条命令：" + string.Join("_", code));
        }
        private void runAcceptCodeOff()
        {
            runCodeCts.Cancel();
        }
        private void readDataOff()
        {
            readDataCts.Cancel();
        }

        //命令操作
        private void exit()
        {
            readDataOff();
            runAcceptCodeOff();
        }
        private void init()
        {
            string heros = string.Join(" ", Program.heros);
            CsharpLinkWebSocket.SendData("init "+heros);
        }
        private void setHeroPlace(string[] code)
        {
            try
            {
                Hero hero;
                int heroSquareID = Int32.Parse(code[1]);
                List<Hero> heroList;
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
                if(heroList.Any(hero => hero.heroSquareId == heroSquareID))
                {
                    hero = heroList.FirstOrDefault(hero => hero.heroSquareId == heroSquareID);
                    hero.heroName = code[2];
                }
                else
                {
                    hero = new Hero();
                    hero.heroName = code[2];
                    hero.heroSquareId = heroSquareID;
                    heroList.Add(hero);
                }
                CsharpLinkWebSocket.SendData("setHeroNum "+heroColor+"Num "+heroList.Count.ToString());
                CsharpLinkWebSocket.SendData(hero.setHeroInf());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        private void changeHeroLevel(string[] code)
        {
            Hero hero;
            try
            {
                int heroSquareID = Int32.Parse(code[1]);
                if (heroSquareID <= 27)
                {
                    hero = blueHeroList.FirstOrDefault(hero => hero.heroSquareId == heroSquareID);
                }
                else
                {
                    hero = redHeroList.FirstOrDefault(hero => hero.heroSquareId == heroSquareID);
                }
                switch (hero.heroLevel)
                {
                    case 1:
                        hero.heroLevel = 2;
                        break;
                    case 2:
                        hero.heroLevel = 3;
                        break;
                    case 3:
                        hero.heroLevel = 1;
                        break;
                }
                CsharpLinkWebSocket.SendData("setHeroLevel " + heroSquareID + " " + hero.heroLevel);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
