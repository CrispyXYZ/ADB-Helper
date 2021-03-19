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
            cf.SetTextValue += new ConnectForm.setText(cf_SetTextValue);
            cf.Show();
        }

        void cf_SetTextValue(string txt)
        {
            TextBox1.Text = txt;
        }
    }
}
