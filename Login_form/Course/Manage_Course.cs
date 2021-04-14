using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using iTextSharp.text.pdf;
using iTextSharp.text;

using Word = Microsoft.Office.Interop.Word;

namespace Login_form.Course
{
    public partial class Manage_Course : Form
    {
        DataTable b = new DataTable();
        public Manage_Course()
        {
            InitializeComponent();
            Load();
            txt_Course_ID.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            txt_Label.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            txt_Period.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            txt_Descrip.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
        }

        public void Load()
        {
            string connection = "Data Source=DESKTOP-I15DKS7;Initial Catalog=Student;Integrated Security=True";
            string strSQL = @"select * from Course ";
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = connection;
            Con.Open();
            SqlDataAdapter da = new SqlDataAdapter(strSQL, Con);
            DataSet ds = new DataSet("Course");

            da.Fill(ds, "Course");
            DataTable dt = ds.Tables["Course"];

            dataGridView1.DataSource = dt;
            //DataTable b = dataGridView1.DataSource;
            Con.Close();
            Con.ConnectionString = connection;
            b = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            flag = true;
            txt_Course_ID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_Label.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_Period.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_Descrip.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            d = dataGridView1.CurrentRow.Index;
        }
        public void Remove()
        {
            string connection = "Data Source=DESKTOP-I15DKS7;Initial Catalog=Student;Integrated Security=True";
            SqlConnection Con = new SqlConnection(connection);
            Con.Open();
            var command = Con.CreateCommand();
            command.CommandText = "Delete from Course where id = " + dataGridView1.Rows[d].Cells[0].Value.ToString();
            command.ExecuteNonQuery();
            Con.Close();
        }



        private void btn_First_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentRow.Selected = false;
            Off_except(0);
            dataGridView1.Rows[0].Selected = true;
            Load_info(0);
            d = 0;
            flag = false;
        }

        public void Off_except(int c)
        {
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {

                if (i != c) dataGridView1.Rows[i].Selected = false;
            }
        }

        public void Load_info(int a)
        {
            if (a >= 0 && a <= dataGridView1.Rows.Count - 1)
            {
                txt_Course_ID.Text = dataGridView1.Rows[a].Cells[0].Value.ToString();
                txt_Label.Text = dataGridView1.Rows[a].Cells[1].Value.ToString();
                txt_Period.Text = dataGridView1.Rows[a].Cells[2].Value.ToString();
                txt_Descrip.Text = dataGridView1.Rows[a].Cells[3].Value.ToString();
            }

        }

