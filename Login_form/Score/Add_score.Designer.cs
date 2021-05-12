
namespace Login_form.Score
{
    partial class Add_score
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
            this.btn_Add = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Descrip = new System.Windows.Forms.TextBox();
            this.txt_Score = new System.Windows.Forms.TextBox();
            this.txt_Student_ID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbBox_Course = new System.Windows.Forms.ComboBox();
            this.student_list = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.First_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Last_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.student_list)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Add
            // 
            this.btn_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add.Location = new System.Drawing.Point(236, 367);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(233, 50);
            this.btn_Add.TabIndex = 17;
            this.btn_Add.Text = "ADD";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(42, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 33);
            this.label4.TabIndex = 16;
            this.label4.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(99, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 33);
            this.label3.TabIndex = 15;
            this.label3.Text = "Score";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 33);
            this.label1.TabIndex = 13;
            this.label1.Text = "Student ID";
            // 
            // txt_Descrip
            // 
            this.txt_Descrip.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Descrip.Location = new System.Drawing.Point(236, 202);
            this.txt_Descrip.Multiline = true;
            this.txt_Descrip.Name = "txt_Descrip";
            this.txt_Descrip.Size = new System.Drawing.Size(342, 150);
            this.txt_Descrip.TabIndex = 12;
            // 
            // txt_Score
            // 
            this.txt_Score.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Score.Location = new System.Drawing.Point(236, 143);
            this.txt_Score.Name = "txt_Score";
            this.txt_Score.Size = new System.Drawing.Size(210, 34);
            this.txt_Score.TabIndex = 11;
            // 
            // txt_Student_ID
            // 
            this.txt_Student_ID.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Student_ID.Location = new System.Drawing.Point(236, 32);
            this.txt_Student_ID.Name = "txt_Student_ID";
            this.txt_Student_ID.ReadOnly = true;
            this.txt_Student_ID.Size = new System.Drawing.Size(210, 34);
            this.txt_Student_ID.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(83, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 33);
            this.label2.TabIndex = 18;
            this.label2.Text = "Course";
            // 
            // cbBox_Course
            // 
            this.cbBox_Course.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBox_Course.FormattingEnabled = true;
            this.cbBox_Course.Location = new System.Drawing.Point(236, 92);
            this.cbBox_Course.Name = "cbBox_Course";
            this.cbBox_Course.Size = new System.Drawing.Size(210, 33);
            this.cbBox_Course.TabIndex = 19;
            this.cbBox_Course.SelectedIndexChanged += new System.EventHandler(this.cbBox_Course_SelectedIndexChanged);
            // 
            // student_list
            // 
            this.student_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.student_list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.First_Name,
            this.Last_Name});
            this.student_list.Location = new System.Drawing.Point(715, 61);
            this.student_list.Name = "student_list";
            this.student_list.RowHeadersWidth = 51;
            this.student_list.RowTemplate.Height = 24;
            this.student_list.Size = new System.Drawing.Size(567, 356);
            this.student_list.TabIndex = 20;
            this.student_list.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.student_list_CellClick);
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // First_Name
            // 
            this.First_Name.HeaderText = "First Name";
            this.First_Name.MinimumWidth = 6;
            this.First_Name.Name = "First_Name";
            this.First_Name.ReadOnly = true;
            this.First_Name.Width = 125;
            // 
            // Last_Name
            // 
            this.Last_Name.HeaderText = "Last Name";
            this.Last_Name.MinimumWidth = 6;
            this.Last_Name.Name = "Last_Name";
            this.Last_Name.ReadOnly = true;
            this.Last_Name.Width = 125;
            // 
            // Add_score
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 450);
            this.Controls.Add(this.student_list);
            this.Controls.Add(this.cbBox_Course);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Descrip);
            this.Controls.Add(this.txt_Score);
            this.Controls.Add(this.txt_Student_ID);
            this.Name = "Add_score";
            this.Text = "Add_score";
            ((System.ComponentModel.ISupportInitialize)(this.student_list)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Descrip;
        private System.Windows.Forms.TextBox txt_Score;
        private System.Windows.Forms.TextBox txt_Student_ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbBox_Course;
        private System.Windows.Forms.DataGridView student_list;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn First_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Last_Name;
    }
}