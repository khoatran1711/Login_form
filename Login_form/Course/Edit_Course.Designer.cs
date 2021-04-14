
namespace Login_form.Course
{
    partial class Edit_Course
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
            this.components = new System.ComponentModel.Container();
            this.cbox_Select = new System.Windows.Forms.ComboBox();
            this.courseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studentDataSet1 = new Login_form.StudentDataSet1();
            this.txt_label = new System.Windows.Forms.TextBox();
            this.numUpDo_Period = new System.Windows.Forms.NumericUpDown();
            this.txt_descrip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.courseTableAdapter = new Login_form.StudentDataSet1TableAdapters.CourseTableAdapter();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_remove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.courseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDo_Period)).BeginInit();
            this.SuspendLayout();
            // 
            // cbox_Select
            // 
            this.cbox_Select.DataSource = this.courseBindingSource;
            this.cbox_Select.DisplayMember = "ID";
            this.cbox_Select.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbox_Select.FormattingEnabled = true;
            this.cbox_Select.Location = new System.Drawing.Point(206, 45);
            this.cbox_Select.Name = "cbox_Select";
            this.cbox_Select.Size = new System.Drawing.Size(223, 34);
            this.cbox_Select.TabIndex = 0;
            this.cbox_Select.ValueMember = "ID";
            this.cbox_Select.SelectedIndexChanged += new System.EventHandler(this.cbox_Select_SelectedIndexChanged);
            // 
            // courseBindingSource
            // 
            this.courseBindingSource.DataMember = "Course";
            this.courseBindingSource.DataSource = this.studentDataSet1;
            // 
            // studentDataSet1
            // 
            this.studentDataSet1.DataSetName = "StudentDataSet1";
            this.studentDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txt_label
            // 
            this.txt_label.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_label.Location = new System.Drawing.Point(206, 102);
            this.txt_label.Name = "txt_label";
            this.txt_label.Size = new System.Drawing.Size(288, 34);
            this.txt_label.TabIndex = 1;
            // 
            // numUpDo_Period
            // 
            this.numUpDo_Period.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numUpDo_Period.Location = new System.Drawing.Point(206, 151);
            this.numUpDo_Period.Name = "numUpDo_Period";
            this.numUpDo_Period.Size = new System.Drawing.Size(223, 34);
            this.numUpDo_Period.TabIndex = 2;
            // 
            // txt_descrip
            // 
            this.txt_descrip.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_descrip.Location = new System.Drawing.Point(206, 213);
            this.txt_descrip.Multiline = true;
            this.txt_descrip.Name = "txt_descrip";
            this.txt_descrip.Size = new System.Drawing.Size(367, 148);
            this.txt_descrip.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 27);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select Course";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(115, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 27);
            this.label2.TabIndex = 5;
            this.label2.Text = "Label";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(107, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 27);
            this.label3.TabIndex = 6;
            this.label3.Text = "Period";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(59, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 27);
            this.label4.TabIndex = 7;
            this.label4.Text = "Description";
            // 
            // courseTableAdapter
            // 
            this.courseTableAdapter.ClearBeforeFill = true;
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(206, 380);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(138, 40);
            this.btn_edit.TabIndex = 8;
            this.btn_edit.Text = "Edit";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_remove
            // 
            this.btn_remove.Location = new System.Drawing.Point(411, 380);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(138, 40);
            this.btn_remove.TabIndex = 9;
            this.btn_remove.Text = "Remove";
            this.btn_remove.UseVisualStyleBackColor = true;
            this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
            // 
            // Edit_Course
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_remove);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_descrip);
            this.Controls.Add(this.numUpDo_Period);
            this.Controls.Add(this.txt_label);
            this.Controls.Add(this.cbox_Select);
            this.Name = "Edit_Course";
            this.Text = "Edit_Course";
            ((System.ComponentModel.ISupportInitialize)(this.courseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDo_Period)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbox_Select;
        private System.Windows.Forms.TextBox txt_label;
        private System.Windows.Forms.NumericUpDown numUpDo_Period;
        private System.Windows.Forms.TextBox txt_descrip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private StudentDataSet1 studentDataSet1;
        private System.Windows.Forms.BindingSource courseBindingSource;
        private StudentDataSet1TableAdapters.CourseTableAdapter courseTableAdapter;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_remove;
    }
}