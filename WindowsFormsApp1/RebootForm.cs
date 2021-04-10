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
    public partial class RebootForm : Form
    {
        public RebootForm()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                groupBox1.Visible = true;
            }
            else
            {
                groupBox1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string c;
            if (radioButton1.Checked)
            {
                c = "adb reboot";
            }
            else
            {
                switch (listBox1.SelectedIndex)
                {
                    case 0:
                        c = "adb reboot bootloader";
                        break;
                    case 1:
                        c = "adb reboot recovery";
                        break;
                    case 2:
                        c = "adb reboot sideload";
                        break;
                    case 3:
                        c = "adb reboot sideload-auto-reboot";
                        break;
                    default:
                        c = "";
                        break;
                }
            }
            CMD.Execute(c);
            Close();
        }
    }
}
