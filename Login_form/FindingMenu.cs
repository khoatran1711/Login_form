using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;

namespace Login_form
{
    public partial class FindingMenu : Form
    {
        public FindingMenu()
        {
            InitializeComponent();
            ra_btn_fname.Checked = true;

        }

        private void btn_Find_Click(object sender, EventArgs e)
        {
            string connection = "Data Source=DESKTOP-I15DKS7;Initial Catalog=Student;Integrated Security=True";
            
            string fin = txt_find.Text;
            string table = "fname";
            if (ra_btn_ID.Checked) table = "id";
            if (ra_btn_lname.Checked) table = "lname";
            string strSQL = @"select * from stu where "+ table +" like '%"+fin+"%'";
            
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = connection;
          //  SqlCommand cmd = new SqlCommand(strSQL, Con);
            
            
            try
            {
                Con.Open();
                
                
                SqlDataAdapter da = new SqlDataAdapter(strSQL, Con);
                
                DataSet ds = new DataSet("Student");

                da.Fill(ds, "Student");
                DataTable dt = ds.Tables["Student"];
                
                dataGridView1.DataSource = dt;
                //DataTable b = dataGridView1.DataSource;
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                if (Con.State != ConnectionState.Closed)
                {
                    Con.Close();
                }
            }
            finally
            {
                Con.Dispose();
            }
        }

      

   

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
        private void btn_Convert_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application xcel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = xcel.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                xcel.Visible = true;
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Exported from gridview";
                for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                {
                    xcel.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value.GetType() == typeof(byte[]))
                        {
                            Image image1 = byteArrayToImage((byte[])dataGridView1.Rows[i].Cells[j].Value);
                            image1.Save(@"C:\Users\84908\OneDrive\Documents\WIN_FORM\Login_form\Login_form\Hinh\Picture.png");
                            Microsoft.Office.Interop.Excel.Range oRange = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[i + 2, j + 1];
                            float Left = (float)((double)oRange.Left);
                            float Top = (float)((double)oRange.Top);
                            worksheet.Shapes.AddPicture(@"C:\Users\84908\OneDrive\Documents\WIN_FORM\Login_form\Login_form\Hinh\Picture.png", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, 32, 32);
                            oRange.RowHeight = 36;
                            File.Delete(@"C:\Users\84908\OneDrive\Documents\WIN_FORM\Login_form\Login_form\Hinh\Picture.png");
                        }
                        else
                            xcel.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                xcel.Columns.AutoFit();
                xcel.Visible = true;
            }
        }
    }
    }
