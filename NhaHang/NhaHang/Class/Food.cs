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
        public bool insertFood(int id, string fname, MemoryStream picture, int amount, int cost)
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
        //cap nhat so luong
        public bool updateUser(int fid,int famount)
        {
            int sl = fAmount(fid);
            sl = sl - famount;
            SqlCommand cmd = new SqlCommand("update FoodDrink set famount = @sl  where id = @fid", mydb.getConnection);
            cmd.Parameters.Add("@fid", SqlDbType.Int).Value = fid;
            cmd.Parameters.Add("@sl", SqlDbType.Int).Value = sl;

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
        //lay so luong
        public int fAmount(int fid)
        {
            int sl = 0;
            SqlCommand command = new SqlCommand("Select famount from FoodDrink where id = @fid", mydb.getConnection);
            command.Parameters.Add("@fid",SqlDbType.Int).Value = fid;
            mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            sl = (int)table.Rows[0]["famount"];
            return sl;
        }
        //lay gia
        public int fCost(int fid)
        {
            int gia = 0;
            SqlCommand command = new SqlCommand("Select fcost from FoodDrink where id = @fid", mydb.getConnection);
            command.Parameters.Add("@fid", SqlDbType.Int).Value = fid;
            mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            gia = (int)table.Rows[0]["fcost"];
            return gia;
        }
    }
}
