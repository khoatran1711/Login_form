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
        public customerForm()
        {
            InitializeComponent();
            foodDataGridView.DataSource = food.getAllFood();
            foodDataGridView.Columns[0].Width = 40;
            foodDataGridView.Columns[1].Width = 100;
            foodDataGridView.Columns[2].Width = 150;
            foodDataGridView.Columns[3].Width = 80;
            foodDataGridView.Columns[4].Width = 58;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            picCol = (DataGridViewImageColumn)foodDataGridView.Columns[1];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }
    }
}
