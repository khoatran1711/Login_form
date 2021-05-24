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
    }
}
