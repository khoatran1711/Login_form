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
    public partial class Edit_contact : Form
    {
        public Edit_contact()
        {
            InitializeComponent();
            load();
            getGroup();
        }
        DataTable group = new DataTable();
        DataTable contact = new DataTable();

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
                cbb_group.ValueMember = "id";
                group = dt;

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
            public void load()
          {
            string connection = "Data Source=DESKTOP-I15DKS7;Initial Catalog=Login;Integrated Security=True";

            string strSQL = @"select * from mycontact";
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = connection;
            try
            {
                Con.Open();
                SqlDataAdapter da = new SqlDataAdapter(strSQL, Con);
                DataSet ds = new DataSet("mycontact");
                da.Fill(ds, "mycontact");
                DataTable dt = ds.Tables["mycontact"];
                contact = dt;
 

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

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                int ID = Convert.ToInt32(txt_ID.Text);
                int i ;
                for ( i = 0; i < contact.Rows.Count; i++)
                {
                    if (Convert.ToInt32(contact.Rows[i][0]) == ID)
                    {
                        txt_fname.Text = contact.Rows[i][1].ToString();
                        txt_lname.Text = contact.Rows[i][2].ToString();
                        cbb_group.Text = group.Rows[Convert.ToInt32(contact.Rows[i][3]) - 1][1].ToString();
                        txt_phone.Text = contact.Rows[i][4].ToString();
                        txt_mail.Text = contact.Rows[i][5].ToString();
                        txt_addr.Text = contact.Rows[i][6].ToString();
                        byte[] pic;
                        pic = (byte[])contact.Rows[i][7];
                        MemoryStream picture = new MemoryStream(pic);
                        pic_box.Image = System.Drawing.Image.FromStream(picture);
                        txt_user_id.Text = contact.Rows[i][8].ToString();
                        break;
                    }

                }
                if (i==contact.Rows.Count) MessageBox.Show("Cannot find this ID\n please try again!", "Select contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (check())
                {
                    Contact a = new Contact();
                    MemoryStream pic = new MemoryStream();
                    pic_box.Image.Save(pic, pic_box.Image.RawFormat);
                    if (a.edit(txt_ID.Text, txt_fname.Text, txt_lname.Text, cbb_group.SelectedValue.ToString(), txt_phone.Text, txt_mail.Text, txt_addr.Text, pic, txt_user_id.Text))
                        {
                            MessageBox.Show("New contact added successfully!", "Add contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("There was some errors, please try again!", "Add contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }

                else
                {
                    MessageBox.Show("Something is missing! \nPlease try again!", "Add contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);

            }
        }
    }
}

