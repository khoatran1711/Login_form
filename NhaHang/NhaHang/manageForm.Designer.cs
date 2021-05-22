
namespace NhaHang
{
    partial class manageForm
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
            this.manageTabControl = new System.Windows.Forms.TabControl();
            this.StaffTabPage = new System.Windows.Forms.TabPage();
            this.foodTabPage = new System.Windows.Forms.TabPage();
            this.addFoodButton = new System.Windows.Forms.Button();
            this.manageTabControl.SuspendLayout();
            this.foodTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // manageTabControl
            // 
            this.manageTabControl.Controls.Add(this.StaffTabPage);
            this.manageTabControl.Controls.Add(this.foodTabPage);
            this.manageTabControl.Location = new System.Drawing.Point(6, 7);
            this.manageTabControl.Name = "manageTabControl";
            this.manageTabControl.SelectedIndex = 0;
            this.manageTabControl.Size = new System.Drawing.Size(783, 434);
            this.manageTabControl.TabIndex = 0;
            // 
            // StaffTabPage
            // 
            this.StaffTabPage.Location = new System.Drawing.Point(4, 25);
            this.StaffTabPage.Name = "StaffTabPage";
            this.StaffTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.StaffTabPage.Size = new System.Drawing.Size(775, 405);
            this.StaffTabPage.TabIndex = 0;
            this.StaffTabPage.Text = "Staff";
            this.StaffTabPage.UseVisualStyleBackColor = true;
            // 
            // foodTabPage
            // 
            this.foodTabPage.Controls.Add(this.addFoodButton);
            this.foodTabPage.Location = new System.Drawing.Point(4, 25);
            this.foodTabPage.Name = "foodTabPage";
            this.foodTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.foodTabPage.Size = new System.Drawing.Size(775, 405);
            this.foodTabPage.TabIndex = 1;
            this.foodTabPage.Text = "Food&Drink";
            this.foodTabPage.UseVisualStyleBackColor = true;
            // 
            // addFoodButton
            // 
            this.addFoodButton.Location = new System.Drawing.Point(34, 45);
            this.addFoodButton.Name = "addFoodButton";
            this.addFoodButton.Size = new System.Drawing.Size(257, 99);
            this.addFoodButton.TabIndex = 0;
            this.addFoodButton.Text = "Add";
            this.addFoodButton.UseVisualStyleBackColor = true;
            // 
            // manageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.manageTabControl);
            this.Name = "manageForm";
            this.Text = "manageForm";
            this.manageTabControl.ResumeLayout(false);
            this.foodTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl manageTabControl;
        private System.Windows.Forms.TabPage StaffTabPage;
        private System.Windows.Forms.TabPage foodTabPage;
        private System.Windows.Forms.Button addFoodButton;
    }
}