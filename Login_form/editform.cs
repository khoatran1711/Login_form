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

namespace Login_form
{
    public partial class editform : Form
    {
        public editform()
        {
            InitializeComponent();
            
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Student ne = new Student();
            int ID = Convert.ToInt32(txt_ID.Text);
            string fname = txt_firstname.Text;
            string lname = txt_lastname.Text;
            string phone = txt_phone.Text;
            string address = txt_address.Text;
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
            this.Close();

        }

        private void btn_changepic_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg,*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pic_box.Image = Image.FromFile(opf.FileName);
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
                        this.Close();
                        
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

        private void btn_Find_Click(object sender, EventArgs e)
        {
            string connection = "Data Source=DESKTOP-I15DKS7;Initial Catalog=Student;Integrated Security=True";
   
            string strSQL = @"select * from stu where id = "+txt_Find_ID.Text;

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
                
                dataGridView1.DataSource = dt;
                txt_ID.Text= dataGridView1.Rows[0].Cells[0].Value.ToString();
                txt_firstname.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                txt_lastname.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
                dt_brt.Value = Convert.ToDateTime(dataGridView1.Rows[0].Cells[3].Value);
                string gender = dataGridView1.Rows[0].Cells[4].Value.ToString();
                if (gender == "Other") ra_btn_other.Checked = true;
                if (gender == "Male") ra_btn_Male.Checked = true;
                if (gender == "Female") ra_btn_female.Checked = true;
                txt_phone.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();
                txt_address.Text = dataGridView1.Rows[0].Cells[6].Value.ToString();
                byte[] pic;
                pic = (byte[])dataGridView1.Rows[0].Cells[7].Value;
                MemoryStream picture = new MemoryStream(pic);
                pic_box.Image = System.Drawing.Image.FromStream(picture);


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
}
