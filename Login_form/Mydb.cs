using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
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

    class User
    {
        Mydb user = new Mydb();
        
        public bool isExist (string uname)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM Human WHERE uname = @uname", user.GetConnection);

            command.Parameters.Add("@uname", SqlDbType.VarChar).Value = uname;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0) return true;
            return false;
        }
        public bool insertUser(int id, string fname, string lname, string uname, string pwd, MemoryStream pic)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Human (id,f_name,l_name,uname,pwd,fig)" + " VALUES (@id,@fn,@ln,@uname,@pwd,@fig)", user.GetConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@fn", SqlDbType.NVarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.NVarChar).Value = lname;
            command.Parameters.Add("@uname", SqlDbType.NVarChar).Value = uname;
            command.Parameters.Add("@pwd", SqlDbType.NVarChar).Value = pwd;
            command.Parameters.Add("@fig", SqlDbType.Image).Value = pic.ToArray();

            user.openConnectionState();
            if (command.ExecuteNonQuery() == 1)
            {
                user.closeConnection();
                return true;
            }
            else
            {
                user.closeConnection();
                return false;
            }
        }

        public bool updateUser(int id, string fname, string lname, string uname, string pwd, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("Update Human set f_name = @fn,l_name=@ln,uname=@uname,pwd=@pwd,fig=@pic where ID=@id  ", user.GetConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@fn", SqlDbType.NVarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.NVarChar).Value = lname;
            command.Parameters.Add("@uname", SqlDbType.NVarChar).Value = uname;
            command.Parameters.Add("@pwd", SqlDbType.NVarChar).Value = pwd;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

            user.openConnectionState();
            if (command.ExecuteNonQuery() == 1)
            {
                user.closeConnection();
                return true;
            }
            else
            {
                user.closeConnection();
                return false;
            }
        }



       
    }

}
