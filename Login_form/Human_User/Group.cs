using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace Login_form.Human_User
{
    class Mygroup
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
    class Group
    {
        

       
            Mygroup contact = new Mygroup();
            public bool add(string id, string name, string userID )
            {

                SqlCommand command = new SqlCommand("INSERT INTO Group1 (id,name,userID)" + " VALUES (@id,@name,@userID)", contact.GetConnection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                command.Parameters.Add("@userID", SqlDbType.VarChar).Value = userID;
               
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

            public bool edit(string id, string name)
            {
                SqlCommand command = new SqlCommand("UPDATE Group1 SET name = @name where id=@id", contact.GetConnection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
          

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
                SqlCommand command = new SqlCommand("DELETE FROM Group1 where id = @id", contact.GetConnection);
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

