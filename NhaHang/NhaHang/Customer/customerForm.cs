using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace NhaHang.Customer
{
    public partial class customerForm : Form
    {
        Class.Food food = new Class.Food();
        Class.Order order = new Class.Order();
        Class.Table tb = new Class.Table();
        int oid;

        public customerForm()
        {
            InitializeComponent();
            oid = order.oID();
            oid++;
            loadData();
            loadTable();

        }
        //hien du lieu
        public void loadData()
        {
            foodDataGridView.DataSource = food.getAllFood();
            foodDataGridView.Columns[0].Width = 43;
            foodDataGridView.Columns[1].Width = 110;
            foodDataGridView.Columns[2].Width = 170;
            foodDataGridView.Columns[3].Width = 90;
            foodDataGridView.Columns[4].Width = 71;
            foodDataGridView.RowHeadersVisible = false;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            picCol = (DataGridViewImageColumn)foodDataGridView.Columns[1];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            orderDataGridView.DataSource = order.getOrder(oid);
            orderDataGridView.RowHeadersVisible = false;
            orderDataGridView.Columns[0].Width = 190;
            orderDataGridView.Columns[1].Width = 85;
            orderDataGridView.Columns[2].Width = 165;
        }

        private void foodDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.foodDataGridView.DefaultCellStyle.Font = new Font("VNI-Zap", 14);
            for (int i = 0; i < foodDataGridView.Rows.Count; i++)
            {
                if (i % 2 != 0)
                {
                    foodDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.OldLace;
                }
                else
                {
                    foodDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.MistyRose;
                }
            }

        }
        private void orderDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.orderDataGridView.DefaultCellStyle.Font = new Font("VNI-Zap", 14);
            for(int i = 0;i<orderDataGridView.Rows.Count;i++)
            {
                orderDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.SeaShell;
            }
        }
        //hien trang thai ban
        public void loadTable()
        {
            table1.Text = "Table 1: "+ tb.slotTable(1) + "seat(s) left";
            table2.Text = "Table 2: " + tb.slotTable(2) + "seat(s) left";
            table3.Text = "Table 3: " + tb.slotTable(3) + "seat(s) left";
            table4.Text = "Table 4: " + tb.slotTable(4) + "seat(s) left";
            table5.Text = "Table 5: " + tb.slotTable(5) + "seat(s) left";
            table6.Text = "Table 6: " + tb.slotTable(6) + "seat(s) left";
            table7.Text = "Table 7: " + tb.slotTable(7) + "seat(s) left";
        }
        //chon mon
        private void foodDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            fNameTextBox.Text = foodDataGridView.CurrentRow.Cells[2].Value.ToString();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            int id = oid;
            int fid = (int)foodDataGridView.CurrentRow.Cells[0].Value;
            string fname = fNameTextBox.Text;
            int famount = (int)amountNumericUpDown.Value;
            int fcost = food.fCost(fid) * famount;
            order.insertOrder(id,fid,fname,famount,fcost);
            loadData();
        }


    }
}
