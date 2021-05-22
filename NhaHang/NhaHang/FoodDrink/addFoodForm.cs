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

namespace NhaHang.FoodDrink
{
    public partial class addFoodForm : Form
    {
        public addFoodForm()
        {
            InitializeComponent();
        }
        //them mon an
        private void addButton_Click(object sender, EventArgs e)
        {

            Class.Food food = new Class.Food();
            if (idTextBox.Text == "")
            {
                MessageBox.Show("Please enter the ID");
            }
            else
            {
                int id = Convert.ToInt32(idTextBox.Text);
                string fname = nameTextBox.Text;
                int amount = 10;
                int cost = Convert.ToInt32(costTextBox.Text);
                MemoryStream pic = new MemoryStream();
                /*try
                {
                  */  if (nameTextBox.Text == "" || costTextBox.Text == "" || foodPictureBox.Image == null)
                    {
                        MessageBox.Show("Empty Fields");
                    }
                    else
                    {
                       
                        if (food.foodExist(fname) == false)
                        {
                            foodPictureBox.Image.Save(pic, foodPictureBox.Image.RawFormat);
                            if (food.insertUser(id, fname, pic, amount,cost))
                            {
                                MessageBox.Show("New food added successfully!", "Add food", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            else
                            {
                                MessageBox.Show("Error!", "Add food", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Food exists", "Add food", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                       
                    }
             /*   }
                catch (Exception)
                {
                    MessageBox.Show("Error enter information, please check and try again!!!", "Add student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }*/
            }
        }
        //them anh
        private void addPicButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                foodPictureBox.Image = Image.FromFile(opf.FileName);
                foodPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
