using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Login_form.Score
{
    public partial class Add_score : Form
    {
        public Add_score()
        {
            InitializeComponent();
            Load();
            Load_to_list();
            txt_Student_ID.Text = Ds_hoc_sinh.Rows[0][0].ToString();
            Load_course(1);
            Load_diem();
        }

        DataTable Ds_hoc_sinh = new DataTable();
        DataTable Ds_mon_hoc = new DataTable();

        public void Load_diem ()
        {
            for (int i = 0; i < Ds_mon_hoc.Rows.Count; i++)
            {
                if (txt_Student_ID.Text == Ds_mon_hoc.Rows[i][0].ToString() && Ds_mon_hoc.Rows[i][1].ToString() == cbBox_Course.SelectedValue)
                {
                    txt_Score.Text = Ds_mon_hoc.Rows[i][3].ToString();
                    txt_Descrip.Text = Ds_mon_hoc.Rows[i][5].ToString();
                }
            }
        }
        public void Load_diem(string a)
        {
            for (int i = 0; i < Ds_mon_hoc.Rows.Count; i++)
            {
                if (txt_Student_ID.Text == Ds_mon_hoc.Rows[i][0].ToString() && Ds_mon_hoc.Rows[i][1].ToString() == a)
                {
                    txt_Score.Text = Ds_mon_hoc.Rows[i][3].ToString();
                    txt_Descrip.Text = Ds_mon_hoc.Rows[i][5].ToString();
                }
            }
        }
        public void Load_course (int ID)
        {
            DataTable b = new DataTable();
            b.Columns.Add("ID");
            b.Columns.Add("NAME");
            b.Columns.Add("SCORE");
            b.Columns.Add("SEMESTER");
            b.Columns.Add("DESCRIPTION");
            for (int i=0;i<Ds_mon_hoc.Rows.Count;i++)
            {
                if (Convert.ToInt32(Ds_mon_hoc.Rows[i][0]) == ID)
                {

                    b.Rows.Add(Ds_mon_hoc.Rows[i][1], Ds_mon_hoc.Rows[i][2], Ds_mon_hoc.Rows[i][3], Ds_mon_hoc.Rows[i][4], Ds_mon_hoc.Rows[i][5]); 
                       
                }
            }
            cbBox_Course.DataSource = b;
            cbBox_Course.DisplayMember = "Name";
            cbBox_Course.ValueMember = "ID";
           
        }
        
        public void Load_to_list ()
        {
            for (int i=0;i<2;i++)
            {
                student_list.Rows.Add(new DataGridViewRow());
                student_list.Rows[i].Cells[0].Value = Ds_hoc_sinh.Rows[i][0].ToString();
                student_list.Rows[i].Cells[1].Value = Ds_hoc_sinh.Rows[i][1].ToString();
                student_list.Rows[i].Cells[2].Value = Ds_hoc_sinh.Rows[i][2].ToString();
              
            }
        }

        public void Load ()
        {
            string connection = "Data Source=DESKTOP-I15DKS7;Initial Catalog=Student;Integrated Security=True";
            string strSQL = @"select id,fname,lname from stu " ;
            string strSQL2 = @"select d.ID_student,d.ID_course,c.Label,d.Grade,d.Semester,d.Description from course c,grade d where c.ID = d.ID_course ";
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = connection;
            try
            {
                Con.Open();
                SqlDataAdapter da = new SqlDataAdapter(strSQL, Con);
                DataSet ds = new DataSet("Student");
                da.Fill(ds, "Student");
                DataTable dt = ds.Tables["Student"];
                Ds_hoc_sinh = dt;

                SqlDataAdapter db = new SqlDataAdapter(strSQL2, Con);
                DataSet dss = new DataSet("Course");
                db.Fill(dss, "Course");
                DataTable dt2 = dss.Tables["Course"];
                Ds_mon_hoc = dt2;
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

        private void cbBox_Course_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_diem(cbBox_Course.SelectedValue.ToString());
        }

        private void student_list_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_Student_ID.Text = student_list.CurrentRow.Cells[0].Value.ToString();
            Load_course(Convert.ToInt32(student_list.CurrentRow.Cells[0].Value));
            Load_diem();
        }

        public void ADD()
        {
            string connection = "Data Source=DESKTOP-I15DKS7;Initial Catalog=Student;Integrated Security=True";
            SqlConnection Con = new SqlConnection(connection);
            try
            {
                Con.Open();
                var command = Con.CreateCommand();
                string ID = txt_Student_ID.Text;
                string Course_ID = cbBox_Course.SelectedValue.ToString();
                string Descrip = txt_Descrip.Text;
                string Score = txt_Score.Text;

                command.CommandText = "UPDATE grade set Grade = " + Score + ", Description = '" + Descrip + "' where ID_Student = " + ID + " and ID_Course = " + Course_ID;
                command.ExecuteNonQuery();
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

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to add score for this student ?", "Change Score", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ADD();
                MessageBox.Show("SUCCESSFULLY!!!", "Change Score ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("FAIL TO ADD", "Change Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Load();
            Load_diem();
        }
    }
}
