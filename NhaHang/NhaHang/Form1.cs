using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhaHang
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void txt_acc_login_MouseClick(object sender, MouseEventArgs e)
        {
            txt_acc_login.Text = "";
         
        }

        private void txt_pass_login_MouseClick(object sender, MouseEventArgs e)
        {
            txt_pass_login.Text = "";
            txt_pass_login.UseSystemPasswordChar = true;
        }
    }
}
