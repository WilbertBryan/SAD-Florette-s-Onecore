namespace Florette_s_Onecore
{
    partial class formEditPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formEditPassword));
            this.close = new System.Windows.Forms.Label();
            this.txtBoxNewPas = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelIncorrect = new System.Windows.Forms.Label();
            this.VisibleOn2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.txtBoxCurrentPas = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelEditPassword = new System.Windows.Forms.Label();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.labelEditUsername = new System.Windows.Forms.Label();
            this.VisibleOff1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txtBoxConfirmPas = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.VisibleOn3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.VisibleOn1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.VisibleOff2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.VisibleOff3 = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.VisibleOn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisibleOff1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisibleOn3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisibleOn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisibleOff2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisibleOff3)).BeginInit();
            this.SuspendLayout();
            // 
            // close
            // 
            this.close.AutoSize = true;
            this.close.Font = new System.Drawing.Font("Leelawadee UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(134)))), ((int)(((byte)(127)))));
            this.close.Location = new System.Drawing.Point(658, 9);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(30, 38);
            this.close.TabIndex = 24;
            this.close.Text = "x";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // txtBoxNewPas
            // 
            this.txtBoxNewPas.AutoRoundedCorners = true;
            this.txtBoxNewPas.BorderRadius = 19;
            this.txtBoxNewPas.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBoxNewPas.DefaultText = "";
            this.txtBoxNewPas.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBoxNewPas.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBoxNewPas.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxNewPas.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxNewPas.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxNewPas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBoxNewPas.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxNewPas.Location = new System.Drawing.Point(241, 226);
            this.txtBoxNewPas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBoxNewPas.Name = "txtBoxNewPas";
            this.txtBoxNewPas.PasswordChar = '\0';
            this.txtBoxNewPas.PlaceholderText = "";
            this.txtBoxNewPas.SelectedText = "";
            this.txtBoxNewPas.Size = new System.Drawing.Size(211, 40);
            this.txtBoxNewPas.TabIndex = 51;
            this.txtBoxNewPas.Leave += new System.EventHandler(this.txtBoxNewPas_Leave);
            // 
            // labelIncorrect
            // 
            this.labelIncorrect.AutoSize = true;
            this.labelIncorrect.ForeColor = System.Drawing.Color.IndianRed;
            this.labelIncorrect.Location = new System.Drawing.Point(263, 364);
            this.labelIncorrect.Name = "labelIncorrect";
            this.labelIncorrect.Size = new System.Drawing.Size(154, 16);
            this.labelIncorrect.TabIndex = 50;
            this.labelIncorrect.Text = "Username Already Exist.";
            this.labelIncorrect.Visible = false;
            // 
            // VisibleOn2
            // 
            this.VisibleOn2.BackColor = System.Drawing.Color.Transparent;
            this.VisibleOn2.Image = ((System.Drawing.Image)(resources.GetObject("VisibleOn2.Image")));
            this.VisibleOn2.ImageRotate = 0F;
            this.VisibleOn2.Location = new System.Drawing.Point(458, 235);
            this.VisibleOn2.Name = "VisibleOn2";
            this.VisibleOn2.Size = new System.Drawing.Size(25, 25);
            this.VisibleOn2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.VisibleOn2.TabIndex = 49;
            this.VisibleOn2.TabStop = false;
            this.VisibleOn2.UseTransparentBackground = true;
            this.VisibleOn2.Click += new System.EventHandler(this.VisibleOn2_Click);
            // 
            // btnSave
            // 
            this.btnSave.Animated = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderRadius = 15;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(199)))), ((int)(((byte)(174)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(286, 383);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.TabIndex = 48;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseTransparentBackground = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtBoxCurrentPas
            // 
            this.txtBoxCurrentPas.AutoRoundedCorners = true;
            this.txtBoxCurrentPas.BorderRadius = 19;
            this.txtBoxCurrentPas.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBoxCurrentPas.DefaultText = "";
            this.txtBoxCurrentPas.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBoxCurrentPas.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBoxCurrentPas.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxCurrentPas.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxCurrentPas.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxCurrentPas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBoxCurrentPas.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxCurrentPas.Location = new System.Drawing.Point(241, 141);
            this.txtBoxCurrentPas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBoxCurrentPas.Name = "txtBoxCurrentPas";
            this.txtBoxCurrentPas.PasswordChar = '\0';
            this.txtBoxCurrentPas.PlaceholderText = "";
            this.txtBoxCurrentPas.SelectedText = "";
            this.txtBoxCurrentPas.Size = new System.Drawing.Size(211, 40);
            this.txtBoxCurrentPas.TabIndex = 47;
            this.txtBoxCurrentPas.Leave += new System.EventHandler(this.txtBoxCurrentPas_Leave_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Leelawadee UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(134)))), ((int)(((byte)(127)))));
            this.label1.Location = new System.Drawing.Point(176, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 45);
            this.label1.TabIndex = 46;
            this.label1.Text = "CHANGE USERNAME";
            // 
            // labelEditPassword
            // 
            this.labelEditPassword.AutoSize = true;
            this.labelEditPassword.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEditPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(134)))), ((int)(((byte)(127)))));
            this.labelEditPassword.Location = new System.Drawing.Point(268, 190);
            this.labelEditPassword.Name = "labelEditPassword";
            this.labelEditPassword.Size = new System.Drawing.Size(138, 28);
            this.labelEditPassword.TabIndex = 45;
            this.labelEditPassword.Text = "New Password";
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox2.Image")));
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.InitialImage = null;
            this.guna2PictureBox2.Location = new System.Drawing.Point(241, 194);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(25, 25);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox2.TabIndex = 44;
            this.guna2PictureBox2.TabStop = false;
            this.guna2PictureBox2.UseTransparentBackground = true;
            // 
            // labelEditUsername
            // 
            this.labelEditUsername.AutoSize = true;
            this.labelEditUsername.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEditUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(134)))), ((int)(((byte)(127)))));
            this.labelEditUsername.Location = new System.Drawing.Point(268, 109);
            this.labelEditUsername.Name = "labelEditUsername";
            this.labelEditUsername.Size = new System.Drawing.Size(164, 28);
            this.labelEditUsername.TabIndex = 42;
            this.labelEditUsername.Text = "Current Password";
            // 
            // VisibleOff1
            // 
            this.VisibleOff1.BackColor = System.Drawing.Color.Transparent;
            this.VisibleOff1.Image = ((System.Drawing.Image)(resources.GetObject("VisibleOff1.Image")));
            this.VisibleOff1.ImageRotate = 0F;
            this.VisibleOff1.Location = new System.Drawing.Point(458, 150);
            this.VisibleOff1.Name = "VisibleOff1";
            this.VisibleOff1.Size = new System.Drawing.Size(25, 25);
            this.VisibleOff1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.VisibleOff1.TabIndex = 52;
            this.VisibleOff1.TabStop = false;
            this.VisibleOff1.UseTransparentBackground = true;
            this.VisibleOff1.Visible = false;
            this.VisibleOff1.Click += new System.EventHandler(this.VisibleOff1_Click);
            // 
            // guna2PictureBox3
            // 
            this.guna2PictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox3.Image")));
            this.guna2PictureBox3.ImageRotate = 0F;
            this.guna2PictureBox3.InitialImage = null;
            this.guna2PictureBox3.Location = new System.Drawing.Point(241, 110);
            this.guna2PictureBox3.Name = "guna2PictureBox3";
            this.guna2PictureBox3.Size = new System.Drawing.Size(25, 25);
            this.guna2PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox3.TabIndex = 53;
            this.guna2PictureBox3.TabStop = false;
            this.guna2PictureBox3.UseTransparentBackground = true;
            // 
            // txtBoxConfirmPas
            // 
            this.txtBoxConfirmPas.AutoRoundedCorners = true;
            this.txtBoxConfirmPas.BorderRadius = 19;
            this.txtBoxConfirmPas.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBoxConfirmPas.DefaultText = "";
            this.txtBoxConfirmPas.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBoxConfirmPas.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBoxConfirmPas.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxConfirmPas.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxConfirmPas.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxConfirmPas.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBoxConfirmPas.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxConfirmPas.Location = new System.Drawing.Point(241, 308);
            this.txtBoxConfirmPas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBoxConfirmPas.Name = "txtBoxConfirmPas";
            this.txtBoxConfirmPas.PasswordChar = '\0';
            this.txtBoxConfirmPas.PlaceholderText = "";
            this.txtBoxConfirmPas.SelectedText = "";
            this.txtBoxConfirmPas.Size = new System.Drawing.Size(211, 40);
            this.txtBoxConfirmPas.TabIndex = 56;
            this.txtBoxConfirmPas.Leave += new System.EventHandler(this.txtBoxConfirmPas_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Leelawadee UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(134)))), ((int)(((byte)(127)))));
            this.label2.Location = new System.Drawing.Point(268, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 28);
            this.label2.TabIndex = 55;
            this.label2.Text = "Confirm New Password";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.InitialImage = null;
            this.guna2PictureBox1.Location = new System.Drawing.Point(241, 276);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(25, 25);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 54;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
            // 
            // VisibleOn3
            // 
            this.VisibleOn3.BackColor = System.Drawing.Color.Transparent;
            this.VisibleOn3.Image = ((System.Drawing.Image)(resources.GetObject("VisibleOn3.Image")));
            this.VisibleOn3.ImageRotate = 0F;
            this.VisibleOn3.Location = new System.Drawing.Point(458, 315);
            this.VisibleOn3.Name = "VisibleOn3";
            this.VisibleOn3.Size = new System.Drawing.Size(25, 25);
            this.VisibleOn3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.VisibleOn3.TabIndex = 57;
            this.VisibleOn3.TabStop = false;
            this.VisibleOn3.UseTransparentBackground = true;
            this.VisibleOn3.Click += new System.EventHandler(this.VisibleOn3_Click);
            // 
            // VisibleOn1
            // 
            this.VisibleOn1.BackColor = System.Drawing.Color.Transparent;
            this.VisibleOn1.Image = ((System.Drawing.Image)(resources.GetObject("VisibleOn1.Image")));
            this.VisibleOn1.ImageRotate = 0F;
            this.VisibleOn1.Location = new System.Drawing.Point(458, 150);
            this.VisibleOn1.Name = "VisibleOn1";
            this.VisibleOn1.Size = new System.Drawing.Size(25, 25);
            this.VisibleOn1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.VisibleOn1.TabIndex = 58;
            this.VisibleOn1.TabStop = false;
            this.VisibleOn1.UseTransparentBackground = true;
            this.VisibleOn1.Click += new System.EventHandler(this.VisibleOn1_Click_1);
            // 
            // VisibleOff2
            // 
            this.VisibleOff2.BackColor = System.Drawing.Color.Transparent;
            this.VisibleOff2.Image = ((System.Drawing.Image)(resources.GetObject("VisibleOff2.Image")));
            this.VisibleOff2.ImageRotate = 0F;
            this.VisibleOff2.Location = new System.Drawing.Point(458, 235);
            this.VisibleOff2.Name = "VisibleOff2";
            this.VisibleOff2.Size = new System.Drawing.Size(25, 25);
            this.VisibleOff2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.VisibleOff2.TabIndex = 59;
            this.VisibleOff2.TabStop = false;
            this.VisibleOff2.UseTransparentBackground = true;
            this.VisibleOff2.Visible = false;
            this.VisibleOff2.Click += new System.EventHandler(this.VisibleOff2_Click);
            // 
            // VisibleOff3
            // 
            this.VisibleOff3.BackColor = System.Drawing.Color.Transparent;
            this.VisibleOff3.Image = ((System.Drawing.Image)(resources.GetObject("VisibleOff3.Image")));
            this.VisibleOff3.ImageRotate = 0F;
            this.VisibleOff3.Location = new System.Drawing.Point(458, 315);
            this.VisibleOff3.Name = "VisibleOff3";
            this.VisibleOff3.Size = new System.Drawing.Size(25, 25);
            this.VisibleOff3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.VisibleOff3.TabIndex = 60;
            this.VisibleOff3.TabStop = false;
            this.VisibleOff3.UseTransparentBackground = true;
            this.VisibleOff3.Visible = false;
            this.VisibleOff3.Click += new System.EventHandler(this.VisibleOff3_Click);
            // 
            // formEditPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(239)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(700, 450);
            this.Controls.Add(this.VisibleOff3);
            this.Controls.Add(this.VisibleOff2);
            this.Controls.Add(this.VisibleOn1);
            this.Controls.Add(this.VisibleOn3);
            this.Controls.Add(this.txtBoxConfirmPas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.guna2PictureBox3);
            this.Controls.Add(this.VisibleOff1);
            this.Controls.Add(this.txtBoxNewPas);
            this.Controls.Add(this.labelIncorrect);
            this.Controls.Add(this.VisibleOn2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtBoxCurrentPas);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelEditPassword);
            this.Controls.Add(this.guna2PictureBox2);
            this.Controls.Add(this.labelEditUsername);
            this.Controls.Add(this.close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formEditPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formEditPassword";
            this.Load += new System.EventHandler(this.formEditPassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VisibleOn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisibleOff1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisibleOn3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisibleOn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisibleOff2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisibleOff3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label close;
        private Guna.UI2.WinForms.Guna2TextBox txtBoxNewPas;
        private System.Windows.Forms.Label labelIncorrect;
        private Guna.UI2.WinForms.Guna2PictureBox VisibleOn2;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2TextBox txtBoxCurrentPas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelEditPassword;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private System.Windows.Forms.Label labelEditUsername;
        private Guna.UI2.WinForms.Guna2PictureBox VisibleOff1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox3;
        private Guna.UI2.WinForms.Guna2TextBox txtBoxConfirmPas;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2PictureBox VisibleOn3;
        private Guna.UI2.WinForms.Guna2PictureBox VisibleOn1;
        private Guna.UI2.WinForms.Guna2PictureBox VisibleOff2;
        private Guna.UI2.WinForms.Guna2PictureBox VisibleOff3;
    }
}