using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login_form.Human_User.Contact
{
    public partial class Show_all : Form
    {
        public Show_all()
        {
            InitializeComponent();
        }

        private void Show_all_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'loginDataSet.mycontact' table. You can move, or remove it, as needed.
            this.mycontactTableAdapter.Fill(this.loginDataSet.mycontact);
            if (dataGridView1.Rows.Count <= 3)
                dataGridView1.Height = dataGridView1.ColumnHeadersHeight + dataGridView1.RowTemplate.Height * dataGridView1.Rows.Count;
            else
                dataGridView1.Height = 273;


        }
    }
}
