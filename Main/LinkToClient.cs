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
        private void runCode(string[] code)
        {
            switch (code[0])
            {
                case "exit":
                    exit();
                    break;
                case "setHeroPlace":
                    setHeroPlace(code);
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
        private void setHeroPlace(string[] code)
        {
            try
            {
                int heroSquareID = Int32.Parse(code[1]);
                List<Hero> heroList;
                string heroColor;
                if (heroSquareID < 27)
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
                    heroList.FirstOrDefault(hero => hero.heroSquareId == heroSquareID).heroName = code[2];
                }
                else
                {
                    Hero hero = new Hero();
                    hero.heroName = code[2];
                    hero.heroSquareId = heroSquareID;
                    heroList.Add(hero);
                }
                CsharpLinkWebSocket.SendData("setHeroNum "+heroColor+"Num "+heroList.Count.ToString());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
