
namespace Login_form
{
    partial class FindingMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_find = new System.Windows.Forms.TextBox();
            this.btn_Find = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ra_btn_fname = new System.Windows.Forms.RadioButton();
            this.ra_btn_lname = new System.Windows.Forms.RadioButton();
            this.ra_btn_ID = new System.Windows.Forms.RadioButton();
            this.btn_Convert = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_find
            // 
            this.txt_find.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_find.Location = new System.Drawing.Point(29, 23);
            this.txt_find.Name = "txt_find";
            this.txt_find.Size = new System.Drawing.Size(474, 34);
            this.txt_find.TabIndex = 0;
            // 
            // btn_Find
            // 
            this.btn_Find.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Find.Location = new System.Drawing.Point(523, 25);
            this.btn_Find.Name = "btn_Find";
            this.btn_Find.Size = new System.Drawing.Size(100, 32);
            this.btn_Find.TabIndex = 1;
            this.btn_Find.Text = "&Find ";
            this.btn_Find.UseVisualStyleBackColor = true;
            this.btn_Find.Click += new System.EventHandler(this.btn_Find_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(29, 117);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(715, 297);
            this.dataGridView1.TabIndex = 2;
            // 
            // ra_btn_fname
            // 
            this.ra_btn_fname.AutoSize = true;
            this.ra_btn_fname.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ra_btn_fname.Location = new System.Drawing.Point(63, 80);
            this.ra_btn_fname.Name = "ra_btn_fname";
            this.ra_btn_fname.Size = new System.Drawing.Size(107, 21);
            this.ra_btn_fname.TabIndex = 3;
            this.ra_btn_fname.TabStop = true;
            this.ra_btn_fname.Text = "First Name";
            this.ra_btn_fname.UseVisualStyleBackColor = true;
            // 
            // ra_btn_lname
            // 
            this.ra_btn_lname.AutoSize = true;
            this.ra_btn_lname.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ra_btn_lname.Location = new System.Drawing.Point(241, 80);
            this.ra_btn_lname.Name = "ra_btn_lname";
            this.ra_btn_lname.Size = new System.Drawing.Size(106, 21);
            this.ra_btn_lname.TabIndex = 4;
            this.ra_btn_lname.TabStop = true;
            this.ra_btn_lname.Text = "Last Name";
            this.ra_btn_lname.UseVisualStyleBackColor = true;
            // 
            // ra_btn_ID
            // 
            this.ra_btn_ID.AutoSize = true;
            this.ra_btn_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ra_btn_ID.Location = new System.Drawing.Point(441, 80);
            this.ra_btn_ID.Name = "ra_btn_ID";
            this.ra_btn_ID.Size = new System.Drawing.Size(44, 21);
            this.ra_btn_ID.TabIndex = 5;
            this.ra_btn_ID.TabStop = true;
            this.ra_btn_ID.Text = "ID";
            this.ra_btn_ID.UseVisualStyleBackColor = true;
            // 
            // btn_Convert
            // 
            this.btn_Convert.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Convert.Location = new System.Drawing.Point(643, 25);
            this.btn_Convert.Name = "btn_Convert";
            this.btn_Convert.Size = new System.Drawing.Size(101, 32);
            this.btn_Convert.TabIndex = 6;
            this.btn_Convert.Text = "To Excel";
            this.btn_Convert.UseVisualStyleBackColor = true;
            this.btn_Convert.Click += new System.EventHandler(this.btn_Convert_Click);
            // 
            // FindingMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Convert);
            this.Controls.Add(this.ra_btn_ID);
            this.Controls.Add(this.ra_btn_lname);
            this.Controls.Add(this.ra_btn_fname);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_Find);
            this.Controls.Add(this.txt_find);
            this.Name = "FindingMenu";
            this.Text = "FindingMenu";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_find;
        private System.Windows.Forms.Button btn_Find;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton ra_btn_fname;
        private System.Windows.Forms.RadioButton ra_btn_lname;
        private System.Windows.Forms.RadioButton ra_btn_ID;
        private System.Windows.Forms.Button btn_Convert;
    }
}