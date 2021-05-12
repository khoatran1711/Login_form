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

namespace Login_form.Human_User
{
    public partial class New_User : Form
    {
        public New_User()
        {
            InitializeComponent();
        }

        public bool check ()
        {
            if ((txt_firstname.Text.Trim() == "")
               || (txt_lastname.Text.Trim() == "")
               || (txt_acc.Text.Trim() == "")
               || (txt_ID.Text.Trim() == "")
               || (txt_pwd.Text.Trim() == "")
               || (pic_box.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            User a = new User();
            int id = Convert.ToInt32(txt_ID.Text);
            string fname = txt_firstname.Text;
            string lname = txt_lastname.Text;
            string uname = txt_acc.Text;
            string pwd = txt_pwd.Text;
            MemoryStream pic = new MemoryStream();
            if (check())
            {
                if (txt_pwd.Text==txt_con_pwd.Text)
                {
                    if (a.isExist(uname))
                    {
                        MessageBox.Show("This Account is already exist", "Add user", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        pic_box.Image.Save(pic, pic_box.Image.RawFormat);
                        if (a.insertUser(id,fname,lname,uname,pwd,pic))
                        {
                            MessageBox.Show("New user added successfully!", "Add student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("There was some errors, please try again!", "Add student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Your password is not match", "Add user", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                MessageBox.Show("Something is missing", "Add user", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
    }
}
