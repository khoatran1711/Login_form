using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_form
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            Addstudent addstudent = new Addstudent();
            
            addstudent.Show();

           

        }

        

        private void studentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentList a = new StudentList();
            a.Show();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindingMenu a = new FindingMenu();
            a.Show();
        }

        private void statisticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Statistic sta = new Statistic();
            sta.Show();
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage a = new Manage();
            a.ShowDialog();
        }

        private void editRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editform a = new editform();
            
            a.txt_Find_ID.Visible = true;
            a.btn_Find.Visible = true;
            a.ShowDialog();

        }

        private void addCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Course.Add_Course a = new Course.Add_Course();
            a.Show();
        }

        private void editRemoveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Course.Edit_Course a = new Course.Edit_Course();
            a.ShowDialog();
        }

        private void addScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Score.Add_score a = new Score.Add_score();
            a.ShowDialog();
        }
    }
}
