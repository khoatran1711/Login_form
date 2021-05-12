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


namespace Login_form.Course
{
    public partial class Add_course_for_stu : Form
    {
        DataTable avai = new DataTable();
        DataTable select = new DataTable();
        public Add_course_for_stu()
        {
            InitializeComponent();
           
        }

        // Load Course da co
       public void Load_selected()
        {
            string connection = "Data Source=DESKTOP-I15DKS7;Initial Catalog=Student;Integrated Security=True";
            string ab = txt_id.Text;
            string strSQL2 = @"select c.ID,c.Label from Course c Except select c.ID,c.Label from Course c JOIN  grade d on c.ID = d.ID_course where d.ID_student ="+txt_id.Text;
            string strSQL = @"select c.ID,c.Label,d.Grade from Course c JOIN grade d on c.ID = d.ID_course where d.ID_student = " + txt_id.Text;
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = connection;
            try
            {
                Con.Open();
                SqlDataAdapter da = new SqlDataAdapter(strSQL, Con);
                DataSet ds = new DataSet("Course");
                da.Fill(ds, "Course");
                DataTable dt = ds.Tables["Course"];
                avai = dt;
                
                SqlDataAdapter db = new SqlDataAdapter(strSQL2, Con);
                DataSet dss = new DataSet("Course2");
                db.Fill(dss, "Course2");
                DataTable dt2 = dss.Tables["Course2"];
                select = dt2;
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

        // Load tat ca Course
       
       

        private void Add_course_for_stu_Shown(object sender, EventArgs e)
        {
            Load_selected();
            for (int i = 0; i < avai.Rows.Count; i++)
            {
                 avai_couse.Items.Add(avai.Rows[i][0]+ " - " + avai.Rows[i][1]);
            }
            for (int i=0;i<select.Rows.Count;i++)
            {
                select_course.Items.Add(select.Rows[i][0] + " - " + select.Rows[i][1]);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {

            for (int i =0; i< select_course.Items.Count;i++)
            {
                if (select_course.GetItemChecked(i) == true) Add(ID_Course(select_course.Items[i].ToString()));
            }
            select_course.Items.Clear();
            avai_couse.Items.Clear();

            Load_selected();
            for (int i = 0; i < avai.Rows.Count; i++)
            {
                avai_couse.Items.Add(avai.Rows[i][0] + " - " + avai.Rows[i][1]);
            }
            for (int i = 0; i < select.Rows.Count; i++)
            {
                select_course.Items.Add(select.Rows[i][0] + " - " + select.Rows[i][1]);
            }

        }
        // Add mon hoc moi cho SV
        public void Add(string ID_course)
        {
            string connection = "Data Source=DESKTOP-I15DKS7;Initial Catalog=Student;Integrated Security=True";
            SqlConnection Con = new SqlConnection(connection);
            try
            {
                Con.Open();
                var command = Con.CreateCommand();
                command.CommandText = "INSERT INTO Grade(ID_Student,ID_Course) VALUES (" + txt_id.Text + ", '" + ID_course + "')";
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
        // Lay ra Ma ID cua mon hoc
        public string ID_Course (string ID)
        {
            string a = "";
            for (int i =0;i<ID.Length && ID[i] != ' ';i++)
            {
                a = a + ID[i];
            }
            return a;
        }
        // Remove mon hoc
         public void Remove (string ID_Course)
        {
            string connection = "Data Source=DESKTOP-I15DKS7;Initial Catalog=Student;Integrated Security=True";
            SqlConnection Con = new SqlConnection(connection);
            try
            {
                Con.Open();
                var command = Con.CreateCommand();
                command.CommandText = "Delete from grade where ID_course ='" + ID_Course +"' and ID_student ="+txt_id.Text;
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

        public void Remove ()
        {
            for (int i = 0; i < avai_couse.Items.Count; i++)
            {
                if (avai_couse.GetItemChecked(i) == true) Remove(ID_Course(avai_couse.Items[i].ToString()));
            }
            select_course.Items.Clear();
            avai_couse.Items.Clear();

            Load_selected();
            for (int i = 0; i < avai.Rows.Count; i++)
            {
                avai_couse.Items.Add(avai.Rows[i][0] + " - " + avai.Rows[i][1]);
            }
            for (int i = 0; i < select.Rows.Count; i++)
            {
                select_course.Items.Add(select.Rows[i][0] + " - " + select.Rows[i][1]);
            }
        }

        public bool Check ()
        {
            for (int d=0;d<avai.Rows.Count;d++)
            {
                if (avai_couse.GetItemChecked(d) == true && avai.Rows[d][2] != null) return false;
            }
            return true;
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                if (MessageBox.Show("Are you sure you want to remove this course from this student ?", "Change Course", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Remove();
                    MessageBox.Show("DONE", "Change Course ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    MessageBox.Show("FAIL TO REMOVE", "Change Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("This course(s) has information, are you still want you remove ?", "Change Course", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Remove();
                    MessageBox.Show("DONE", "Change Course ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    MessageBox.Show("FAIL TO REMOVE", "Change Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }
    }
}
