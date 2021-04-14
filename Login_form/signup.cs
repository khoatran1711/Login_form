using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using word = Microsoft.Office.Interop.Word;
using System.IO;
namespace Login_form
{
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();

        }

      

       

        private void panel2_Click(object sender, EventArgs e)
        {
            Mydb mydb = new Mydb();
            mydb.openConnectionState();
            SqlCommand cmd = new SqlCommand(@"Select * from Login where username = @user", mydb.GetConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = txt_NewAccount.Text;
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0) MessageBox.Show("Da co tai khoan roi");
            else
            {
                if (txt_NewPass.Text == txt_Pass2.Text)
                {
                    account ne = new account();
                    if (ne.insertaccount(txt_NewAccount.Text, txt_NewPass.Text))
                    {
                        MessageBox.Show("Dang ky thanh cong!!");

                    }
                    else
                    {
                        MessageBox.Show("Xay ra loi! Thu lai sau!!");
                    }
                }
                else
                {
                    MessageBox.Show("Mat khau khong giong nhau");
                }
            }


        }

        private void panel3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            Mydb mydb = new Mydb();
            mydb.openConnectionState();
            SqlCommand cmd = new SqlCommand(@"Select * from Login where username = @user", mydb.GetConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = txt_NewAccount.Text;
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0) MessageBox.Show("Da co tai khoan roi");
            else
            {
                if (txt_NewPass.Text == txt_Pass2.Text)
                {
                    account ne = new account();
                    if (ne.insertaccount(txt_NewAccount.Text, txt_NewPass.Text))
                    {
                        MessageBox.Show("Dang ky thanh cong!!");

                    }
                    else
                    {
                        MessageBox.Show("Xay ra loi! Thu lai sau!!");
                    }
                }
                else
                {
                    MessageBox.Show("Mat khau khong giong nhau");
                }
            }
        }
    }
}
