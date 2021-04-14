using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace Login_form
{
    class Student
    {
        SV student = new SV();
        public bool insertStudent(int id, string fname, string lname, DateTime bdate, string gender, string phone, string address, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("INSERT INTO stu (id,fname,lname,bdate,gender,phone,address,picture)" + " VALUES (@id,@fn,@ln,@bdt,@gdr,@phn,@adrs,@pic)", student.GetConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

            student.openConnectionState();
            if (command.ExecuteNonQuery() == 1)
            {
                student.closeConnection();
                return true;
            }
            else
            {
                student.closeConnection();
                return false;
            }
        }

        public bool UpdateStudent(int id, string fname, string lname, DateTime bdate, string gender, string phone, string address, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("Update stu set fname=@fn,lname=@ln,bdate=@bdt,gender=@gdr,phone = @phn,address=@adrs,picture = @pic where id=@id ", student.GetConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

            student.openConnectionState();
            if (command.ExecuteNonQuery() == 1)
            {
                student.closeConnection();
                return true;
            }
            else
            {
                student.closeConnection();
                return false;
            }
        }

        public bool RemoveStudent(int id)
        {
            SqlCommand command = new SqlCommand("Delete from stu where id=@id ", student.GetConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
           
            student.openConnectionState();
            if (command.ExecuteNonQuery() == 1)
            {
                student.closeConnection();
                return true;
            }
            else
            {
                student.closeConnection();
                return false;
            }
        }

        /*public bool Total()
        {
            SqlCommand command = new SqlCommand("Select count(*) from stu ", student.GetConnection);
            

            student.openConnectionState();
            if (command.ExecuteNonQuery() == 1)
            {
                student.closeConnection();
                return true;
            }
            else
            {
                student.closeConnection();
                return false;
            }
        }*/

    }

    class account
    {
        Mydb Account = new Mydb();
        public bool insertaccount(string username, string password)
        {
            SqlCommand command = new SqlCommand("INSERT INTO login (username,password)" + " VALUES (@username,@password)", Account.GetConnection);
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@password", SqlDbType.VarChar).Value = password;


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
