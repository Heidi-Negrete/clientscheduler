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
            components = new System.ComponentModel.Container();
            panelSideMenu = new System.Windows.Forms.Panel();
            lblUserStamp = new System.Windows.Forms.Label();
            lblLoginStamp = new System.Windows.Forms.Label();
            btnLogout = new System.Windows.Forms.Button();
            panel4 = new System.Windows.Forms.Panel();
            btnGenerateReport = new System.Windows.Forms.Button();
            cbReports = new System.Windows.Forms.ComboBox();
            label5 = new System.Windows.Forms.Label();
            panel3 = new System.Windows.Forms.Panel();
            btnManageClients = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            panel5 = new System.Windows.Forms.Panel();
            monthCalendar = new System.Windows.Forms.MonthCalendar();
            panel2 = new System.Windows.Forms.Panel();
            btnEditApt = new System.Windows.Forms.Button();
            lblAppointmentsClient = new System.Windows.Forms.Label();
            btnDeleteApt = new System.Windows.Forms.Button();
            btnAddApt = new System.Windows.Forms.Button();
            dgvAppointments = new System.Windows.Forms.DataGridView();
            Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ApptLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            Contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            AppointmentUrl = new System.Windows.Forms.DataGridViewLinkColumn();
            Start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            End = new System.Windows.Forms.DataGridViewTextBoxColumn();
            lblHeadline = new System.Windows.Forms.Label();
            appointmentBindingSource = new System.Windows.Forms.BindingSource(components);
            panelSideMenu.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).BeginInit();
            ((System.ComponentModel.ISupportInitialize)appointmentBindingSource).BeginInit();
            SuspendLayout();
            // 
            // panelSideMenu
            // 
            panelSideMenu.BackColor = System.Drawing.SystemColors.Control;
            panelSideMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panelSideMenu.Controls.Add(lblUserStamp);
            panelSideMenu.Controls.Add(lblLoginStamp);
            panelSideMenu.Controls.Add(btnLogout);
            panelSideMenu.Controls.Add(panel4);
            panelSideMenu.Controls.Add(panel3);
            panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            panelSideMenu.Location = new System.Drawing.Point(0, 0);
            panelSideMenu.Name = "panelSideMenu";
            panelSideMenu.Size = new System.Drawing.Size(173, 617);
            panelSideMenu.TabIndex = 0;
            // 
            // lblUserStamp
            // 
            lblUserStamp.AutoSize = true;
            lblUserStamp.Dock = System.Windows.Forms.DockStyle.Bottom;
            lblUserStamp.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblUserStamp.Location = new System.Drawing.Point(0, 527);
            lblUserStamp.Margin = new System.Windows.Forms.Padding(0);
            lblUserStamp.Name = "lblUserStamp";
            lblUserStamp.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            lblUserStamp.Size = new System.Drawing.Size(43, 27);
            lblUserStamp.TabIndex = 3;
            lblUserStamp.Text = "User";
            // 
            // lblLoginStamp
            // 
            lblLoginStamp.AutoSize = true;
            lblLoginStamp.Dock = System.Windows.Forms.DockStyle.Bottom;
            lblLoginStamp.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            lblLoginStamp.Location = new System.Drawing.Point(0, 554);
            lblLoginStamp.Margin = new System.Windows.Forms.Padding(0);
            lblLoginStamp.Name = "lblLoginStamp";
            lblLoginStamp.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            lblLoginStamp.Size = new System.Drawing.Size(153, 26);
            lblLoginStamp.TabIndex = 2;
            lblLoginStamp.Text = "Logged in at 8:18:380";
            // 
            // btnLogout
            // 
            btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)((byte)41)), ((int)((byte)128)), ((int)((byte)185)));
            btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLogout.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnLogout.Location = new System.Drawing.Point(0, 580);
            btnLogout.MaximumSize = new System.Drawing.Size(83, 35);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new System.Drawing.Size(83, 35);
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
            panel4.Dock = System.Windows.Forms.DockStyle.Top;
            panel4.Location = new System.Drawing.Point(0, 221);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(171, 255);
            panel4.TabIndex = 1;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btnGenerateReport.BackColor = System.Drawing.SystemColors.Control;
            btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGenerateReport.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnGenerateReport.Location = new System.Drawing.Point(45, 93);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new System.Drawing.Size(83, 35);
            btnGenerateReport.TabIndex = 17;
            btnGenerateReport.Text = "GENERATE";
            btnGenerateReport.UseVisualStyleBackColor = false;
            btnGenerateReport.Click += btnGenerateReport_Clicked;
            // 
            // cbReports
            // 
            cbReports.FormattingEnabled = true;
            cbReports.Location = new System.Drawing.Point(3, 55);
            cbReports.Name = "cbReports";
            cbReports.Size = new System.Drawing.Size(160, 23);
            cbReports.TabIndex = 16;
            // 
            // label5
            // 
            label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label5.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)41)), ((int)((byte)128)), ((int)((byte)185)));
            label5.Location = new System.Drawing.Point(19, 3);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(132, 39);
            label5.TabIndex = 15;
            label5.Text = "Reports";
            // 
            // panel3
            // 
            panel3.Controls.Add(btnManageClients);
            panel3.Controls.Add(label2);
            panel3.Dock = System.Windows.Forms.DockStyle.Top;
            panel3.Location = new System.Drawing.Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(171, 221);
            panel3.TabIndex = 0;
            // 
            // btnManageClients
            // 
            btnManageClients.Anchor = System.Windows.Forms.AnchorStyles.Top;
            btnManageClients.BackColor = System.Drawing.SystemColors.Control;
            btnManageClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnManageClients.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnManageClients.Location = new System.Drawing.Point(45, 60);
            btnManageClients.Name = "btnManageClients";
            btnManageClients.Size = new System.Drawing.Size(83, 35);
            btnManageClients.TabIndex = 18;
            btnManageClients.Text = "MANAGE";
            btnManageClients.UseVisualStyleBackColor = false;
            btnManageClients.Click += btnManageClients_Clicked;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.SystemColors.Control;
            label2.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)41)), ((int)((byte)128)), ((int)((byte)185)));
            label2.Location = new System.Drawing.Point(31, 9);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(119, 39);
            label2.TabIndex = 13;
            label2.Text = "Clients";
            // 
            // panel1
            // 
            panel1.Controls.Add(panel5);
            panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel1.Location = new System.Drawing.Point(173, 291);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(751, 326);
            panel1.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.Controls.Add(monthCalendar);
            panel5.Dock = System.Windows.Forms.DockStyle.Left;
            panel5.Location = new System.Drawing.Point(0, 0);
            panel5.Name = "panel5";
            panel5.Size = new System.Drawing.Size(234, 326);
            panel5.TabIndex = 0;
            // 
            // monthCalendar
            // 
            monthCalendar.Location = new System.Drawing.Point(7, 146);
            monthCalendar.MaxSelectionCount = 1;
            monthCalendar.Name = "monthCalendar";
            monthCalendar.TabIndex = 13;
            monthCalendar.DateChanged += monthCalendar_DateChanged;
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.Color.FromArgb(((int)((byte)41)), ((int)((byte)128)), ((int)((byte)185)));
            panel2.Controls.Add(btnEditApt);
            panel2.Controls.Add(lblAppointmentsClient);
            panel2.Controls.Add(btnDeleteApt);
            panel2.Controls.Add(btnAddApt);
            panel2.Controls.Add(dgvAppointments);
            panel2.Controls.Add(lblHeadline);
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(173, 0);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(751, 425);
            panel2.TabIndex = 2;
            // 
            // btnEditApt
            // 
            btnEditApt.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            btnEditApt.BackColor = System.Drawing.SystemColors.Control;
            btnEditApt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEditApt.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnEditApt.Location = new System.Drawing.Point(567, 382);
            btnEditApt.Name = "btnEditApt";
            btnEditApt.Size = new System.Drawing.Size(83, 35);
            btnEditApt.TabIndex = 18;
            btnEditApt.Text = "EDIT";
            btnEditApt.UseVisualStyleBackColor = false;
            btnEditApt.Click += btnEditAppointment_Clicked;
            // 
            // lblAppointmentsClient
            // 
            lblAppointmentsClient.Dock = System.Windows.Forms.DockStyle.Left;
            lblAppointmentsClient.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblAppointmentsClient.Location = new System.Drawing.Point(0, 376);
            lblAppointmentsClient.Name = "lblAppointmentsClient";
            lblAppointmentsClient.Size = new System.Drawing.Size(468, 49);
            lblAppointmentsClient.TabIndex = 17;
            lblAppointmentsClient.Text = "Client for selected appointment: JARY HOLMES";
            // 
            // btnDeleteApt
            // 
            btnDeleteApt.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            btnDeleteApt.BackColor = System.Drawing.SystemColors.Control;
            btnDeleteApt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDeleteApt.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnDeleteApt.Location = new System.Drawing.Point(656, 382);
            btnDeleteApt.Name = "btnDeleteApt";
            btnDeleteApt.Size = new System.Drawing.Size(83, 35);
            btnDeleteApt.TabIndex = 16;
            btnDeleteApt.Text = "DELETE";
            btnDeleteApt.UseVisualStyleBackColor = false;
            btnDeleteApt.Click += btnDeleteApt_Clicked;
            // 
            // btnAddApt
            // 
            btnAddApt.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            btnAddApt.BackColor = System.Drawing.SystemColors.Control;
            btnAddApt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddApt.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnAddApt.Location = new System.Drawing.Point(474, 382);
            btnAddApt.Name = "btnAddApt";
            btnAddApt.Size = new System.Drawing.Size(83, 35);
            btnAddApt.TabIndex = 15;
            btnAddApt.Text = "ADD";
            btnAddApt.UseVisualStyleBackColor = false;
            btnAddApt.Click += btnAddAppt_Clicked;
            // 
            // dgvAppointments
            // 
            dgvAppointments.AllowUserToAddRows = false;
            dgvAppointments.AllowUserToDeleteRows = false;
            dgvAppointments.BackgroundColor = System.Drawing.SystemColors.Control;
            dgvAppointments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAppointments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Title, Description, Type, ApptLocation, Contact, AppointmentUrl, Start, End });
            dgvAppointments.Dock = System.Windows.Forms.DockStyle.Top;
            dgvAppointments.Location = new System.Drawing.Point(0, 36);
            dgvAppointments.Name = "dgvAppointments";
            dgvAppointments.RowHeadersVisible = false;
            dgvAppointments.RowTemplate.Height = 25;
            dgvAppointments.Size = new System.Drawing.Size(751, 340);
            dgvAppointments.TabIndex = 4;
            dgvAppointments.CellClick += dgvAppointments_Changed;
            dgvAppointments.CellValueChanged += dgvAppointments_Changed;
            dgvAppointments.DataBindingComplete += dgvAppointments_DataBindingComplete;
            // 
            // Title
            // 
            Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            Title.DataPropertyName = "Title";
            Title.HeaderText = "Title";
            Title.Name = "Title";
            Title.Width = 94;
            // 
            // Description
            // 
            Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            Description.DataPropertyName = "Description";
            Description.HeaderText = "Description";
            Description.Name = "Description";
            Description.Width = 94;
            // 
            // Type
            // 
            Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            Type.DataPropertyName = "Type";
            Type.HeaderText = "Type";
            Type.Name = "Type";
            Type.Width = 93;
            // 
            // ApptLocation
            // 
            ApptLocation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            ApptLocation.DataPropertyName = "Location";
            ApptLocation.HeaderText = "Location";
            ApptLocation.Name = "ApptLocation";
            ApptLocation.Width = 95;
            // 
            // Contact
            // 
            Contact.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            Contact.DataPropertyName = "Contact";
            Contact.HeaderText = "Contact";
            Contact.Name = "Contact";
            Contact.Width = 94;
            // 
            // AppointmentUrl
            // 
            AppointmentUrl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            AppointmentUrl.DataPropertyName = "Url";
            AppointmentUrl.HeaderText = "URL";
            AppointmentUrl.Name = "AppointmentUrl";
            AppointmentUrl.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            AppointmentUrl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            AppointmentUrl.Width = 95;
            // 
            // Start
            // 
            Start.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            Start.DataPropertyName = "Start";
            Start.HeaderText = "Start";
            Start.Name = "Start";
            Start.Width = 91;
            // 
            // End
            // 
            End.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            End.DataPropertyName = "End";
            End.HeaderText = "End";
            End.Name = "End";
            End.Width = 94;
            // 
            // lblHeadline
            // 
            lblHeadline.AutoSize = true;
            lblHeadline.Dock = System.Windows.Forms.DockStyle.Top;
            lblHeadline.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblHeadline.ForeColor = System.Drawing.Color.White;
            lblHeadline.Location = new System.Drawing.Point(0, 0);
            lblHeadline.Name = "lblHeadline";
            lblHeadline.Size = new System.Drawing.Size(0, 36);
            lblHeadline.TabIndex = 3;
            // 
            // appointmentBindingSource
            // 
            appointmentBindingSource.DataSource = typeof(heidischwartz_c969.Models.Appointment);
            // 
            // MainDashboard
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.FromArgb(((int)((byte)41)), ((int)((byte)128)), ((int)((byte)185)));
            ClientSize = new System.Drawing.Size(924, 617);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panelSideMenu);
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Dashboard";
            panelSideMenu.ResumeLayout(false);
            panelSideMenu.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAppointments).EndInit();
            ((System.ComponentModel.ISupportInitialize)appointmentBindingSource).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnEditApt;

        private System.Windows.Forms.Label lblAppointmentsClient;

        #endregion

        private Panel panelSideMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblHeadline;
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Button btnAddApt;
        private System.Windows.Forms.Button btnDeleteApt;
        private Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private Label label2;
        private ComboBox cbReports;
        private Button btnGenerateReport;
        private Button btnManageClients;
        private System.Windows.Forms.Label lblLoginStamp;
        private System.Windows.Forms.Label lblUserStamp;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panel5;
        private BindingSource appointmentBindingSource;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn ApptLocation;
        private DataGridViewTextBoxColumn Contact;
        private DataGridViewLinkColumn AppointmentUrl;
        private DataGridViewTextBoxColumn Start;
        private DataGridViewTextBoxColumn End;
    }
}