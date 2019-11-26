using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Main
{
    class LinkToClient:ReadSocket
    {
        private Task readDataTask;
        private CancellationTokenSource readDataCts = new CancellationTokenSource();
        private Task runCodeTask;
        private CancellationTokenSource runCodeCts = new CancellationTokenSource();
        private object acceptCodeListMe = new object();
        private List<String[]> acceptCodeList;
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



        public void readData(String data)
        {
            lock (acceptCodeListMe)
            {
                acceptCodeList.Add(data.Split(" "));
            }
        }
        private void runCode(string[] code)
        {
            switch (code[0])
            {
                case "exit":
                    readDataOff();
                    runAcceptCodeOff();
                    break;
            }
            Console.WriteLine("执行了一条命令："+code);
        }


        //线程操作
        private void readData()
        {
            readDataTask = new Task(() => {
                while (true)
                {
                    if (readDataCts.Token.IsCancellationRequested) break;
                    CsharpLinkWebSocket.ReadData(this);
                }
            });
            readDataTask.Start();
        }
        private void runAcceptCode()
        {
            runCodeTask = new Task(() => {
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
                    System.Threading.Thread.Sleep(500);
                }
            });
            runCodeTask.Start();
        }
        private void runAcceptCodeOff()
        {
            runCodeCts.Cancel();
        }
        private void readDataOff()
        {
            readDataCts.Cancel();
        }
    }
}
