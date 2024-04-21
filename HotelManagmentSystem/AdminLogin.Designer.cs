namespace HotelManagmentSystem
{
    partial class AdminLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminLogin));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            ClosedLink = new Label();
            LoginBtn = new Button();
            label2 = new Label();
            PasswordTb = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(ClosedLink);
            panel1.Controls.Add(LoginBtn);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(PasswordTb);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(769, 417);
            panel1.TabIndex = 18;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(335, 86);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 62);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 23;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(275, 45);
            label1.Name = "label1";
            label1.Size = new Size(250, 28);
            label1.TabIndex = 22;
            label1.Text = "Hotel Managment System";
            // 
            // ClosedLink
            // 
            ClosedLink.AutoSize = true;
            ClosedLink.Font = new Font("Segoe UI", 10.8F, FontStyle.Underline, GraphicsUnit.Point, 204);
            ClosedLink.Location = new Point(359, 352);
            ClosedLink.Name = "ClosedLink";
            ClosedLink.Size = new Size(66, 25);
            ClosedLink.TabIndex = 2;
            ClosedLink.Text = "Closed";
            ClosedLink.Click += ClosedLink_Click_1;
            // 
            // LoginBtn
            // 
            LoginBtn.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            LoginBtn.Location = new Point(335, 270);
            LoginBtn.Name = "LoginBtn";
            LoginBtn.Size = new Size(125, 47);
            LoginBtn.TabIndex = 1;
            LoginBtn.Text = "Login";
            LoginBtn.UseVisualStyleBackColor = true;
            LoginBtn.Click += LoginBtn_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(271, 195);
            label2.Name = "label2";
            label2.Size = new Size(87, 25);
            label2.TabIndex = 19;
            label2.Text = "Password";
            // 
            // PasswordTb
            // 
            PasswordTb.Location = new Point(275, 223);
            PasswordTb.Name = "PasswordTb";
            PasswordTb.PasswordChar = '*';
            PasswordTb.Size = new Size(250, 31);
            PasswordTb.TabIndex = 0;
            // 
            // AdminLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Blue;
            ClientSize = new Size(778, 427);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "AdminLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminLogin";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1;
        private Label ClosedLink;
        private Button LoginBtn;
        private Label label2;
        private TextBox PasswordTb;
    }
}