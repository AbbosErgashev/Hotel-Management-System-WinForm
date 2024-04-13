namespace HotelManagmentSystem
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel1 = new Panel();
            ContinueLink = new Label();
            LoginBtn = new Button();
            label3 = new Label();
            label2 = new Label();
            PasswordTbl = new TextBox();
            UnameTbl = new TextBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(ContinueLink);
            panel1.Controls.Add(LoginBtn);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(PasswordTbl);
            panel1.Controls.Add(UnameTbl);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(769, 440);
            panel1.TabIndex = 0;
            // 
            // ContinueLink
            // 
            ContinueLink.AutoSize = true;
            ContinueLink.Font = new Font("Segoe UI", 10.8F, FontStyle.Underline, GraphicsUnit.Point, 204);
            ContinueLink.Location = new Point(316, 359);
            ContinueLink.Name = "ContinueLink";
            ContinueLink.Size = new Size(163, 25);
            ContinueLink.TabIndex = 4;
            ContinueLink.Text = "Continue as Admin";
            ContinueLink.Click += ContinueLink_Click;
            // 
            // LoginBtn
            // 
            LoginBtn.Cursor = Cursors.Hand;
            LoginBtn.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LoginBtn.Location = new Point(340, 298);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Size = new Size(125, 46);
            LoginBtn.TabIndex = 3;
            LoginBtn.Text = "Login";
            LoginBtn.UseVisualStyleBackColor = true;
            LoginBtn.Click += LoginBtn_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(163, 167);
            label3.Name = "label3";
            label3.Size = new Size(91, 25);
            label3.TabIndex = 5;
            label3.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(163, 224);
            label2.Name = "label2";
            label2.Size = new Size(87, 25);
            label2.TabIndex = 4;
            label2.Text = "Password";
            // 
            // PasswordTbl
            // 
            PasswordTbl.Cursor = Cursors.IBeam;
            PasswordTbl.Location = new Point(260, 218);
            PasswordTbl.Name = "PasswordTbl";
            PasswordTbl.Size = new Size(287, 31);
            PasswordTbl.TabIndex = 2;
            // 
            // UnameTbl
            // 
            UnameTbl.Cursor = Cursors.IBeam;
            UnameTbl.Location = new Point(260, 167);
            UnameTbl.Name = "UnameTbl";
            UnameTbl.Size = new Size(287, 31);
            UnameTbl.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(340, 69);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(293, 26);
            label1.Name = "label1";
            label1.Size = new Size(250, 28);
            label1.TabIndex = 0;
            label1.Text = "Hotel Managment System";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Blue;
            ClientSize = new Size(778, 449);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label3;
        private Label label2;
        private TextBox PasswordTbl;
        private TextBox UnameTbl;
        private Label ContinueLink;
        private Button LoginBtn;
    }
}