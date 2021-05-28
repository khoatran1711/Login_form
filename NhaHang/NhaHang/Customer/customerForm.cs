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
using Word = Microsoft.Office.Interop.Word;

namespace NhaHang.Customer
{
    public partial class customerForm : Form
    {
        Class.Food food = new Class.Food();
        Class.Order order = new Class.Order();
        Class.Table tb = new Class.Table();
        Class.Bill bill = new Class.Bill();
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
            foodDataGridView.Columns[2].Width = 160;
            foodDataGridView.Columns[3].Width = 80;
            foodDataGridView.Columns[4].Width = 91;
            foodDataGridView.RowHeadersVisible = false;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            picCol = (DataGridViewImageColumn)foodDataGridView.Columns[1];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            orderDataGridView.DataSource = order.getOrder(oid);
            orderDataGridView.RowHeadersVisible = false;
            orderDataGridView.Columns[0].Width = 190;
            orderDataGridView.Columns[1].Width = 85;
            orderDataGridView.Columns[2].Width = 165;

            dateDateTimePicker.Format = DateTimePickerFormat.Custom;
            dateDateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm:ss";

            tableComboBox.DataSource = tb.getTables();
            tableComboBox.DisplayMember = "id";
            tableComboBox.ValueMember = "id";
            tableComboBox.SelectedItem = null;
        }
        //format datagridview
        private void foodDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            this.foodDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("VNI-Ariston", 12);
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
        private void billDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for (int i = 0; i < billDataGridView.Rows.Count; i++)
            {
                billDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.MistyRose;
            }
        }
        //hien trang thai ban
        public void loadTable()
        {
            table1.Text = "Table 1: "+ tb.slotTable(1) + " seat(s) left";
            table2.Text = "Table 2: " + tb.slotTable(2) + " seat(s) left";
            table3.Text = "Table 3: " + tb.slotTable(3) + " seat(s) left";
            table4.Text = "Table 4: " + tb.slotTable(4) + " seat(s) left";
            table5.Text = "Table 5: " + tb.slotTable(5) + " seat(s) left";
            table6.Text = "Table 6: " + tb.slotTable(6) + " seat(s) left";
            table7.Text = "Table 7: " + tb.slotTable(7) + " seat(s) left";
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
        //xac nhan order
        //load bill
        public void loadBill()
        {
            billDataGridView.DataSource = orderDataGridView.DataSource;
            billDataGridView.RowHeadersVisible = false;
            billDataGridView.Columns[0].Width = 200;
            billDataGridView.Columns[1].Width = 100;
            billDataGridView.Columns[2].Width = 185;
            billDataGridView.Columns[0].HeaderText = "Name";
            billDataGridView.Columns[1].HeaderText = "Amount";
            billDataGridView.Columns[2].HeaderText = "Price";
        }
        private void orderButton_Click(object sender, EventArgs e)
        {

            loadBill();

            costLabel.Text = order.totalCost(oid).ToString();

            tableBillTextBox.Text = tableComboBox.Text;
            dayTextBox.Text = dateDateTimePicker.Text;
            cusNumTextBox.Text = customerNumericUpDown.Value.ToString();

            MessageBox.Show("Order Successfully!!!<3");
        }
        //thanh toan hoa don
        private void payButton_Click(object sender, EventArgs e)
        {
            SavetoWord();
            bill.saveBill(oid,Convert.ToInt32(tableBillTextBox.Text),Convert.ToInt32(cusNumTextBox.Text),dayTextBox.Text,Convert.ToInt32(costLabel.Text));
        }



        //word
        //save to word
        private void SavetoWord()
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.DefaultExt ="*.docx";
            savefile.Filter = "DOCX files(*.docx)|*.docx";

            if (savefile.ShowDialog() == DialogResult.OK && savefile.FileName.Length > 0)
            {
                Export_Data_To_Word(billDataGridView, savefile.FileName);
                MessageBox.Show("File saved!", "Message Dialog", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void Export_Data_To_Word(DataGridView DGV, string filename)
        {
            if (DGV.Rows.Count != 0)
            {
                int Row_Count = DGV.Rows.Count;
                int Col_Count = DGV.Columns.Count;
                Word.Document oDoc = new Word.Document();
                Object oMissing = System.Reflection.Missing.Value;
                oDoc.Application.Visible = true;

                //in ten quan
                //Codefe
                var title = oDoc.Content.Paragraphs.Add(ref oMissing);
                title.Range.Text = "CODEFE BILL";
                title.Range.Bold = 20;
                title.Range.Font.Name = ".VnBahamasBH";
                title.Range.Font.Size = 24;
                title.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                title.Range.InsertParagraphAfter();
                title.Range.Font.Reset();

                //in hotline
                //Codefe
                var hotline = oDoc.Content.Paragraphs.Add(ref oMissing);
                hotline.Range.Text = "Hotline: 0123.xxx.xxx";
                hotline.Range.Bold = 20;
                hotline.Range.Font.Size = 16;
                hotline.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                hotline.Range.InsertParagraphAfter();
                hotline.Range.Font.Reset();
              
                //in thoi gian - ma hoa don
                var timebill = oDoc.Content.Paragraphs.Add(ref oMissing);
                timebill.Range.Text = "Date/time: "+dayTextBox.Text+ "                                     Bill ID: "+oid+"\n";
                timebill.Range.Bold = 20;
                timebill.Range.Font.Size = 16;
                timebill.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                timebill.Range.InsertParagraphAfter();
                timebill.Range.Font.Reset();

                string oTemp = "";
                object b = "\\endofdoc";

                Microsoft.Office.Interop.Word.Table tab;
                Microsoft.Office.Interop.Word.Range rangeof = oDoc.Bookmarks.get_Item(ref b).Range;
                tab = oDoc.Tables.Add(rangeof, Row_Count, Col_Count + 1, ref oMissing, ref oMissing);
                tab.Range.ParagraphFormat.SpaceAfter = 8;
                tab.Rows.Height = 60;
                tab.Cell(1, 1).Range.Text = "STT";
                tab.Cell(1, 1).Range.Paragraphs.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                tab.Cell(1, 1).Range.Bold = 3;
                tab.Cell(1, 1).Range.Font.Color = Word.WdColor.wdColorWhite;

                for (int i = 0; i < Col_Count; i++)
                {
                    tab.Cell(1, i + 2).Range.Text = DGV.Columns[i].HeaderText;
                    tab.Cell(1, i + 2).Range.Paragraphs.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    tab.Cell(1, i + 2).Range.Bold = 3;
                    tab.Cell(1, i + 2).Range.Font.Size = 12;
                    tab.Cell(1, i + 2).Range.Font.Color = Word.WdColor.wdColorWhite;
                }
                tab.Rows[1].Shading.ForegroundPatternColor = Word.WdColor.wdColorBrown;
                tab.Rows[1].Height = 20;

                tab.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                tab.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;

                for (int r = 0; r <= Row_Count - 2; r++)
                {
                    oTemp = "";
                    int c;
                    tab.Cell(r + 2, 1).Range.Text = (r + 1).ToString();
                    for (c = 0; c < Col_Count - 1; c++)
                    {
                        oTemp = DGV.Rows[r].Cells[c].Value.ToString();
                        tab.Cell(r + 2, c + 2).Range.Text = oTemp;
                        tab.Cell(r + 2, c + 2).Range.Paragraphs.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        tab.Cell(r + 2, c + 2).Range.Font.Size = 11;
                    }
                    oTemp = DGV.Rows[r].Cells[c].Value.ToString();
                    tab.Cell(r + 2, c + 2).Range.Text = oTemp;
                    tab.Cell(r + 2, c + 2).Range.Paragraphs.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    tab.Cell(r + 2, c + 2).Range.Font.Size = 11;
                }

                //in tong tien
                //total bill
                var totalbill = oDoc.Content.Paragraphs.Add(ref oMissing);
                totalbill.Range.Text = "Total bill: "+ costLabel.Text;
                totalbill.Range.Bold = 20;
                totalbill.Range.Font.Size = 16;
                totalbill.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                totalbill.Range.InsertParagraphAfter();
                totalbill.Range.Font.Reset();
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }
    }
}