        private void btn_Last_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentRow.Selected = false;
            Off_except(dataGridView1.Rows.Count - 1);
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
            Load_info(dataGridView1.Rows.Count - 1);
            d = dataGridView1.Rows.Count - 1;
            flag = false;
        }

        int d = 0;
        bool flag = true;

        private void btn_Next_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                d = dataGridView1.CurrentRow.Index;
                if (d <= dataGridView1.Rows.Count - 1)
                {
                    Off_except(d + 1);
                    d++;
                    dataGridView1.Rows[d].Selected = true;
                    Load_info(d);
                    flag = false;
                }
            }
            else
            {
                if (d < dataGridView1.Rows.Count - 1)
                {
                    Off_except(d + 1);
                    d++;
                    dataGridView1.Rows[d].Selected = true;
                    Load_info(d);
                }
            }
        }

        bool Verify()
        {
            if ((txt_Course_ID.Text.Trim() == "")
                || (txt_Label.Text.Trim() == "")
                || (txt_Period.Text.Trim() == "")
                || (Convert.ToInt32(txt_Period.Text) <= 10))

            {
                return false;
            }
            else
            {
                return true;
            }
        }



        private void btn_Previous_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                d = dataGridView1.CurrentRow.Index;
                if (d > 0)
                {
                    Off_except(d - 1);
                    d--;
                    dataGridView1.Rows[d].Selected = true;
                    Load_info(d);
                    flag = false;
                }
            }
            else
            {
                if (d > 0)
                {
                    Off_except(d - 1);
                    d--;
                    Load_info(d);
                    dataGridView1.Rows[d].Selected = true;
                }
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            course a = new course();
            if (Verify())
            {
                if (a.insertcourse(txt_Course_ID.Text, txt_Label.Text, Convert.ToInt32(txt_Period.Text), txt_Descrip.Text))
                {
                    MessageBox.Show("New course has been added successfully!", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error!", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Load();
            }
            else
            {
                {
                    MessageBox.Show("Something is missing or Wrong!!!", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }
        public void Change()
        {
            string label = txt_Label.Text;
            string period = txt_Period.Text;
            string descrip = txt_Descrip.Text;
            string connection = "Data Source=DESKTOP-I15DKS7;Initial Catalog=Student;Integrated Security=True";
            SqlConnection Con = new SqlConnection(connection);
            Con.Open();
            var command = Con.CreateCommand();
            command.CommandText = "Update course set Label = ' " + label + "',Period = " + period + ",Description = '" + descrip + "' where id = " + dataGridView1.Rows[d].Cells[0].Value.ToString();
            command.ExecuteNonQuery();
            Con.Close();
            Load();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to change this course?", "Change Course", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Change();
                MessageBox.Show("You have changed the Course!!!", "Change Course ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("The Course has not been changed", "Change Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Load();
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this course?", "Delete Course", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Remove();
                MessageBox.Show("You have removed the Course!!!", "Delete Course ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("The Course has not been removed", "Delete Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Load();
        }

        private void btn_PrintToWord_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                int Row_Count = dataGridView1.Rows.Count;
                int Col_Count = dataGridView1.Columns.Count;
                Word.Document oDoc = new Word.Document();
                Object oMissing = System.Reflection.Missing.Value;
                oDoc.Application.Visible = true;
                string oTemp = "";
                object b = "\\endofdoc";
                // TAO TEU DE
                var Title = oDoc.Content.Paragraphs.Add(ref oMissing);
                Title.Range.Text = "DANH SACH MON HOC ";
                Title.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                Title.Range.Font.Size = 40;
                Title.Range.Font.Bold = 30;
                Title.Range.Font.Color = Word.WdColor.wdColorGreen;
                Title.Range.InsertParagraphAfter();
                Title.Range.Font.Reset();
                // TONG SO SINH VIEN
                var Total = oDoc.Content.Paragraphs.Add(ref oMissing);
                Total.Range.Text = "So Luong Mon Hoc: " + dataGridView1.Rows.Count.ToString();
                Total.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                Total.Range.Font.Italic = 20;
                Total.Range.Font.Color = Word.WdColor.wdColorGreen;
                Total.Range.InsertParagraphAfter();
                Total.Range.Font.Reset();
                // BANG THONG TIN SV
                Microsoft.Office.Interop.Word.Table tab;
                Microsoft.Office.Interop.Word.Range rangeof = oDoc.Bookmarks.get_Item(ref b).Range;
                tab = oDoc.Tables.Add(rangeof, Row_Count + 1, Col_Count + 1, ref oMissing, ref oMissing);
                tab.Range.ParagraphFormat.SpaceAfter = 8;
                tab.Rows.Height = 80;
                tab.Cell(1, 1).Range.Text = "STT";
                tab.Cell(1, 1).Range.Paragraphs.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                tab.Cell(1, 1).Range.Bold = 5;
                for (int i = 0; i < Col_Count; i++)
                {
                    tab.Cell(1, i + 2).Range.Text = dataGridView1.Columns[i].HeaderText;
                    tab.Cell(1, i + 2).Range.Paragraphs.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    tab.Cell(1, i + 2).Range.Bold = 5;
                }

                tab.Rows[1].Shading.ForegroundPatternColor = Word.WdColor.wdColorLime;
                tab.Rows[1].Height = 30;
                tab.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                tab.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                for (int r = 0; r <= Row_Count - 1; r++)
                {
                    oTemp = "";
                    int c;
                    tab.Cell(r + 2, 1).Range.Text = (r + 1).ToString();
                    tab.Cell(r + 2, 1).Range.Paragraphs.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    for (c = 0; c < Col_Count ; c++)
                    {
                        oTemp = dataGridView1.Rows[r].Cells[c].Value.ToString();
                        tab.Cell(r + 2, c + 2).Range.Text = oTemp;
                        tab.Cell(r + 2, c + 2).Range.Paragraphs.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    }
                    tab.Rows[r+2].Height = 50;
                }
                tab.Columns[1].Width = 50;
            }
        }
    }
}

