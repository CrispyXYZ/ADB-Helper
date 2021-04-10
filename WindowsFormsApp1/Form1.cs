using System;
using System.Diagnostics;
using System.Text;
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
            TextBox1.Text = CMD.Execute("adb version");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = CMD.Execute("adb devices");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            TextBox1.Text = CMD.Execute("adb start-server");
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            TextBox1.Text = CMD.Execute("adb kill-server");
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            ConnectForm cf = new ConnectForm();
            cf.SetTextValue += new ConnectForm.setText(Cf_SetTextValue);
            cf.Show();
        }

        void Cf_SetTextValue(string txt)
        {
            TextBox1.Text = txt;
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            new FileTransferForm().Show();
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            new RebootForm().Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",//设定需要执行的命令   
                    Arguments = "/C adb shell",// /C表示执行完命令后马上退出   
                    //UseShellExecute = false,//不使用系统外壳程序启动   
                    //StandardOutputEncoding = Encoding.UTF8,
                    //StandardErrorEncoding = Encoding.UTF8,
                }

            };
            process.Start();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new RemoteCtrlForm().Show();
        }
    }
}
