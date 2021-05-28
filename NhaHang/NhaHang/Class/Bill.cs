using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace NhaHang.Class
{
    class Bill
    {
        MYDB mydb = new MYDB();
        //luu bill
        public bool saveBill(int oid, int tid, int nCus, string date, int totalBill)
        {
            SqlCommand cmd = new SqlCommand("insert into Bills (oid,tid,nCus,day,totalBill) values (@oid,@tid,@nCus,@date,@totalBill)", mydb.getConnection);

            cmd.Parameters.Add("@oid", SqlDbType.Int).Value = oid;
            cmd.Parameters.Add("@tid", SqlDbType.Int).Value = tid;
            cmd.Parameters.Add("@nCus", SqlDbType.Int).Value = nCus;
            cmd.Parameters.Add("@date", SqlDbType.VarChar).Value = date;
            cmd.Parameters.Add("@totalBill", SqlDbType.Int).Value = totalBill;

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
