
namespace Login_form
{
    partial class Khoafr
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Khoafr));
            this.Login = new System.Windows.Forms.Label();
            this.Login_btn = new System.Windows.Forms.Button();
            this.Account_txt = new System.Windows.Forms.TextBox();
            this.Password_txt = new System.Windows.Forms.TextBox();
            this.Pass = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sign_up = new System.Windows.Forms.Button();
            this.stuTableAdapter1 = new Login_form.StudentDataSetTableAdapters.stuTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Login
            // 
            this.Login.AutoSize = true;
            this.Login.BackColor = System.Drawing.SystemColors.MenuText;
            this.Login.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Login.Location = new System.Drawing.Point(349, 104);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(88, 24);
            this.Login.TabIndex = 0;
            this.Login.Text = "Account";
            // 
            // Login_btn
            // 
            this.Login_btn.BackColor = System.Drawing.SystemColors.Control;
            this.Login_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Login_btn.Location = new System.Drawing.Point(204, 351);
            this.Login_btn.Name = "Login_btn";
            this.Login_btn.Size = new System.Drawing.Size(100, 39);
            this.Login_btn.TabIndex = 1;
            this.Login_btn.Text = "Confirm";
            this.Login_btn.UseVisualStyleBackColor = false;
            this.Login_btn.Click += new System.EventHandler(this.Login_btn_Click);
            // 
            // Account_txt
            // 
            this.Account_txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Account_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Account_txt.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.Account_txt.Location = new System.Drawing.Point(83, 156);
            this.Account_txt.Name = "Account_txt";
            this.Account_txt.Size = new System.Drawing.Size(623, 23);
            this.Account_txt.TabIndex = 2;
            this.Account_txt.Click += new System.EventHandler(this.Account_txt_Click);
            // 
            // Password_txt
            // 
            this.Password_txt.BackColor = System.Drawing.SystemColors.HighlightText;
            this.Password_txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Password_txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Password_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_txt.Location = new System.Drawing.Point(83, 274);
            this.Password_txt.Name = "Password_txt";
            this.Password_txt.Size = new System.Drawing.Size(623, 23);
            this.Password_txt.TabIndex = 4;
            this.Password_txt.Click += new System.EventHandler(this.Password_txt_Click);
            // 
            // Pass
            // 
            this.Pass.AutoSize = true;
            this.Pass.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pass.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Pass.Location = new System.Drawing.Point(349, 217);
            this.Pass.Name = "Pass";
            this.Pass.Size = new System.Drawing.Size(103, 24);
            this.Pass.TabIndex = 3;
            this.Pass.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.MenuText;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.PeachPuff;
            this.label1.Location = new System.Drawing.Point(347, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 35);
            this.label1.TabIndex = 5;
            this.label1.Text = "Log in";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(43, 260);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(706, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(43, 143);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(706, 52);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(43, 40);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(746, 72);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.sign_up);
            this.panel1.Controls.Add(this.Login);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Password_txt);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.Pass);
            this.panel1.Controls.Add(this.Account_txt);
            this.panel1.Controls.Add(this.Login_btn);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(97, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 439);
            this.panel1.TabIndex = 10;
            // 
            // sign_up
            // 
            this.sign_up.BackColor = System.Drawing.SystemColors.Control;
            this.sign_up.ForeColor = System.Drawing.SystemColors.ControlText;
            this.sign_up.Location = new System.Drawing.Point(445, 351);
            this.sign_up.Name = "sign_up";
            this.sign_up.Size = new System.Drawing.Size(100, 39);
            this.sign_up.TabIndex = 9;
            this.sign_up.Text = "Sign up";
            this.sign_up.UseVisualStyleBackColor = false;
            this.sign_up.Click += new System.EventHandler(this.sign_up_Click);
            // 
            // stuTableAdapter1
            // 
            this.stuTableAdapter1.ClearBeforeFill = true;
            // 
            // Khoafr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(969, 505);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "Khoafr";
            this.Text = "Tran Dang Khoa";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Login;
        private System.Windows.Forms.Button Login_btn;
        private System.Windows.Forms.TextBox Password_txt;
        private System.Windows.Forms.Label Pass;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox Account_txt;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button sign_up;
        private StudentDataSetTableAdapters.stuTableAdapter stuTableAdapter1;
    }
}

