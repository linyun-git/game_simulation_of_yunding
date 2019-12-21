using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Main
{
    internal class LinkToClient
    {
        private Task readDataTask;//接受命令任务
        private Task sendComandTask;//发送命令任务

        private CancellationTokenSource readDataCts = new CancellationTokenSource();
        private CancellationTokenSource runCodeCts = new CancellationTokenSource();
        private CancellationTokenSource sendCommandCts = new CancellationTokenSource();


        private static List<String> sendComandList;//发送命令栈

        private static readonly object sendComandListlock = new object();//sendComandList的lock

        private CsharpLinkWebSocket CsharpLinkWebSocket;

        private static readonly string ip = "127.0.0.1";
        private static readonly int port = 4430;



        public LinkToClient()
        {
            sendComandList = new List<string>();
            CsharpLinkWebSocket = new CsharpLinkWebSocket(ip, port);
            SendCommand();
        }

        //公开函数
        public static void SendCommand(string command)
        {
            lock (sendComandListlock)
            {
                sendComandList.Add(command);
            }
        }
        public void ReadData(Action<string> action)
        {
            readData(action);
            readDataTask.Start();
            readDataTask.Wait();
        }
        public void TaskBreak()
        {
            readDataCts.Cancel();
            sendCommandCts.Cancel();
        }
        public static void Error(string error)
        {
            SendCommand("error " + error);
        }

        //接收数据
        private void readData(Action<string> action)
        {
            readDataTask = new Task(() =>
            {
                while (true)
                {
                    if (readDataCts.Token.IsCancellationRequested) break;
                    string code = CsharpLinkWebSocket.ReadData();
                    new Task(() => {
                        action(code);
                    }).Start();
                }
            });
        }

        //发送数据
        private void SendCommand()
        {
            sendComandTask = new Task(()=> {
                while (true)
                {
                    if (sendCommandCts.Token.IsCancellationRequested) break;
                    if (sendComandList.Count > 0)
                    {
                        lock (sendComandListlock)
                        {
                            CsharpLinkWebSocket.SendData(sendComandList[0]);
                            sendComandList.RemoveAt(0);
                        }
                    }
                    Thread.Sleep(20);
                }
            });
            sendComandTask.Start();
        }

    }
}
