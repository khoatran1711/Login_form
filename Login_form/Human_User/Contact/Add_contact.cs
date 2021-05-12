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
using System.IO;


namespace Login_form.Human_User.Contact
{
    public partial class Add_contact : Form
    {
        public Add_contact()
        {
            InitializeComponent();
            getGroup();
        }

        DataTable group = new DataTable();
      public void getGroup()
        {
            string connection = "Data Source=DESKTOP-I15DKS7;Initial Catalog=Login;Integrated Security=True";

            string strSQL = @"select * from Group1";
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = connection;
            try
            {
                Con.Open();
                SqlDataAdapter da = new SqlDataAdapter(strSQL, Con);
                DataSet ds = new DataSet("Group");
                da.Fill(ds, "Group");
                DataTable dt = ds.Tables["Group"];
                cbb_group.DataSource = dt;
                cbb_group.DisplayMember = "name";
                group = dt;
                cbb_group.ValueMember = "id";
                txt_user_id.Text = group.Rows[cbb_group.SelectedIndex][2].ToString();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                if (Con.State != ConnectionState.Closed)
                {
                    Con.Close();
                }
            }
            finally
            {
                Con.Dispose();
            }
        }

        private void cbb_group_SelectedIndexChanged(object sender, EventArgs e)
        {
            group = (DataTable)cbb_group.DataSource;
            txt_user_id.Text = group.Rows[cbb_group.SelectedIndex][2].ToString();
        }

        public bool check()
        {
            if ((txt_ID.Text.Trim() == "")
                 || (txt_fname.Text.Trim() == "")
                 || (txt_lname.Text.Trim() == "")
                 || (txt_phone.Text.Trim() == "")
                 || (txt_mail.Text.Trim() == "")
                 || (txt_addr.Text.Trim() == "")
                 || (pic_box.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btn_choose_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg,*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pic_box.Image = Image.FromFile(opf.FileName);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (check())
            {
                Contact a = new Contact();
                MemoryStream pic = new MemoryStream();
                pic_box.Image.Save(pic, pic_box.Image.RawFormat);
                try
                {
                    if (a.add(txt_ID.Text, txt_fname.Text, txt_lname.Text, cbb_group.SelectedValue.ToString(), txt_phone.Text, txt_mail.Text, txt_addr.Text, pic, txt_user_id.Text))
                    {
                        MessageBox.Show("New contact added successfully!", "Add contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("There was some errors, please try again!", "Add contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
         
                }
                

            }
            else
            {
                MessageBox.Show("Something is missing! \nPlease try again!", "Add contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
