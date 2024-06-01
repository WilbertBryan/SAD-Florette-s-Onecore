namespace Florette_s_Onecore
{
    partial class ChooseRole
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseRole));
            this.guna2PictureBox3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.Owner = new Guna.UI2.WinForms.Guna2PictureBox();
            this.Staff = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Owner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Staff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2PictureBox3
            // 
            this.guna2PictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2PictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox3.Image")));
            this.guna2PictureBox3.ImageRotate = 0F;
            this.guna2PictureBox3.Location = new System.Drawing.Point(-7, -10);
            this.guna2PictureBox3.Name = "guna2PictureBox3";
            this.guna2PictureBox3.Size = new System.Drawing.Size(2066, 1045);
            this.guna2PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox3.TabIndex = 21;
            this.guna2PictureBox3.TabStop = false;
            // 
            // Owner
            // 
            this.Owner.BackColor = System.Drawing.Color.Transparent;
            this.Owner.Image = ((System.Drawing.Image)(resources.GetObject("Owner.Image")));
            this.Owner.ImageRotate = 0F;
            this.Owner.Location = new System.Drawing.Point(509, 329);
            this.Owner.Name = "Owner";
            this.Owner.Size = new System.Drawing.Size(480, 450);
            this.Owner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Owner.TabIndex = 23;
            this.Owner.TabStop = false;
            this.Owner.UseTransparentBackground = true;
            this.Owner.Click += new System.EventHandler(this.Owner_Click);
            // 
            // Staff
            // 
            this.Staff.BackColor = System.Drawing.Color.Transparent;
            this.Staff.Image = ((System.Drawing.Image)(resources.GetObject("Staff.Image")));
            this.Staff.ImageRotate = 0F;
            this.Staff.Location = new System.Drawing.Point(1072, 329);
            this.Staff.Name = "Staff";
            this.Staff.Size = new System.Drawing.Size(480, 450);
            this.Staff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Staff.TabIndex = 24;
            this.Staff.TabStop = false;
            this.Staff.UseTransparentBackground = true;
            this.Staff.Click += new System.EventHandler(this.Staff_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = global::Florette_s_Onecore.Properties.Resources.CHOOSE_YOUR_POSITION;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(277, 160);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(1150, 68);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.guna2PictureBox1.TabIndex = 25;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
            // 
            // ChooseRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(215)))), ((int)(((byte)(197)))));
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.Staff);
            this.Controls.Add(this.Owner);
            this.Controls.Add(this.guna2PictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ChooseRole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Florette\'s Onecore";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Owner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Staff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox3;
        private Guna.UI2.WinForms.Guna2PictureBox Owner;
        private Guna.UI2.WinForms.Guna2PictureBox Staff;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}