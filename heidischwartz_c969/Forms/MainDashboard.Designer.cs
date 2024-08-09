namespace heidischwartz_c969.Forms
{
    partial class MainDashboard
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
            panelSideMenu = new Panel();
            lblUserStamp = new Label();
            lblLoginStamp = new Label();
            btnLogout = new Button();
            panel4 = new Panel();
            btnGenerateReport = new Button();
            cbReports = new ComboBox();
            label5 = new Label();
            panel3 = new Panel();
            btnManageClients = new Button();
            label2 = new Label();
            panel1 = new Panel();
            dgvWeekView = new DataGridView();
            Sunday = new DataGridViewTextBoxColumn();
            Monday = new DataGridViewTextBoxColumn();
            Tuesday = new DataGridViewTextBoxColumn();
            Wednesday = new DataGridViewTextBoxColumn();
            Thursday = new DataGridViewTextBoxColumn();
            Friday = new DataGridViewTextBoxColumn();
            Saturday = new DataGridViewTextBoxColumn();
            panel5 = new Panel();
            monthCalendar = new MonthCalendar();
            panel2 = new Panel();
            btnDeleteApt = new Button();
            btnAddApt = new Button();
            dgvAppointments = new DataGridView();
            Title = new DataGridViewTextBoxColumn();
            Client = new DataGridViewComboBoxColumn();
            Description = new DataGridViewTextBoxColumn();
            Type = new DataGridViewTextBoxColumn();
            ApptLocation = new DataGridViewTextBoxColumn();
            Contact = new DataGridViewTextBoxColumn();
            AppointmentUrl = new DataGridViewLinkColumn();
            Start = new DataGridViewTextBoxColumn();
            End = new DataGridViewTextBoxColumn();
            lblHeadline = new Label();
            panelSideMenu.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvWeekView).BeginInit();
            panel5.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).BeginInit();
            SuspendLayout();
            // 
            // panelSideMenu
            // 
            panelSideMenu.BackColor = SystemColors.Control;
            panelSideMenu.BorderStyle = BorderStyle.FixedSingle;
            panelSideMenu.Controls.Add(lblUserStamp);
            panelSideMenu.Controls.Add(lblLoginStamp);
            panelSideMenu.Controls.Add(btnLogout);
            panelSideMenu.Controls.Add(panel4);
            panelSideMenu.Controls.Add(panel3);
            panelSideMenu.Dock = DockStyle.Left;
            panelSideMenu.Location = new Point(0, 0);
            panelSideMenu.Name = "panelSideMenu";
            panelSideMenu.Size = new Size(173, 617);
            panelSideMenu.TabIndex = 0;
            // 
            // lblUserStamp
            // 
            lblUserStamp.AutoSize = true;
            lblUserStamp.Dock = DockStyle.Bottom;
            lblUserStamp.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblUserStamp.Location = new Point(0, 527);
            lblUserStamp.Margin = new Padding(0);
            lblUserStamp.Name = "lblUserStamp";
            lblUserStamp.Padding = new Padding(10, 10, 0, 0);
            lblUserStamp.Size = new Size(43, 27);
            lblUserStamp.TabIndex = 3;
            lblUserStamp.Text = "User";
            // 
            // lblLoginStamp
            // 
            lblLoginStamp.AutoSize = true;
            lblLoginStamp.Dock = DockStyle.Bottom;
            lblLoginStamp.Font = new Font("Century Gothic", 9F, FontStyle.Italic, GraphicsUnit.Point);
            lblLoginStamp.Location = new Point(0, 554);
            lblLoginStamp.Margin = new Padding(0);
            lblLoginStamp.Name = "lblLoginStamp";
            lblLoginStamp.Padding = new Padding(10, 0, 10, 10);
            lblLoginStamp.Size = new Size(153, 26);
            lblLoginStamp.TabIndex = 2;
            lblLoginStamp.Text = "Logged in at 8:18:380";
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(41, 128, 185);
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnLogout.Location = new Point(0, 580);
            btnLogout.MaximumSize = new Size(83, 35);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(83, 35);
            btnLogout.TabIndex = 18;
            btnLogout.Text = "LOG OUT";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Clicked;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnGenerateReport);
            panel4.Controls.Add(cbReports);
            panel4.Controls.Add(label5);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 157);
            panel4.Name = "panel4";
            panel4.Size = new Size(171, 168);
            panel4.TabIndex = 1;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.Anchor = AnchorStyles.Top;
            btnGenerateReport.BackColor = SystemColors.Control;
            btnGenerateReport.FlatStyle = FlatStyle.Flat;
            btnGenerateReport.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnGenerateReport.Location = new Point(45, 93);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(83, 35);
            btnGenerateReport.TabIndex = 17;
            btnGenerateReport.Text = "GENERATE";
            btnGenerateReport.UseVisualStyleBackColor = false;
            btnGenerateReport.Click += btnGenerateReport_Clicked;
            // 
            // cbReports
            // 
            cbReports.FormattingEnabled = true;
            cbReports.Location = new Point(3, 55);
            cbReports.Name = "cbReports";
            cbReports.Size = new Size(160, 23);
            cbReports.TabIndex = 16;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.FromArgb(41, 128, 185);
            label5.Location = new Point(19, 3);
            label5.Name = "label5";
            label5.Size = new Size(132, 39);
            label5.TabIndex = 15;
            label5.Text = "Reports";
            // 
            // panel3
            // 
            panel3.Controls.Add(btnManageClients);
            panel3.Controls.Add(label2);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(171, 157);
            panel3.TabIndex = 0;
            // 
            // btnManageClients
            // 
            btnManageClients.Anchor = AnchorStyles.Top;
            btnManageClients.BackColor = SystemColors.Control;
            btnManageClients.FlatStyle = FlatStyle.Flat;
            btnManageClients.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnManageClients.Location = new Point(45, 60);
            btnManageClients.Name = "btnManageClients";
            btnManageClients.Size = new Size(83, 35);
            btnManageClients.TabIndex = 18;
            btnManageClients.Text = "MANAGE";
            btnManageClients.UseVisualStyleBackColor = false;
            btnManageClients.Click += btnManageClients_Clicked;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.Font = new Font("Century Gothic", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(41, 128, 185);
            label2.Location = new Point(31, 9);
            label2.Name = "label2";
            label2.Size = new Size(119, 39);
            label2.TabIndex = 13;
            label2.Text = "Clients";
            // 
            // panel1
            // 
            panel1.Controls.Add(dgvWeekView);
            panel1.Controls.Add(panel5);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(173, 291);
            panel1.Name = "panel1";
            panel1.Size = new Size(751, 326);
            panel1.TabIndex = 1;
            // 
            // dgvWeekView
            // 
            dgvWeekView.AllowUserToAddRows = false;
            dgvWeekView.AllowUserToDeleteRows = false;
            dgvWeekView.AllowUserToResizeRows = false;
            dgvWeekView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvWeekView.BackgroundColor = SystemColors.Control;
            dgvWeekView.BorderStyle = BorderStyle.None;
            dgvWeekView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWeekView.Columns.AddRange(new DataGridViewColumn[] { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday });
            dgvWeekView.Dock = DockStyle.Fill;
            dgvWeekView.Location = new Point(234, 0);
            dgvWeekView.MultiSelect = false;
            dgvWeekView.Name = "dgvWeekView";
            dgvWeekView.RowHeadersVisible = false;
            dgvWeekView.RowHeadersWidth = 40;
            dgvWeekView.RowTemplate.Height = 25;
            dgvWeekView.ScrollBars = ScrollBars.Vertical;
            dgvWeekView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvWeekView.Size = new Size(517, 326);
            dgvWeekView.TabIndex = 14;
            dgvWeekView.DataBindingComplete += dgvWeekView_DataBindingComplete;
            // 
            // Sunday
            // 
            Sunday.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Sunday.HeaderText = "Sunday";
            Sunday.Name = "Sunday";
            // 
            // Monday
            // 
            Monday.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Monday.HeaderText = "Monday";
            Monday.Name = "Monday";
            // 
            // Tuesday
            // 
            Tuesday.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Tuesday.HeaderText = "Tuesday";
            Tuesday.Name = "Tuesday";
            // 
            // Wednesday
            // 
            Wednesday.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Wednesday.HeaderText = "Wednesday";
            Wednesday.Name = "Wednesday";
            // 
            // Thursday
            // 
            Thursday.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Thursday.HeaderText = "Thursday";
            Thursday.Name = "Thursday";
            // 
            // Friday
            // 
            Friday.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Friday.HeaderText = "Friday";
            Friday.Name = "Friday";
            // 
            // Saturday
            // 
            Saturday.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Saturday.HeaderText = "Saturday";
            Saturday.Name = "Saturday";
            // 
            // panel5
            // 
            panel5.Controls.Add(monthCalendar);
            panel5.Dock = DockStyle.Left;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(234, 326);
            panel5.TabIndex = 0;
            // 
            // monthCalendar
            // 
            monthCalendar.Location = new Point(5, 0);
            monthCalendar.MaxSelectionCount = 1;
            monthCalendar.Name = "monthCalendar";
            monthCalendar.TabIndex = 13;
            monthCalendar.DateChanged += monthCalendar_DateChanged;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(41, 128, 185);
            panel2.Controls.Add(btnDeleteApt);
            panel2.Controls.Add(btnAddApt);
            panel2.Controls.Add(dgvAppointments);
            panel2.Controls.Add(lblHeadline);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(173, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(751, 285);
            panel2.TabIndex = 2;
            // 
            // btnDeleteApt
            // 
            btnDeleteApt.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDeleteApt.BackColor = SystemColors.Control;
            btnDeleteApt.FlatStyle = FlatStyle.Flat;
            btnDeleteApt.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnDeleteApt.Location = new Point(656, 242);
            btnDeleteApt.Name = "btnDeleteApt";
            btnDeleteApt.Size = new Size(83, 35);
            btnDeleteApt.TabIndex = 16;
            btnDeleteApt.Text = "DELETE";
            btnDeleteApt.UseVisualStyleBackColor = false;
            btnDeleteApt.Click += btnDeleteApt_Clicked;
            // 
            // btnAddApt
            // 
            btnAddApt.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAddApt.BackColor = SystemColors.Control;
            btnAddApt.FlatStyle = FlatStyle.Flat;
            btnAddApt.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddApt.Location = new Point(567, 242);
            btnAddApt.Name = "btnAddApt";
            btnAddApt.Size = new Size(83, 35);
            btnAddApt.TabIndex = 15;
            btnAddApt.Text = "ADD";
            btnAddApt.UseVisualStyleBackColor = false;
            btnAddApt.Click += btnAddAppt_Clicked;
            // 
            // dgvAppointments
            // 
            dgvAppointments.AllowUserToAddRows = false;
            dgvAppointments.AllowUserToDeleteRows = false;
            dgvAppointments.BackgroundColor = SystemColors.Control;
            dgvAppointments.BorderStyle = BorderStyle.None;
            dgvAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAppointments.Columns.AddRange(new DataGridViewColumn[] { Title, Client, Description, Type, ApptLocation, Contact, AppointmentUrl, Start, End });
            dgvAppointments.Dock = DockStyle.Top;
            dgvAppointments.Location = new Point(0, 36);
            dgvAppointments.Name = "dgvAppointments";
            dgvAppointments.RowHeadersVisible = false;
            dgvAppointments.RowTemplate.Height = 25;
            dgvAppointments.Size = new Size(751, 200);
            dgvAppointments.TabIndex = 4;
            dgvAppointments.CellValueChanged += dgvAppointments_Changed;
            dgvAppointments.DataBindingComplete += dgvAppointments_DataBindingComplete;
            // 
            // Title
            // 
            Title.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Title.HeaderText = "Title";
            Title.Name = "Title";
            // 
            // Client
            // 
            Client.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Client.HeaderText = "Client";
            Client.Name = "Client";
            // 
            // Description
            // 
            Description.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Description.HeaderText = "Description";
            Description.Name = "Description";
            // 
            // Type
            // 
            Type.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Type.HeaderText = "Type";
            Type.Name = "Type";
            // 
            // ApptLocation
            // 
            ApptLocation.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ApptLocation.HeaderText = "Location";
            ApptLocation.Name = "ApptLocation";
            // 
            // Contact
            // 
            Contact.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Contact.HeaderText = "Contact";
            Contact.Name = "Contact";
            // 
            // AppointmentUrl
            // 
            AppointmentUrl.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            AppointmentUrl.HeaderText = "URL";
            AppointmentUrl.Name = "AppointmentUrl";
            AppointmentUrl.Resizable = DataGridViewTriState.True;
            AppointmentUrl.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // Start
            // 
            Start.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Start.HeaderText = "Start";
            Start.Name = "Start";
            // 
            // End
            // 
            End.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            End.HeaderText = "End";
            End.Name = "End";
            // 
            // lblHeadline
            // 
            lblHeadline.AutoSize = true;
            lblHeadline.Dock = DockStyle.Top;
            lblHeadline.Font = new Font("Century Gothic", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblHeadline.ForeColor = Color.White;
            lblHeadline.Location = new Point(0, 0);
            lblHeadline.Name = "lblHeadline";
            lblHeadline.Size = new Size(0, 36);
            lblHeadline.TabIndex = 3;
            // 
            // MainDashboard
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(41, 128, 185);
            ClientSize = new Size(924, 617);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panelSideMenu);
            Name = "MainDashboard";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard";
            panelSideMenu.ResumeLayout(false);
            panelSideMenu.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvWeekView).EndInit();
            panel5.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelSideMenu;
        private Panel panel1;
        private Panel panel2;
        private Label lblHeadline;
        private DataGridView dgvAppointments;
        private MonthCalendar monthCalendar;
        private DataGridView dgvWeekView;
        private Button btnAddApt;
        private Button btnDeleteApt;
        private Label label5;
        private Panel panel4;
        private Panel panel3;
        private Label label2;
        private ComboBox cbReports;
        private Button btnGenerateReport;
        private Button btnManageClients;
        private Label lblLoginStamp;
        private Label lblUserStamp;
        private Button btnLogout;
        private Panel panel5;
        private DataGridViewTextBoxColumn Sunday;
        private DataGridViewTextBoxColumn Monday;
        private DataGridViewTextBoxColumn Tuesday;
        private DataGridViewTextBoxColumn Wednesday;
        private DataGridViewTextBoxColumn Thursday;
        private DataGridViewTextBoxColumn Friday;
        private DataGridViewTextBoxColumn Saturday;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewComboBoxColumn Client;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn ApptLocation;
        private DataGridViewTextBoxColumn Contact;
        private DataGridViewLinkColumn AppointmentUrl;
        private DataGridViewTextBoxColumn Start;
        private DataGridViewTextBoxColumn End;
    }
}