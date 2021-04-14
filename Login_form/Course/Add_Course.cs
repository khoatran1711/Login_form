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

namespace Login_form.Course
{
    public partial class Add_Course : Form
    {
        public Add_Course()
        {
            InitializeComponent();
        }

        bool Verify()
        {
            if ((txt_Course_ID.Text.Trim() == "")             
                || (txt_Label.Text.Trim() == "")
                || (txt_Period.Text.Trim() == "")
                || (Convert.ToInt32(txt_Period.Text)<=10))

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
            course a = new course();
            if (Verify())
            {
                if (a.insertcourse(txt_Course_ID.Text, txt_Label.Text, Convert.ToInt32(txt_Period.Text), txt_Descrip.Text))
                {
                    MessageBox.Show("New course has been added successfully!", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error!", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                {
                    MessageBox.Show("Something is missing or Wrong!!!", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
           
        }
    }
}
