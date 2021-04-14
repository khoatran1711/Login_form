using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Login_form
{
    class Mydb 
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-I15DKS7;Initial Catalog=Login;Persist Security Info=True;User ID=sa;Password=Khoa17112001");

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

    class SV
    {
        SqlConnection ko = new SqlConnection(@"Data Source=DESKTOP-I15DKS7;Initial Catalog=Student;Persist Security Info=True;User ID=sa;Password=Khoa17112001");

        public SqlConnection GetConnection
        {
            get
            {
                return ko;
            }
        }

        public void openConnectionState()
        {
            if ((ko.State == ConnectionState.Closed))
            {
                ko.Open();
            }
        }

        public void closeConnection()
        {
            if (ko.State == ConnectionState.Open)
            {
                ko.Close();
            }
        }

    }

}
