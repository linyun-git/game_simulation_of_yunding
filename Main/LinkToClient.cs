using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Main
{
    class LinkToClient
    {
        private List<HeroInf> redHeroList = new List<HeroInf>();
        private List<HeroInf> blueHeroList = new List<HeroInf>();
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
                case "reset":
                    reset();
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
        private void reset()
        {
            blueHeroList.Clear();
            CsharpLinkWebSocket.SendData("setHeroNum blueNum " + blueHeroList.Count.ToString());
            redHeroList.Clear();
            CsharpLinkWebSocket.SendData("setHeroNum redNum " + redHeroList.Count.ToString());
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
                if(heroList.Any(hero => hero.idEquals(heroSquareID)))
                {
                    hero = heroList.FirstOrDefault(hero => hero.idEquals(heroSquareID));
                    hero = new HeroInf(code[2],heroSquareID);
                }
                else
                {
                    hero = new HeroInf(code[2], heroSquareID);
                    heroList.Add(hero);
                }
                CsharpLinkWebSocket.SendData("setHeroNum "+heroColor+"Num "+heroList.Count.ToString());
                CsharpLinkWebSocket.SendData("setHeroInf "+heroSquareID+" "+hero.getHeroInf());
            }
            catch(Exception e)
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
                    hero = blueHeroList.FirstOrDefault(hero => hero.idEquals(heroSquareID));
                }
                else
                {
                    hero = redHeroList.FirstOrDefault(hero => hero.idEquals(heroSquareID));
                }
                hero.changeLevel();
                CsharpLinkWebSocket.SendData("setHeroInf " + heroSquareID + " " + hero.getHeroInf());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        //执行
        private Boolean addHero(HeroInf hero,List<HeroInf> heroList)
        {
            return false;
        }
    }
}
