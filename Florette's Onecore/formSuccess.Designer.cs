namespace Florette_s_Onecore
{
    partial class formSuccess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formSuccess));
            this.Centang = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Centang)).BeginInit();
            this.SuspendLayout();
            // 
            // Centang
            // 
            this.Centang.BackColor = System.Drawing.Color.Transparent;
            this.Centang.Image = ((System.Drawing.Image)(resources.GetObject("Centang.Image")));
            this.Centang.ImageRotate = 0F;
            this.Centang.Location = new System.Drawing.Point(175, 103);
            this.Centang.Name = "Centang";
            this.Centang.Size = new System.Drawing.Size(200, 200);
            this.Centang.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Centang.TabIndex = 0;
            this.Centang.TabStop = false;
            this.Centang.UseTransparentBackground = true;
            // 
            // label
            // 
            this.label.Font = new System.Drawing.Font("Leelawadee UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(134)))), ((int)(((byte)(127)))));
            this.label.Location = new System.Drawing.Point(98, 269);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(360, 186);
            this.label.TabIndex = 5;
            this.label.Text = "Your Account Has Been Successfully Changed";
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // close
            // 
            this.close.AutoSize = true;
            this.close.Font = new System.Drawing.Font("Leelawadee UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(134)))), ((int)(((byte)(127)))));
            this.close.Location = new System.Drawing.Point(492, -2);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(39, 50);
            this.close.TabIndex = 22;
            this.close.Text = "x";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // formSuccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(543, 490);
            this.Controls.Add(this.close);
            this.Controls.Add(this.Centang);
            this.Controls.Add(this.label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formSuccess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formSuccess";
            this.Load += new System.EventHandler(this.formSuccess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Centang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox Centang;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label close;
    }
}