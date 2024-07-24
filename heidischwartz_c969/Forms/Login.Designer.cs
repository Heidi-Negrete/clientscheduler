namespace heidischwartz_c969.Forms
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
            panel1 = new Panel();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            btnForgotPassword = new Button();
            btnLogin = new Button();
            panel4 = new Panel();
            tbPassword = new TextBox();
            pictureBox3 = new PictureBox();
            panel3 = new Panel();
            tbUsername = new TextBox();
            pictureBox2 = new PictureBox();
            label5 = new Label();
            btnExit = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(41, 128, 185);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 530);
            panel1.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(237, 496);
            label4.Name = "label4";
            label4.Size = new Size(34, 16);
            label4.TabIndex = 4;
            label4.Text = "Heidi";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(185, 480);
            label3.Name = "label3";
            label3.Size = new Size(86, 16);
            label3.TabIndex = 3;
            label3.Text = "Developed by";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(93, 229);
            label2.Name = "label2";
            label2.Size = new Size(178, 24);
            label2.TabIndex = 2;
            label2.Text = "Client Scheduler";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(93, 204);
            label1.Name = "label1";
            label1.Size = new Size(178, 24);
            label1.TabIndex = 1;
            label1.Text = "Welcome to the";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.clippy;
            pictureBox1.Location = new Point(95, 40);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(120, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnForgotPassword);
            panel2.Controls.Add(btnLogin);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(btnExit);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(300, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(450, 530);
            panel2.TabIndex = 1;
            // 
            // btnForgotPassword
            // 
            btnForgotPassword.BackColor = SystemColors.Control;
            btnForgotPassword.FlatAppearance.BorderSize = 0;
            btnForgotPassword.FlatStyle = FlatStyle.Flat;
            btnForgotPassword.Font = new Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnForgotPassword.ForeColor = Color.FromArgb(41, 128, 185);
            btnForgotPassword.Location = new Point(169, 316);
            btnForgotPassword.Name = "btnForgotPassword";
            btnForgotPassword.Size = new Size(120, 25);
            btnForgotPassword.TabIndex = 9;
            btnForgotPassword.Text = "Forgot Password?";
            btnForgotPassword.UseVisualStyleBackColor = false;
            btnForgotPassword.Click += btnForgotPassword_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(41, 128, 185);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogin.Location = new Point(15, 310);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(148, 35);
            btnLogin.TabIndex = 8;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(tbPassword);
            panel4.Controls.Add(pictureBox3);
            panel4.Location = new Point(0, 246);
            panel4.Name = "panel4";
            panel4.Size = new Size(450, 45);
            panel4.TabIndex = 7;
            // 
            // tbPassword
            // 
            tbPassword.BorderStyle = BorderStyle.None;
            tbPassword.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbPassword.ForeColor = Color.FromArgb(41, 128, 185);
            tbPassword.Location = new Point(55, 11);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(370, 20);
            tbPassword.TabIndex = 7;
            tbPassword.UseSystemPasswordChar = true;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.padlock_login;
            pictureBox3.Location = new Point(12, 10);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(24, 24);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(tbUsername);
            panel3.Controls.Add(pictureBox2);
            panel3.Location = new Point(0, 185);
            panel3.Name = "panel3";
            panel3.Size = new Size(450, 45);
            panel3.TabIndex = 6;
            // 
            // tbUsername
            // 
            tbUsername.BorderStyle = BorderStyle.None;
            tbUsername.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbUsername.ForeColor = Color.FromArgb(41, 128, 185);
            tbUsername.Location = new Point(55, 11);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(370, 20);
            tbUsername.TabIndex = 6;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.person_login2;
            pictureBox2.Location = new Point(15, 11);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(24, 24);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.FromArgb(41, 128, 185);
            label5.Location = new Point(38, 135);
            label5.Name = "label5";
            label5.Size = new Size(236, 24);
            label5.TabIndex = 5;
            label5.Text = "Login to your account";
            // 
            // btnExit
            // 
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Verdana", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnExit.ForeColor = Color.FromArgb(41, 128, 185);
            btnExit.Location = new Point(410, 0);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(40, 40);
            btnExit.TabIndex = 0;
            btnExit.Text = "X";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(750, 530);
            ControlBox = false;
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label3;
        private Button btnExit;
        private Label label5;
        private Panel panel4;
        private PictureBox pictureBox3;
        private Panel panel3;
        private PictureBox pictureBox2;
        private TextBox tbPassword;
        private TextBox tbUsername;
        private Button btnLogin;
        private Button btnForgotPassword;
    }
}