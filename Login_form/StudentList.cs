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
using iTextSharp.text.pdf;
using iTextSharp.text;

using Word = Microsoft.Office.Interop.Word;



using System.Drawing.Drawing2D;

namespace Login_form
{
    public partial class StudentList : Form
    {
        public StudentList()
        {
            InitializeComponent();
        }

        private void StudentList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentDataSet.stu' table. You can move, or remove it, as needed.
            this.stuTableAdapter.Fill(this.studentDataSet.stu);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editform edi = new editform();
            edi.txt_ID.Text = list.CurrentRow.Cells[0].Value.ToString();
            edi.txt_firstname.Text = this.list.CurrentRow.Cells[1].Value.ToString();
            edi.txt_lastname.Text = this.list.CurrentRow.Cells[2].Value.ToString();
            edi.dt_brt.Value = (DateTime)this.list.CurrentRow.Cells[3].Value;
            if (this.list.CurrentRow.Cells[4].Value.ToString() == "Male") edi.ra_btn_Male.Checked = true;
            if (this.list.CurrentRow.Cells[4].Value.ToString() == "Female") edi.ra_btn_female.Checked = true;
            if (this.list.CurrentRow.Cells[4].Value.ToString() == "Other") edi.ra_btn_other.Checked = true;
            edi.txt_phone.Text = this.list.CurrentRow.Cells[5].Value.ToString();
            edi.txt_address.Text = this.list.CurrentRow.Cells[6].Value.ToString();
            byte[] pic = (byte[])this.list.CurrentRow.Cells[7].Value;
            MemoryStream ms = new MemoryStream(pic);
            edi.pic_box.Image = System.Drawing.Image.FromStream(ms);
            edi.ShowDialog();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            StudentList_Load(sender,e);
        }

        public System.Drawing.Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
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

