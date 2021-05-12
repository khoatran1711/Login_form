using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Login_form.Human_User.Contact
{

    class Mycontact
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

    class Contact
    {
        Mycontact contact = new Mycontact();
        public bool add(string id, string fname,string lname,string group,string phone,string mail,string address,MemoryStream pic,string userID)
        {
            
                SqlCommand command = new SqlCommand("INSERT INTO mycontact (id,f_name,l_name,group_id,phone,email,address,picture,user_id)" + " VALUES (@id,@f_name,@l_name,@group_id,@phone,@email,@address,@picture,@user_id)", contact.GetConnection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                command.Parameters.Add("@f_name", SqlDbType.VarChar).Value = fname;
                command.Parameters.Add("@l_name", SqlDbType.VarChar).Value = lname;
                command.Parameters.Add("@group_id", SqlDbType.Int).Value = group;
                command.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = mail;
                command.Parameters.Add("@address", SqlDbType.VarChar).Value = address;
                command.Parameters.Add("@picture", SqlDbType.Image).Value = pic.ToArray();
                command.Parameters.Add("@user_id", SqlDbType.Int).Value = userID;


                contact.openConnectionState();
                if (command.ExecuteNonQuery() == 1)
                {
                    contact.closeConnection();
                    return true;
                }
                else
                {
                    contact.closeConnection();
                    return false;
                }
            

           
        }

        public bool edit(string id, string fname, string lname, string group, string phone, string mail, string address, MemoryStream pic, string userID)
        {
            SqlCommand command = new SqlCommand("UPDATE mycontact SET f_name=@f_name,l_name=@l_name,group_id=@group_id,phone=@phone,email=@email,address=@address,picture=@picture,user_id=@user_id where id=@id", contact.GetConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@f_name", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@l_name", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@group_id", SqlDbType.Int).Value = group;
            command.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = mail;
            command.Parameters.Add("@address", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@picture", SqlDbType.Image).Value = pic.ToArray();
            command.Parameters.Add("@user_id", SqlDbType.Int).Value = userID;


            contact.openConnectionState();
            if (command.ExecuteNonQuery() == 1)
            {
                contact.closeConnection();
                return true;
            }
            else
            {
                contact.closeConnection();
                return false;
            }
        }

        public bool remove(string id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM mycontact where id = @id", contact.GetConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
 
            contact.openConnectionState();
            if (command.ExecuteNonQuery() == 1)
            {
                contact.closeConnection();
                return true;
            }
            else
            {
                contact.closeConnection();
                return false;
            }
        }
    }
}
