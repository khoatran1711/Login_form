using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Login_form.Course
{
    class Course
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-I15DKS7;Initial Catalog=Student;Persist Security Info=True;User ID=sa;Password=Khoa17112001");

        public SqlConnection GetConnection
        {
            get
            {
                return con;
            }
        }



        public void openConnectionState()
        {
            if ((con.State == ConnectionState.Closed))
            {
                con.Open();
            }
        }

        public void closeConnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }

    class course
    {
        Course Account = new Course();
        public bool insertcourse(string id, string label,int period,string description)
        {
            
            SqlCommand command = new SqlCommand("INSERT INTO Course (id,label,period,description)" + " VALUES (@id,@label,@period,@description)", Account.GetConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            command.Parameters.Add("@label", SqlDbType.VarChar).Value = label;
            command.Parameters.Add("@period", SqlDbType.Int).Value = period;
            command.Parameters.Add("@description", SqlDbType.VarChar).Value = description;


            Account.openConnectionState();
            if (command.ExecuteNonQuery() == 1)
            {
                Account.closeConnection();
                return true;
            }
            else
            {
                Account.closeConnection();
                return false;
            }
        }
    }
}
