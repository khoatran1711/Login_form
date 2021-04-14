using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Drawing.Imaging;

namespace Login_form
{
    public partial class Manage : Form
    {
        public Manage()
        {
            InitializeComponent();
            ra_btn_all.Checked = true;
            List_All();
        }

        void List_All ()
        {
            string connection = "Data Source=DESKTOP-I15DKS7;Initial Catalog=Student;Integrated Security=True";
            string strSQL = @"select * from stu ";
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = connection;
            try
            {
                Con.Open();


                SqlDataAdapter da = new SqlDataAdapter(strSQL, Con);

                DataSet ds = new DataSet("Student");

                da.Fill(ds, "Student");
                DataTable dt = ds.Tables["Student"];

                list.DataSource = dt;
                Total.Text = Convert.ToString(dt.Rows.Count);
                list.Columns[0].Width = 30;
                DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                picCol = (DataGridViewImageColumn)list.Columns[7];
                picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                Con.Close();
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

        bool Verify()
        {
            if ((txt_firstname.Text.Trim() == "")
                || (txt_lastname.Text.Trim() == "")
                || (txt_Adr.Text.Trim() == "")
                || (txt_phone.Text.Trim() == "")
                || (pic_box.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

       

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            int id = Convert.ToInt32(txt_ID.Text);
            string fname = txt_firstname.Text;
            string lname = txt_lastname.Text;
            DateTime bdate = dt_brt.Value;
            string phone = txt_phone.Text;
            string adress = txt_Adr.Text;
            string gender = "Other";
          
            if (ra_btn_female.Checked)
            {
                gender = "Female";
            }

            if (ra_btn_Male.Checked)
            {
                gender = "Male";
            }

            MemoryStream pic = new MemoryStream();
            int born_year = dt_brt.Value.Year;
            int this_year = DateTime.Now.Year;
            if (((this_year - born_year) < 10) || ((this_year - born_year) > 100))
            {
                MessageBox.Show("The student's age must be between 10 and 100 years old", "Invalid Date of birth", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (Verify())
            {
                pic_box.Image.Save(pic, pic_box.Image.RawFormat);
                if (student.insertStudent(id, fname, lname, bdate, gender, phone, adress, pic))
                {
                    MessageBox.Show("New student added successfully!", "Add student", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Error!", "Add student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty fields", "Add student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_ID.Text = list.CurrentRow.Cells[0].Value.ToString();
            txt_firstname.Text = list.CurrentRow.Cells[1].Value.ToString();
            txt_lastname.Text = list.CurrentRow.Cells[2].Value.ToString();
            dt_brt.Value = (DateTime)list.CurrentRow.Cells[3].Value;
            if (this.list.CurrentRow.Cells[4].Value.ToString() == "Male") ra_btn_Male.Checked = true;
            if (this.list.CurrentRow.Cells[4].Value.ToString() == "Female") ra_btn_female.Checked = true;
            if (this.list.CurrentRow.Cells[4].Value.ToString() == "Other") ra_btn_other.Checked = true;
            txt_phone.Text = this.list.CurrentRow.Cells[5].Value.ToString();
            txt_Adr.Text = this.list.CurrentRow.Cells[6].Value.ToString();
            byte[] pic = (byte[])this.list.CurrentRow.Cells[7].Value;
            MemoryStream ms = new MemoryStream(pic);
            txt_ID.ReadOnly = true;
            pic_box.Image = Image.FromStream(ms);
        }



        private void btn_refresh_Click(object sender, EventArgs e)
        {
            List_All();
        }

        private void btn_add_picture_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg,*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pic_box.Image = Image.FromFile(opf.FileName);
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (ra_btn_all.Checked) List_All();
            else {
                string connection = "Data Source=DESKTOP-I15DKS7;Initial Catalog=Student;Integrated Security=True";

                string fin = txt_find.Text;
                string table = "fname";
                if (ra_btn_ID.Checked) table = "id";
                if (ra_btn_lname.Checked) table = "lname";
                string strSQL = @"select * from stu where " + table + " like '%" + fin + "%'";

                SqlConnection Con = new SqlConnection();
                Con.ConnectionString = connection;
                //  SqlCommand cmd = new SqlCommand(strSQL, Con);


                try
                {
                    Con.Open();


                    SqlDataAdapter da = new SqlDataAdapter(strSQL, Con);

                    DataSet ds = new DataSet("Student");

                    da.Fill(ds, "Student");
                    DataTable dt = ds.Tables["Student"];

                    list.DataSource = dt;
                    
                    list.Columns[0].Width = 30;
                    DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                    picCol = (DataGridViewImageColumn)list.Columns[7];
                    picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    Total.Text = Convert.ToString(dt.Rows.Count);
                    Con.Close();
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
            
            
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            Student re = new Student();
            try
            {
                int stid = Convert.ToInt32(txt_ID.Text);
                if ((MessageBox.Show("Are you sure you want to delete this student?", "Delete student", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    if (re.RemoveStudent(stid))
                    {
                        MessageBox.Show("Student Deleted", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //clear feilds
                        //this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Student can not be deleted", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please enter a valid ID", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Student ne = new Student();
            int ID = Convert.ToInt32(txt_ID.Text);
            string fname = txt_firstname.Text;
            string lname = txt_lastname.Text;
            string phone = txt_phone.Text;
            string address = txt_Adr.Text;
            string gender = "";
            if (ra_btn_other.Checked)
            {
                gender = "Other";
            }
            if (ra_btn_female.Checked)
            {
                gender = "Female";
            }

            if (ra_btn_Male.Checked)
            {
                gender = "Male";
            }
            MemoryStream pic = new MemoryStream();
            pic_box.Image.Save(pic, pic_box.Image.RawFormat);
            ne.UpdateStudent(ID, fname, lname, dt_brt.Value, gender, phone, address, pic);
            MessageBox.Show("Edit successfully");
        }
    }
    
}
