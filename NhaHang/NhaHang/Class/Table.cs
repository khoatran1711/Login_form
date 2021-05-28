using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace NhaHang.Class
{
    class Table
    {
        Class.MYDB mydb = new MYDB();

        //cap nhat trang thai table
        public bool updateTableStatus(int tid,int cusNum)
        {          
            SqlCommand cmd = new SqlCommand("update Table set numCustomer = @cusNum where id =@tid", mydb.getConnection);
            cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tid;
            cmd.Parameters.Add("@cusNum", SqlDbType.Int).Value = 4 - cusNum;
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
        //hien thi trang thai ban
        public int slotTable(int tid)
        {
            int slot = 0;
            SqlCommand command = new SqlCommand("select slot from Tables where id = @tid", mydb.getConnection);
            command.Parameters.Add("@tid", SqlDbType.Int).Value = tid;
            mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            slot = (int)table.Rows[0]["slot"];
            return slot;
        }
        //hien thi so ban con kha dung
        public DataTable getTables()
        {
            SqlCommand command = new SqlCommand("select * from tables where slot > 0", mydb.getConnection);
            mydb.openConnection();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }
    }
}
