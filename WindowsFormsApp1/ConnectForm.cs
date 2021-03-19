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
    public partial class ConnectForm : Form
    {
        public event setText SetTextValue;
        public ConnectForm()
        {
            InitializeComponent();
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SetTextValue(CMD.Execute("adb connect "+textBox2.Text+":"+textBox1.Text));
            Close();
        }

        public delegate void setText(string txt);

    }
}
