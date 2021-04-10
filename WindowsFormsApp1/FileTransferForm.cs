using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADB_Helper
{
    public partial class FileTransferForm : Form
    {
        public FileTransferForm()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Title = "选择文件…",
                Filter = "所有文件(*.*)|*.*"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
                textBox1.Text = dialog.FileName;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string v = "";
            if (radioButton1.Checked)
                v = CMD.Execute($"adb push {textBox1.Text} {textBox2.Text}");
            else if (radioButton2.Checked)
                v = CMD.Execute($"adb pull {textBox2.Text} {textBox1.Text}");
            MessageBox.Show(v);
        }
    }
}
