namespace heidischwartz_c969.Forms
{
    partial class AddAppointment
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
            cmbCustomers = new System.Windows.Forms.ComboBox();
            tbTitle = new System.Windows.Forms.TextBox();
            tbDescription = new System.Windows.Forms.TextBox();
            tbLocation = new System.Windows.Forms.TextBox();
            tbContact = new System.Windows.Forms.TextBox();
            tbType = new System.Windows.Forms.TextBox();
            tbUrl = new System.Windows.Forms.TextBox();
            cmbStartTimes = new System.Windows.Forms.ComboBox();
            mcAppointmentDate = new System.Windows.Forms.MonthCalendar();
            btnAdd = new System.Windows.Forms.Button();
            lblAppointmentTime = new System.Windows.Forms.Label();
            lblStart = new System.Windows.Forms.Label();
            lblEnd = new System.Windows.Forms.Label();
            tbEndTime = new System.Windows.Forms.TextBox();
            lblCustomer = new System.Windows.Forms.Label();
            lblTitle = new System.Windows.Forms.Label();
            lblDescription = new System.Windows.Forms.Label();
            lblLocation = new System.Windows.Forms.Label();
            lblContact = new System.Windows.Forms.Label();
            lblType = new System.Windows.Forms.Label();
            lblUrl = new System.Windows.Forms.Label();
            btnCancel = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // cmbCustomers
            // 
            cmbCustomers.FormattingEnabled = true;
            cmbCustomers.Location = new System.Drawing.Point(173, 30);
            cmbCustomers.Name = "cmbCustomers";
            cmbCustomers.Size = new System.Drawing.Size(121, 23);
            cmbCustomers.Sorted = true;
            cmbCustomers.TabIndex = 0;
            cmbCustomers.SelectionChangeCommitted += cmbCustomers_SelectionCommitted;
            // 
            // tbTitle
            // 
            tbTitle.Location = new System.Drawing.Point(173, 68);
            tbTitle.Name = "tbTitle";
            tbTitle.Size = new System.Drawing.Size(121, 23);
            tbTitle.TabIndex = 1;
            tbTitle.TextChanged += tbTitle_TextChanged;
            // 
            // tbDescription
            // 
            tbDescription.Location = new System.Drawing.Point(173, 109);
            tbDescription.Name = "tbDescription";
            tbDescription.Size = new System.Drawing.Size(121, 23);
            tbDescription.TabIndex = 2;
            tbDescription.TextChanged += tbDescription_TextChanged;
            // 
            // tbLocation
            // 
            tbLocation.Location = new System.Drawing.Point(173, 154);
            tbLocation.Name = "tbLocation";
            tbLocation.Size = new System.Drawing.Size(121, 23);
            tbLocation.TabIndex = 3;
            tbLocation.TextChanged += tbLocation_TextChanged;
            // 
            // tbContact
            // 
            tbContact.Location = new System.Drawing.Point(173, 198);
            tbContact.Name = "tbContact";
            tbContact.Size = new System.Drawing.Size(121, 23);
            tbContact.TabIndex = 4;
            tbContact.TextChanged += tbContact_TextChanged;
            // 
            // tbType
            // 
            tbType.Location = new System.Drawing.Point(173, 241);
            tbType.Name = "tbType";
            tbType.Size = new System.Drawing.Size(121, 23);
            tbType.TabIndex = 5;
            tbType.TextChanged += tbType_TextChanged;
            // 
            // tbUrl
            // 
            tbUrl.Location = new System.Drawing.Point(173, 285);
            tbUrl.Name = "tbUrl";
            tbUrl.Size = new System.Drawing.Size(121, 23);
            tbUrl.TabIndex = 6;
            tbUrl.TextChanged += tbUrl_TextChanged;
            // 
            // cmbStartTimes
            // 
            cmbStartTimes.FormattingEnabled = true;
            cmbStartTimes.Location = new System.Drawing.Point(300, 373);
            cmbStartTimes.Name = "cmbStartTimes";
            cmbStartTimes.Size = new System.Drawing.Size(134, 23);
            cmbStartTimes.TabIndex = 7;
            cmbStartTimes.SelectedIndexChanged += cmbStartTimes_SelectionCommitted;
            cmbStartTimes.SelectionChangeCommitted += cmbStartTimes_SelectionCommitted;
            // 
            // mcAppointmentDate
            // 
            mcAppointmentDate.Location = new System.Drawing.Point(18, 345);
            mcAppointmentDate.MaxSelectionCount = 1;
            mcAppointmentDate.Name = "mcAppointmentDate";
            mcAppointmentDate.TabIndex = 8;
            mcAppointmentDate.DateChanged += mcAppointmentCalendar_DateChanged;
            // 
            // btnAdd
            // 
            btnAdd.Location = new System.Drawing.Point(371, 484);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(75, 23);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Clicked;
            // 
            // lblAppointmentTime
            // 
            lblAppointmentTime.AutoSize = true;
            lblAppointmentTime.Location = new System.Drawing.Point(303, 345);
            lblAppointmentTime.Name = "lblAppointmentTime";
            lblAppointmentTime.Size = new System.Drawing.Size(108, 15);
            lblAppointmentTime.TabIndex = 10;
            lblAppointmentTime.Text = "Appointment Time";
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Location = new System.Drawing.Point(256, 376);
            lblStart.Name = "lblStart";
            lblStart.Size = new System.Drawing.Size(31, 15);
            lblStart.TabIndex = 11;
            lblStart.Text = "Start";
            // 
            // lblEnd
            // 
            lblEnd.AutoSize = true;
            lblEnd.Location = new System.Drawing.Point(256, 410);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new System.Drawing.Size(27, 15);
            lblEnd.TabIndex = 12;
            lblEnd.Text = "End";
            // 
            // tbEndTime
            // 
            tbEndTime.Location = new System.Drawing.Point(303, 407);
            tbEndTime.Name = "tbEndTime";
            tbEndTime.ReadOnly = true;
            tbEndTime.Size = new System.Drawing.Size(131, 23);
            tbEndTime.TabIndex = 13;
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Location = new System.Drawing.Point(39, 33);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new System.Drawing.Size(59, 15);
            lblCustomer.TabIndex = 14;
            lblCustomer.Text = "Customer";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new System.Drawing.Point(39, 71);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(30, 15);
            lblTitle.TabIndex = 15;
            lblTitle.Text = "Title";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new System.Drawing.Point(39, 112);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new System.Drawing.Size(67, 15);
            lblDescription.TabIndex = 16;
            lblDescription.Text = "Description";
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new System.Drawing.Point(39, 157);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new System.Drawing.Size(53, 15);
            lblLocation.TabIndex = 17;
            lblLocation.Text = "Location";
            // 
            // lblContact
            // 
            lblContact.AutoSize = true;
            lblContact.Location = new System.Drawing.Point(39, 201);
            lblContact.Name = "lblContact";
            lblContact.Size = new System.Drawing.Size(49, 15);
            lblContact.TabIndex = 18;
            lblContact.Text = "Contact";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new System.Drawing.Point(39, 244);
            lblType.Name = "lblType";
            lblType.Size = new System.Drawing.Size(32, 15);
            lblType.TabIndex = 19;
            lblType.Text = "Type";
            // 
            // lblUrl
            // 
            lblUrl.AutoSize = true;
            lblUrl.Location = new System.Drawing.Point(39, 288);
            lblUrl.Name = "lblUrl";
            lblUrl.Size = new System.Drawing.Size(22, 15);
            lblUrl.TabIndex = 20;
            lblUrl.Text = "Url";
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(290, 484);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 21;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Clicked;
            // 
            // AddAppointment
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(472, 525);
            Controls.Add(btnCancel);
            Controls.Add(lblUrl);
            Controls.Add(lblType);
            Controls.Add(lblContact);
            Controls.Add(lblLocation);
            Controls.Add(lblDescription);
            Controls.Add(lblTitle);
            Controls.Add(lblCustomer);
            Controls.Add(tbEndTime);
            Controls.Add(lblEnd);
            Controls.Add(lblStart);
            Controls.Add(lblAppointmentTime);
            Controls.Add(btnAdd);
            Controls.Add(mcAppointmentDate);
            Controls.Add(cmbStartTimes);
            Controls.Add(tbUrl);
            Controls.Add(tbType);
            Controls.Add(tbContact);
            Controls.Add(tbLocation);
            Controls.Add(tbDescription);
            Controls.Add(tbTitle);
            Controls.Add(cmbCustomers);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "New Appointment";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbCustomers;
        private TextBox tbTitle;
        private TextBox tbDescription;
        private TextBox tbLocation;
        private TextBox tbContact;
        private TextBox tbType;
        private TextBox tbUrl;
        private System.Windows.Forms.ComboBox cmbStartTimes;
        private MonthCalendar mcAppointmentDate;
        private Button btnAdd;
        private Label lblAppointmentTime;
        private Label lblStart;
        private Label lblEnd;
        private System.Windows.Forms.TextBox tbEndTime;
        private Label lblCustomer;
        private Label lblTitle;
        private Label lblDescription;
        private Label lblLocation;
        private Label lblContact;
        private Label lblType;
        private Label lblUrl;
        private Button btnCancel;
    }
}