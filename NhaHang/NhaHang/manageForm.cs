using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhaHang
{
    public partial class manageForm : Form
    {
        public manageForm()
        {
            InitializeComponent();
        }

        private void addFoodButton_Click(object sender, EventArgs e)
        {
            FoodDrink.addFoodForm af = new FoodDrink.addFoodForm();
            af.ShowDialog();
        }
    }
}
