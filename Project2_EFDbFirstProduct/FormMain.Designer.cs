namespace Project2_EFDbFirstProduct
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
            this.btnCategoriForm = new System.Windows.Forms.Button();
            this.btnProductForm = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCategoriForm
            // 
            this.btnCategoriForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(142)))), ((int)(((byte)(38)))));
            this.btnCategoriForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategoriForm.FlatAppearance.BorderSize = 0;
            this.btnCategoriForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategoriForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategoriForm.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCategoriForm.Location = new System.Drawing.Point(95, 44);
            this.btnCategoriForm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCategoriForm.Name = "btnCategoriForm";
            this.btnCategoriForm.Size = new System.Drawing.Size(230, 114);
            this.btnCategoriForm.TabIndex = 0;
            this.btnCategoriForm.Text = "Kategoriler";
            this.btnCategoriForm.UseVisualStyleBackColor = false;
            this.btnCategoriForm.Click += new System.EventHandler(this.btnCategoriForm_Click);
            // 
            // btnProductForm
            // 
            this.btnProductForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(173)))), ((int)(((byte)(169)))));
            this.btnProductForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductForm.FlatAppearance.BorderSize = 0;
            this.btnProductForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductForm.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnProductForm.Location = new System.Drawing.Point(95, 192);
            this.btnProductForm.Margin = new System.Windows.Forms.Padding(4);
            this.btnProductForm.Name = "btnProductForm";
            this.btnProductForm.Size = new System.Drawing.Size(230, 114);
            this.btnProductForm.TabIndex = 1;
            this.btnProductForm.Text = "Ürünler";
            this.btnProductForm.UseVisualStyleBackColor = false;
            this.btnProductForm.Click += new System.EventHandler(this.btnProductForm_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(47)))), ((int)(((byte)(6)))));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnExit.Location = new System.Drawing.Point(95, 338);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(230, 114);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Çıkış Yap";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(99)))), ((int)(((byte)(130)))));
            this.ClientSize = new System.Drawing.Size(415, 499);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnProductForm);
            this.Controls.Add(this.btnCategoriForm);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menü";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCategoriForm;
        private System.Windows.Forms.Button btnProductForm;
        private System.Windows.Forms.Button btnExit;
    }
}