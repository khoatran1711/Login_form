using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace NhaHang.Class
{
    class Food
    {
        MYDB mydb = new MYDB();

        //them mon an
        public bool insertUser(int id, string fname, MemoryStream picture, int amount, int cost)
        {
            SqlCommand cmd = new SqlCommand("insert into FoodDrink (id, pic,fname,famount,fcost) values (@id,@pic,@fn,@amt,@cost)", mydb.getConnection);

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            cmd.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            cmd.Parameters.Add("@amt", SqlDbType.Int).Value = amount;
            cmd.Parameters.Add("@cost", SqlDbType.BigInt).Value = cost;

            mydb.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        //kiem tra trung
        public bool foodExist(string name)
        {
            mydb.openConnection();
            SqlCommand cmd = new SqlCommand(@"Select * from FoodDrink where fname = @name", mydb.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //lay thong tin mon an
        public DataTable getAllFood()
        {
            SqlCommand command = new SqlCommand("Select id as 'ID',pic as 'Image' ,fname as 'Name',fcost as 'Price',fstatus as 'Status' from FoodDrink", mydb.getConnection);
            mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }
        //cap nhat user
        public bool updateUser(int userid, string fname, string lname, string username, string password, MemoryStream picture)
        {
            SqlCommand cmd = new SqlCommand("update hr set f_name = @fn, l_name = @ln, uname = @un, pwd = @pass, fig = @pic where id =@uid", mydb.getConnection);

            cmd.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            cmd.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            cmd.Parameters.Add("@un", SqlDbType.VarChar).Value = username;
            cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;
            cmd.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            cmd.Parameters.Add("@uid", SqlDbType.Int).Value = userid;

            mydb.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
    }
}
