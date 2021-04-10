using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADB_Helper
{
    public partial class RemoteCtrlForm : Form
    {
        private int x;
        private int y;
        private int n;
        public RemoteCtrlForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(n.ToString());
            CMD.Execute("adb shell /system/bin/screencap -p /sdcard/temp.png");
            CMD.Execute("adb pull /sdcard/temp.png \"D:\\Program Files\"");
            try {
                File.Move("D:\\Program Files\\temp.png", "D:\\Program Files\\temp" + n + ".png");
            }catch (FileNotFoundException) { }
            catch (IOException) { }
            try
            {
                pictureBox1.Load("D:\\Program Files\\temp" + n + ".png");
            }
            catch (FileNotFoundException) { }
            try
            {
                File.Delete("D:\\Program Files\\temp" + (n - 1) + ".png");
            }
            catch (IOException) { }
            n++;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(Image.FromFile(@"D:\Program Files\temp"+(n-1)+".png"));
            int pWidth = bitmap.Size.Width;
            int pHeight = bitmap.Size.Height;
            CMD.Execute("adb shell input tap " + x * pWidth / pictureBox1.Width + " " + y * pHeight / pictureBox1.Height);
            bitmap.Dispose();
            Thread.Sleep(500);
            button1_Click(null, null);
        }

        private void RemoteCtrlForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (pictureBox1 != null) pictureBox1.Dispose();
            CMD.Execute("del \"D:\\Program Files\\temp*.png\"");
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            x = e.Location.X;
            y = e.Location.Y;
            StatusLabel1.Text = x.ToString() + ", " + y.ToString();
        }
    }
}
