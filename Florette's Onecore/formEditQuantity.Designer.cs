namespace Florette_s_Onecore
{
    partial class formEditQuantity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formEditQuantity));
            this.label1 = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gambar = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.minus = new Guna.UI2.WinForms.Guna2PictureBox();
            this.plus = new Guna.UI2.WinForms.Guna2PictureBox();
            this.labelQty = new System.Windows.Forms.Label();
            this.btnRemove = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.gambar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.plus)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Leelawadee UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(134)))), ((int)(((byte)(127)))));
            this.label1.Location = new System.Drawing.Point(138, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 54);
            this.label1.TabIndex = 26;
            this.label1.Text = "Edit Quantity";
            // 
            // close
            // 
            this.close.AutoSize = true;
            this.close.Font = new System.Drawing.Font("Leelawadee UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(134)))), ((int)(((byte)(127)))));
            this.close.Location = new System.Drawing.Point(718, 35);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(39, 50);
            this.close.TabIndex = 25;
            this.close.Text = "x";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Leelawadee UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(134)))), ((int)(((byte)(127)))));
            this.label2.Location = new System.Drawing.Point(473, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 50);
            this.label2.TabIndex = 27;
            this.label2.Text = "x";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // gambar
            // 
            this.gambar.BackColor = System.Drawing.Color.Transparent;
            this.gambar.BorderRadius = 15;
            this.gambar.ImageRotate = 0F;
            this.gambar.Location = new System.Drawing.Point(180, 111);
            this.gambar.Name = "gambar";
            this.gambar.Size = new System.Drawing.Size(168, 134);
            this.gambar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gambar.TabIndex = 85;
            this.gambar.TabStop = false;
            this.gambar.UseTransparentBackground = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Leelawadee UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(134)))), ((int)(((byte)(127)))));
            this.label11.Location = new System.Drawing.Point(203, 265);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 31);
            this.label11.TabIndex = 89;
            this.label11.Text = "Babi Rica";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Leelawadee UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(134)))), ((int)(((byte)(127)))));
            this.label3.Location = new System.Drawing.Point(102, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 41);
            this.label3.TabIndex = 90;
            this.label3.Text = "Quantity";
            // 
            // minus
            // 
            this.minus.BackColor = System.Drawing.Color.Transparent;
            this.minus.Image = ((System.Drawing.Image)(resources.GetObject("minus.Image")));
            this.minus.ImageRotate = 0F;
            this.minus.Location = new System.Drawing.Point(268, 312);
            this.minus.Name = "minus";
            this.minus.Size = new System.Drawing.Size(28, 28);
            this.minus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.minus.TabIndex = 91;
            this.minus.TabStop = false;
            this.minus.UseTransparentBackground = true;
            this.minus.Click += new System.EventHandler(this.minus_Click);
            // 
            // plus
            // 
            this.plus.BackColor = System.Drawing.Color.Transparent;
            this.plus.Image = ((System.Drawing.Image)(resources.GetObject("plus.Image")));
            this.plus.ImageRotate = 0F;
            this.plus.Location = new System.Drawing.Point(350, 306);
            this.plus.Name = "plus";
            this.plus.Size = new System.Drawing.Size(40, 40);
            this.plus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.plus.TabIndex = 92;
            this.plus.TabStop = false;
            this.plus.UseTransparentBackground = true;
            this.plus.Click += new System.EventHandler(this.minus_Click);
            // 
            // labelQty
            // 
            this.labelQty.AutoSize = true;
            this.labelQty.BackColor = System.Drawing.Color.Transparent;
            this.labelQty.Font = new System.Drawing.Font("Leelawadee UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(134)))), ((int)(((byte)(127)))));
            this.labelQty.Location = new System.Drawing.Point(309, 303);
            this.labelQty.Name = "labelQty";
            this.labelQty.Size = new System.Drawing.Size(35, 41);
            this.labelQty.TabIndex = 93;
            this.labelQty.Text = "1";
            // 
            // btnRemove
            // 
            this.btnRemove.Animated = true;
            this.btnRemove.BackColor = System.Drawing.Color.Transparent;
            this.btnRemove.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(226)))));
            this.btnRemove.BorderRadius = 20;
            this.btnRemove.BorderThickness = 1;
            this.btnRemove.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRemove.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRemove.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRemove.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRemove.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(242)))), ((int)(((byte)(243)))));
            this.btnRemove.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(134)))), ((int)(((byte)(127)))));
            this.btnRemove.Location = new System.Drawing.Point(194, 364);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.btnRemove.ShadowDecoration.CustomizableEdges.BottomLeft = false;
            this.btnRemove.ShadowDecoration.CustomizableEdges.TopLeft = false;
            this.btnRemove.ShadowDecoration.Depth = 10;
            this.btnRemove.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 2, 3);
            this.btnRemove.Size = new System.Drawing.Size(132, 41);
            this.btnRemove.TabIndex = 95;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseTransparentBackground = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnSave
            // 
            this.btnSave.Animated = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(221)))), ((int)(((byte)(226)))));
            this.btnSave.BorderRadius = 20;
            this.btnSave.BorderThickness = 1;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(251)))));
            this.btnSave.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(134)))), ((int)(((byte)(127)))));
            this.btnSave.Location = new System.Drawing.Point(212, 420);
            this.btnSave.Name = "btnSave";
            this.btnSave.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.btnSave.ShadowDecoration.CustomizableEdges.BottomLeft = false;
            this.btnSave.ShadowDecoration.CustomizableEdges.TopLeft = false;
            this.btnSave.ShadowDecoration.Depth = 10;
            this.btnSave.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 2, 3);
            this.btnSave.Size = new System.Drawing.Size(98, 41);
            this.btnSave.TabIndex = 94;
            this.btnSave.Text = "Save";
            this.btnSave.UseTransparentBackground = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // formEditQuantity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 485);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.labelQty);
            this.Controls.Add(this.plus);
            this.Controls.Add(this.minus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.gambar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formEditQuantity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formEditQuantity";
            this.Load += new System.EventHandler(this.formEditQuantity_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gambar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.plus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label close;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2PictureBox gambar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2PictureBox minus;
        private Guna.UI2.WinForms.Guna2PictureBox plus;
        private System.Windows.Forms.Label labelQty;
        private Guna.UI2.WinForms.Guna2Button btnRemove;
        private Guna.UI2.WinForms.Guna2Button btnSave;
    }
}