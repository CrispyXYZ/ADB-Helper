using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADB_Helper
{
    class CMD
    {
        public static string Execute(string command)
        {
            string output = ""; //输出字符串   
            if (command != null && !command.Equals(""))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",//设定需要执行的命令   
                    Arguments = "/C " + command,//“/C”表示执行完命令后马上退出   
                    UseShellExecute = false,//不使用系统外壳程序启动   
                    RedirectStandardInput = true,//重定向输入   
                    RedirectStandardOutput = true, //重定向输出   
                    StandardOutputEncoding = Encoding.UTF8,
                    StandardErrorEncoding = Encoding.UTF8,
                    RedirectStandardError = true,
                    CreateNoWindow = true//不创建窗口   
                };
                Process process = new Process
                {
                    StartInfo = startInfo
                };//创建进程对象   
                process.Start();
                output = process.StandardOutput.ReadToEnd();
                output += process.StandardError.ReadToEnd();
                process.Close();
            }
            return output;
        }
    }
}
