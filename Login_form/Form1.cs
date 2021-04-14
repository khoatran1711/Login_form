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
namespace Login_form
{
    public partial class Khoafr : Form
    {
        
        public Khoafr()
        {
            InitializeComponent();
            Account_txt.Text = "Enter your account";
            Password_txt.Text = "Enter your passord";
            Account_txt.ForeColor = Color.Gray;
            Password_txt.ForeColor = Color.Gray;

        }

        private void Account_txt_Click(object sender, EventArgs e)
        {
            Account_txt.Text = "";
        }

        private void Password_txt_Click(object sender, EventArgs e)
        {
            Password_txt.Text = "";
            Password_txt.UseSystemPasswordChar = true;
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            Mydb db = new Mydb();

            SqlDataAdapter adapter = new SqlDataAdapter();

            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM Login WHERE username = @username AND password= @password", db.GetConnection);

            command.Parameters.Add("@username", SqlDbType.VarChar).Value = Account_txt.Text;
            command.Parameters.Add("@password", SqlDbType.VarChar).Value = Password_txt.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count>0)
            {
                MessageBox.Show("Login successfully");
                Menu menu = new Menu();
                //this.Hide();
                menu.ShowDialog();
                this.Close();
               
            }
            else
            {
                MessageBox.Show("Account or Password is wrong. Try Again!!");
            }

        }

        private void sign_up_Click(object sender, EventArgs e)
        {
            signup a = new signup();
            a.Show();
        }
    }
}
