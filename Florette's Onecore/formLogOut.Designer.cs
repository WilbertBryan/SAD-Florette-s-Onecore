namespace Florette_s_Onecore
{
    partial class formLogOut
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnYes = new Guna.UI2.WinForms.Guna2Button();
            this.btnNo = new Guna.UI2.WinForms.Guna2Button();
            this.close = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Leelawadee UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(134)))), ((int)(((byte)(127)))));
            this.label1.Location = new System.Drawing.Point(63, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 41);
            this.label1.TabIndex = 5;
            this.label1.Text = "Do you want to log out?";
            // 
            // btnYes
            // 
            this.btnYes.Animated = true;
            this.btnYes.BackColor = System.Drawing.Color.Transparent;
            this.btnYes.BorderColor = System.Drawing.Color.Transparent;
            this.btnYes.BorderRadius = 15;
            this.btnYes.BorderThickness = 2;
            this.btnYes.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnYes.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnYes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnYes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnYes.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(204)))));
            this.btnYes.Font = new System.Drawing.Font("Leelawadee UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(134)))), ((int)(((byte)(127)))));
            this.btnYes.Location = new System.Drawing.Point(103, 159);
            this.btnYes.Name = "btnYes";
            this.btnYes.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.btnYes.ShadowDecoration.CustomizableEdges.BottomLeft = false;
            this.btnYes.ShadowDecoration.CustomizableEdges.TopLeft = false;
            this.btnYes.ShadowDecoration.Depth = 5;
            this.btnYes.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 2, 3);
            this.btnYes.Size = new System.Drawing.Size(89, 46);
            this.btnYes.TabIndex = 50;
            this.btnYes.Text = "Yes";
            this.btnYes.UseTransparentBackground = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.Animated = true;
            this.btnNo.BackColor = System.Drawing.Color.Transparent;
            this.btnNo.BorderColor = System.Drawing.Color.Transparent;
            this.btnNo.BorderRadius = 15;
            this.btnNo.BorderThickness = 2;
            this.btnNo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(241)))), ((int)(((byte)(232)))));
            this.btnNo.Font = new System.Drawing.Font("Leelawadee UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(134)))), ((int)(((byte)(127)))));
            this.btnNo.Location = new System.Drawing.Point(295, 159);
            this.btnNo.Name = "btnNo";
            this.btnNo.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.btnNo.ShadowDecoration.CustomizableEdges.BottomLeft = false;
            this.btnNo.ShadowDecoration.CustomizableEdges.TopLeft = false;
            this.btnNo.ShadowDecoration.Depth = 5;
            this.btnNo.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 2, 3);
            this.btnNo.Size = new System.Drawing.Size(89, 46);
            this.btnNo.TabIndex = 51;
            this.btnNo.Text = "No";
            this.btnNo.UseTransparentBackground = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // close
            // 
            this.close.AutoSize = true;
            this.close.Font = new System.Drawing.Font("Leelawadee UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(134)))), ((int)(((byte)(127)))));
            this.close.Location = new System.Drawing.Point(447, 9);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(35, 45);
            this.close.TabIndex = 79;
            this.close.Text = "x";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // formLogOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 259);
            this.Controls.Add(this.close);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formLogOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formLogOut";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnYes;
        private Guna.UI2.WinForms.Guna2Button btnNo;
        private System.Windows.Forms.Label close;
    }
}