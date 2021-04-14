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

namespace Login_form
{
    public partial class Addstudent : Form
    {
        public Addstudent()
        {
            InitializeComponent();
        }

        private void btn_confirm_Click(object sender, EventArgs e)
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

        private void btn_add_picture_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg,*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pic_box.Image = Image.FromFile(opf.FileName);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
    }
}
