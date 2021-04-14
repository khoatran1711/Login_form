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

namespace Login_form
{
    public partial class Statistic : Form
    {
        public Statistic()
        {
            InitializeComponent();
            string connection = "Data Source=DESKTOP-I15DKS7;Initial Catalog=Student;Integrated Security=True";
            // lay tong sv
            string strSQL = @"select * from stu ";
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = connection;
            SqlCommand cmd = new SqlCommand(strSQL, Con);
            Con.Open();
            SqlDataAdapter da = new SqlDataAdapter(strSQL, Con);
            DataSet ds = new DataSet("Student");
            da.Fill(ds, "Student");
            DataTable dt = ds.Tables["Student"];
            int total = dt.Rows.Count;
            // lay so luong male
            strSQL = @"select * from stu where gender = 'male' ";
            da = new SqlDataAdapter(strSQL, Con);
            ds = new DataSet("Student");
            da.Fill(ds, "Student");
            dt = ds.Tables["Student"];
            int nummale = dt.Rows.Count;
            // lay so luong female
            strSQL = @"select * from stu where gender = 'female' ";
            da = new SqlDataAdapter(strSQL, Con);
            ds = new DataSet("Student");
            da.Fill(ds, "Student");
            dt = ds.Tables["Student"];
            int numfemale = dt.Rows.Count;
            // lay so luong gender la Other
            strSQL = @"select * from stu where gender = 'Other' ";
            da = new SqlDataAdapter(strSQL, Con);
            ds = new DataSet("Student");
            da.Fill(ds, "Student");
            dt = ds.Tables["Student"];
            int numother = dt.Rows.Count;
            Con.Close();

            if (nummale >0 )
            chart1.Series["Gender"].Points.AddXY("Male", nummale);
            if (numfemale >0)
            chart1.Series["Gender"].Points.AddXY("Female", numfemale);
            if (numother >0)
            chart1.Series["Gender"].Points.AddXY("Other", numother);
            chart1.Series["Gender"].IsValueShownAsLabel = true;
       

        }

        
    }
}