        public static Bitmap ResizeImage(System.Drawing.Image image, int width, int height)
        {
            var destRect = new System.Drawing.Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);
            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }
        // Print to Word
        public void Export_Data_To_Word(DataGridView DGV, string filename)
        {
            
            if (list.Rows.Count != 0)
            {
                int Row_Count = list.Rows.Count;
                int Col_Count = list.Columns.Count;
                Word.Document oDoc = new Word.Document();
                Object oMissing = System.Reflection.Missing.Value;
                oDoc.Application.Visible = true;
                // DEM SO NAM - NU
                int count_nam = 0;
                int count_nu = 0;
                for (int i=0;i<Row_Count;i++)
                {
                    if (list.Rows[i].Cells[4].Value.ToString() == "Male") count_nam++;
                    if (list.Rows[i].Cells[4].Value.ToString() == "Male") count_nu++;
                }

                string oTemp = "";
               
                object b = "\\endofdoc";
                // TAO TEU DE
                var Title = oDoc.Content.Paragraphs.Add(ref oMissing);
                Title.Range.Text = "DANH SACH SINH VIEN ";
                Title.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                Title.Range.Font.Size = 40;
                Title.Range.Font.Bold = 30;
                Title.Range.Font.Color = Word.WdColor.wdColorDarkBlue;
                Title.Range.InsertParagraphAfter();
                Title.Range.Font.Reset();
                // TONG SO SINH VIEN
                var Total= oDoc.Content.Paragraphs.Add(ref oMissing);
                Total.Range.Text = "So Luong Sinh Vien: " + list.Rows.Count.ToString();
                Total.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                Total.Range.Font.Italic = 20;
                Total.Range.Font.Color = Word.WdColor.wdColorBlue;
                Total.Range.InsertParagraphAfter();
                Total.Range.Font.Reset();
                // BANG THONG TIN SV
                Microsoft.Office.Interop.Word.Table tab;
                Microsoft.Office.Interop.Word.Range rangeof = oDoc.Bookmarks.get_Item(ref b).Range;
                tab = oDoc.Tables.Add(rangeof, Row_Count+1, Col_Count+1, ref oMissing, ref oMissing);
                tab.Range.ParagraphFormat.SpaceAfter = 8;
                tab.Rows.Height = 80;
                tab.Cell(1, 1).Range.Text = "STT";
                tab.Cell(1, 1).Range.Paragraphs.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                tab.Cell(1, 1).Range.Bold = 5;
                for (int i=0;i < Col_Count;i++)
                {                   
                    tab.Cell(1, i + 2).Range.Text = list.Columns[i].HeaderText;
                    tab.Cell(1, i + 2).Range.Paragraphs.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    tab.Cell(1, i + 2).Range.Bold = 5;
                }
                tab.Rows[1].Shading.ForegroundPatternColor = Word.WdColor.wdColorAqua;
                tab.Rows[1].Height = 30;
                tab.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                tab.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                for (int r = 0; r <= Row_Count - 1; r++)
                {
                    oTemp = "";
                    int c;
                    tab.Cell(r + 2, 1).Range.Text = (r + 1).ToString();
                    tab.Cell(r + 2, 1).Range.Paragraphs.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    for (c = 0; c < Col_Count-1 ; c++)
                    {
                        oTemp = list.Rows[r].Cells[c].Value.ToString();
                        tab.Cell(r+2, c+2).Range.Text = oTemp;
                        tab.Cell(r + 2, c + 2).Range.Paragraphs.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    }
                    System.Drawing.Image image1 = byteArrayToImage((byte[])list.Rows[r].Cells[c].Value);
                    System.Drawing.Image finalPic = (System.Drawing.Image)(new Bitmap(image1, new Size(100, 150)));
                    finalPic.Save(@"C:\Users\84908\OneDrive\Documents\WIN_FORM\Login_form\Login_form\Hinh\Picture.png");
                    tab.Cell(r + 2, c + 2).Range.InlineShapes.AddPicture(@"C:\Users\84908\OneDrive\Documents\WIN_FORM\Login_form\Login_form\Hinh\Picture.png");
                    File.Delete(@"C:\Users\84908\OneDrive\Documents\WIN_FORM\Login_form\Login_form\Hinh\Picture.png");                 
                }
                // SL SV NAM
                var Total_Male = oDoc.Content.Paragraphs.Add(ref oMissing);
                Total_Male.Range.Text = "Nam : " + count_nam.ToString()+ " (SV)";
                Total_Male.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                Total_Male.Range.Font.Italic = 20;
                Total_Male.Range.Font.Color = Word.WdColor.wdColorDarkBlue;
                Total_Male.Range.InsertParagraphAfter();
                Total_Male.Range.Font.Reset();
                // SL SV NU
                var Total_Female = oDoc.Content.Paragraphs.Add(ref oMissing);
                Total_Female.Range.Text = "Nu : " + count_nu.ToString() + " (SV)";
                Total_Female.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                Total_Female.Range.Font.Italic = 20;
                Total_Female.Range.Font.Color = Word.WdColor.wdColorDarkBlue;
                Total_Female.Range.InsertParagraphAfter();
                Total_Female.Range.Font.Reset();
                oDoc.SaveAs2(filename);
            }
        }

        private void To_Word_Click(object sender, EventArgs e)
        {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Word Documents (.docx)|.docx";
                sfd.FileName = "Worldfile.docx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Export_Data_To_Word(list, sfd.FileName);
                }
        }
        // Print to PDF 
        private void To_PDF_Click(object sender, EventArgs e)
        {
            if (list.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf"; bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(list.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                            foreach (DataGridViewColumn column in list.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }
                            foreach (DataGridViewRow row in list.Rows)
                            {
                                string id = row.Cells[0].Value.ToString();
                                pdfTable.AddCell(id);
                                string Fname = row.Cells[1].Value.ToString();
                                pdfTable.AddCell(Fname);
                                string Lname = row.Cells[2].Value.ToString();
                                pdfTable.AddCell(Lname);
                                string Bdate = row.Cells[3].Value.ToString();
                                pdfTable.AddCell(Bdate);
                                string gender = row.Cells[4].Value.ToString();
                                pdfTable.AddCell(gender);
                                string phone = row.Cells[5].Value.ToString();
                                pdfTable.AddCell(phone);
                                string address = row.Cells[6].Value.ToString();
                                pdfTable.AddCell(address);
                                byte[] imageByte = (byte[])row.Cells[7].Value;
                                iTextSharp.text.Image Image = iTextSharp.text.Image.GetInstance(imageByte);   
                                pdfTable.AddCell(Image);
                            }
                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream); pdfDoc.Open();
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }
                            MessageBox.Show("Data Exported Successfully !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }
    }
 }
    


