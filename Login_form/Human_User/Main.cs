using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Login_form.Human_User
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            getInfo();
            getGroup();
            load();

        }
        DataTable contact = new DataTable();
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

        public void getGroup ()
        {
            string connection = "Data Source=DESKTOP-I15DKS7;Initial Catalog=Login;Integrated Security=True";

            string strSQL = @"select * from Group1" ;
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = connection;
            try
            {
                Con.Open();
                SqlDataAdapter da = new SqlDataAdapter(strSQL, Con);
                DataSet ds = new DataSet("Group");
                da.Fill(ds, "Group");
                DataTable dt = ds.Tables["Group"];

                cbb_Group_Edit.DataSource = dt;
                cbb_Remove_group.DataSource = dt;
                cbb_Group_Edit.ValueMember = "id";
                cbb_Remove_group.ValueMember = "id";
                cbb_Group_Edit.DisplayMember = "name";
                cbb_Remove_group.DisplayMember = "name";
                
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

        public void getInfo ()
        {
            Mydb db = new Mydb();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
           
            SqlCommand command = new SqlCommand("SELECT * FROM Human WHERE ID = "+Globals.GlobalUserID.ToString(), db.GetConnection);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count>0)
            {
                byte[] pic = (byte[])table.Rows[0]["fig"];
                MemoryStream picture = new MemoryStream(pic);
                pictureBox1.Image = Image.FromStream(picture);
                lb_Name.Text = "Welcome, " + table.Rows[0]["f_name"].ToString() + " " + table.Rows[0]["l_name"];


            }
        }

        private void btn_add_contact_Click(object sender, EventArgs e)
        {
            Human_User.Contact.Add_contact a = new Contact.Add_contact();
            a.ShowDialog();
        }

        private void btn_edit_contact_Click(object sender, EventArgs e)
        {
            Human_User.Contact.Edit_contact a = new Contact.Edit_contact();
            a.ShowDialog();
        }

        private void btn_select_contact_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txt_contact_ID.Text);
                int i;
                for (i=0;i<contact.Rows.Count;i++)
                {
                    if (id == Convert.ToInt32(contact.Rows[i][0])) break;
                }
                if (i < contact.Rows.Count)
                {
                    
                    MessageBox.Show("Selected contact successfully!", "Select contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btn_remove_contact.Enabled = true;
                }
                else
                {
                   
                    MessageBox.Show("Cannot find this ID \n Please try again!", "Select contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btn_remove_contact.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_remove_contact_Click(object sender, EventArgs e)
        {
            try
            {
                Contact.Contact a = new Contact.Contact();
                if(a.remove(txt_contact_ID.Text))
                {
                    MessageBox.Show(" Contact removed successfully!", "Remove contact", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load();
                    btn_remove_contact.Enabled = false;
                }
                else
                {
                    MessageBox.Show("There was some errors, please try again!", "Remove contact", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_show_all_Click(object sender, EventArgs e)
        {
            Contact.Show_all a = new Contact.Show_all();
            a.ShowDialog();
        }

        public bool check ()
        {
            if ((txt_id.Text.Trim() == "")
               || (txt_Groupname.Text.Trim() == "")
               || (txt_groupID.Text.Trim() == ""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btn_add_group_Click(object sender, EventArgs e)
        {
            try
            {
                if (check())
                {
                    Group a = new Group();
                    if (a.add(txt_id.Text,txt_Groupname.Text,txt_groupID.Text))
                    {
                        MessageBox.Show("New group added successfully!", "Add group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getGroup();
                    }
                    else
                    {
                        MessageBox.Show("There was some errors, please try again!", "Add group", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("There was something missing!\nPlease try again!", "Add group", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        public bool check_edit()
        {
            if (txt_new_group_name.Text.Trim() == "")
              
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btn_edit_group_Click(object sender, EventArgs e)
        {
            try
            {
                    Group a = new Group();
                  if (check_edit())
                    {
                    if (a.edit(cbb_Group_Edit.SelectedValue.ToString(), txt_new_group_name.Text))
                    {
                        MessageBox.Show("Changed name successfully!", "Edit group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getGroup();
                        txt_new_group_name.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("There was some errors, please try again!", "Edit group", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }



                   }
                  else
                {
                    MessageBox.Show("Please enter new name for this group!", "Edit group", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Khong cho xoa group co contact
        public bool check_remove (int id)
        { 
            for (int i=0;i<contact.Rows.Count;i++)
            {
                if (id == Convert.ToInt32(contact.Rows[i][3])) return false;
            }
            return true;
        }

        private void btn_remove_group_Click(object sender, EventArgs e)
        {
            try
            {
                Group a = new Group();
                if (check_remove(Convert.ToInt32(cbb_Remove_group.SelectedValue)))
                {
                    if (a.remove(cbb_Remove_group.SelectedValue.ToString()))
                    {
                        MessageBox.Show("Remove group successfully!", "Remove group", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getGroup();
                       
                    }
                    else
                    {
                        MessageBox.Show("There was some errors, please try again!", "Remove group", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("This group has contacts \nRemove failed!", "Remove group", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
