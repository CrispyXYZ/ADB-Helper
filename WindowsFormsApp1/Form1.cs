using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace ADB_Helper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string ret = Execute("adb version");
            Form formRet = new Form
            {
                Text = this.Text,
                Size = this.Size
            };
            Label lbl = new Label
            {
                Size = formRet.Size,
                Text = ret
            };
            formRet.Controls.Add(lbl);
			formRet.Show();
        }

		/// <summary>   
		/// 执行DOS命令，返回DOS命令的输出   
		/// </summary>   
		/// <param name="command">dos命令</param>   
		/// <returns>返回DOS命令的输出</returns>   
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
                    CreateNoWindow = true//不创建窗口   
                };
                Process process = new Process
                {
                    StartInfo = startInfo
                };//创建进程对象   
                process.Start();
				output = process.StandardOutput.ReadToEnd();
				process.Close();
			}
			return output;
		}
	}
}
