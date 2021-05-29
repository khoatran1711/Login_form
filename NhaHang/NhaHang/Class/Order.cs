using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace NhaHang.Class
{
    class Order
    {
        Class.MYDB mydb = new MYDB();
        //lay id
        public int oID()
        {
            int oid = 0;
            SqlCommand command = new SqlCommand("SELECT TOP 1 * FROM Orders ORDER BY id DESC ", mydb.getConnection);
            mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            oid = (int)table.Rows[0]["id"];
            return oid;
        }
        //lay ds order
        public DataTable getOrder(int id)
        {
            mydb.openConnection();
            SqlCommand cmd = new SqlCommand(@"Select fname,famount,fcost,fid from Orders where id = @id", mydb.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }
        //them order
        public bool insertOrder(int id, int fid, string fname, int famount, int fcost)
        {
            SqlCommand cmd = new SqlCommand("insert into Orders (id, fid,fname,famount,fcost) values (@id,@fid,@fn,@amt,@cost)", mydb.getConnection);

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            cmd.Parameters.Add("@fid", SqlDbType.Int).Value = fid;
            cmd.Parameters.Add("@amt", SqlDbType.Int).Value = famount;
            cmd.Parameters.Add("@cost", SqlDbType.BigInt).Value = fcost;

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
        //xoa order
        public bool deleteOrder(int id, int fid)
        {
            SqlCommand cmd = new SqlCommand("delete from Orders where id = @id and fid = @fid", mydb.getConnection);

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@fid", SqlDbType.Int).Value = fid;

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
        //lay tong gia
        public int totalCost(int tid)
        {
            int total = 0;

            SqlCommand command = new SqlCommand("SELECT sum(fcost) as 'total' FROM Orders where id = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = tid;
            mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            total = Convert.ToInt32(table.Rows[0]["total"]);

            return total;
        }
    }
}
