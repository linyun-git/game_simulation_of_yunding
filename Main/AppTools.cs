using System.Configuration;
using System.Diagnostics;

namespace ElectronHTMLCsharp
{
    public class AppTools
    {
        public static string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        ///     执行CMD语句
        /// </summary>
        /// <param name="param">要执行的CMD命令参数</param>
        public static string RunCmd(string param)
        {

            var pro = new Process
            {
                StartInfo =
                {
                    CreateNoWindow = true, FileName ="cmd.exe", UseShellExecute = false, RedirectStandardError = true,
                    RedirectStandardInput = true,RedirectStandardOutput = true
                }
            };
            pro.Start();
            pro.StandardInput.WriteLine(param);
            pro.StandardInput.WriteLine("exit");
            var outStr = pro.StandardOutput.ReadToEnd();
            pro.Close();
            return outStr;
        }
    }
}
