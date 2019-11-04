using ElectronHTMlCSharp;
using System;
using System.Windows.Forms;

namespace ElectronHTMLCsharp
{
    class Program
    {
        public static void Main(string[] args)
        {
            var ser = new Services();
            ser.StartServer();
            RunElectron();
            Console.ReadKey();
        }
        public static void RunElectron()
        {
            var cmd = AppTools.Get("ElectronAppPath");
            if (cmd.IndexOf("|DataDirectory|") >= 0)
            {
                cmd = cmd.Replace("|DataDirectory|", Application.StartupPath);
            }
            var str = AppTools.RunCmd(cmd);
            Console.WriteLine(str);
        }
    }
}
