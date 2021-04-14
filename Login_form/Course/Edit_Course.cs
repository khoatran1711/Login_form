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

namespace Login_form.Course
{
    public partial class Edit_Course : Form
    {
        int count = 0;
        DataTable b = new DataTable();
        public Edit_Course()
        {
            InitializeComponent();
            Load();
          
        }

        public void Load()
        {
            string connection = "Data Source=DESKTOP-I15DKS7;Initial Catalog=Student;Integrated Security=True";
            string strSQL = @"select * from Course ";
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = connection;
            Con.Open();
            SqlDataAdapter da = new SqlDataAdapter(strSQL, Con);
            DataSet ds = new DataSet("Course");

            da.Fill(ds, "Course");
            DataTable dt = ds.Tables["Course"];

            cbox_Select.DataSource = dt;
            //DataTable b = dataGridView1.DataSource;
            Con.Close();
            Con.ConnectionString = connection;
            count = dt.Rows.Count;
            b = dt;
        }


        private void cbox_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbox_Select.SelectedIndex>=0 && cbox_Select.SelectedIndex< count )
            {
                txt_label.Text = b.Rows[cbox_Select.SelectedIndex][1].ToString();
                numUpDo_Period.Value = Convert.ToInt32 (b.Rows[cbox_Select.SelectedIndex][2]);
                txt_descrip.Text = b.Rows[cbox_Select.SelectedIndex][3].ToString();
            }
        }

        // Change course
        public void Change()
        {
            string label = txt_label.Text;
            string period = numUpDo_Period.Value.ToString();
            string descrip = txt_descrip.Text;
            string connection = "Data Source=DESKTOP-I15DKS7;Initial Catalog=Student;Integrated Security=True";
            SqlConnection Con = new SqlConnection(connection);
            Con.Open();
            var command = Con.CreateCommand();
            command.CommandText = "Update course set Label = ' " + label + "',Period = " + period + ",Description = '" + descrip + "' where id = " + b.Rows[cbox_Select.SelectedIndex][0].ToString();
            command.ExecuteNonQuery();
            Con.Close();
        }

        public void Remove()
        { 
            string connection = "Data Source=DESKTOP-I15DKS7;Initial Catalog=Student;Integrated Security=True";
            SqlConnection Con = new SqlConnection(connection);
            Con.Open();
            var command = Con.CreateCommand();
            command.CommandText = "Delete from Course where id = " + b.Rows[cbox_Select.SelectedIndex][0].ToString();
            command.ExecuteNonQuery();
            Con.Close();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to change this course?", "Change Course", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Change();
                MessageBox.Show("You have changed the Course!!!", "Change Course ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
                MessageBox.Show("The Course has not been changed", "Change Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Load();
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to delete this course?", "Delete Course", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Remove();
                MessageBox.Show("You have removed the Course!!!", "Delete Course ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("The Course has not been removed", "Delete Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Load();
        }
    }
}
//123
