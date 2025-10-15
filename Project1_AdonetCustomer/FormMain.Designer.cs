namespace Project1_AdonetCustomer
{
    partial class FormMain
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
            this.btnCityForm = new System.Windows.Forms.Button();
            this.btnCustomerForm = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCityForm
            // 
            this.btnCityForm.Location = new System.Drawing.Point(62, 12);
            this.btnCityForm.Name = "btnCityForm";
            this.btnCityForm.Size = new System.Drawing.Size(170, 79);
            this.btnCityForm.TabIndex = 0;
            this.btnCityForm.Text = "Şehirler";
            this.btnCityForm.UseVisualStyleBackColor = true;
            this.btnCityForm.Click += new System.EventHandler(this.btnCityForm_Click);
            // 
            // btnCustomerForm
            // 
            this.btnCustomerForm.Location = new System.Drawing.Point(62, 113);
            this.btnCustomerForm.Name = "btnCustomerForm";
            this.btnCustomerForm.Size = new System.Drawing.Size(170, 79);
            this.btnCustomerForm.TabIndex = 1;
            this.btnCustomerForm.Text = "Müşteriler";
            this.btnCustomerForm.UseVisualStyleBackColor = true;
            this.btnCustomerForm.Click += new System.EventHandler(this.btnCustomerForm_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(62, 207);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(170, 79);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Çıkış Yap";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.ClientSize = new System.Drawing.Size(291, 303);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCustomerForm);
            this.Controls.Add(this.btnCityForm);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formlar";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCityForm;
        private System.Windows.Forms.Button btnCustomerForm;
        private System.Windows.Forms.Button btnExit;
    }
}