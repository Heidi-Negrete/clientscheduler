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
            cmbCustomers = new ComboBox();
            tbTitle = new TextBox();
            tbDescription = new TextBox();
            tbLocation = new TextBox();
            tbContact = new TextBox();
            tbType = new TextBox();
            tbUrl = new TextBox();
            cmbStartTimes = new ComboBox();
            mcAppointmentDate = new MonthCalendar();
            btnAdd = new Button();
            lblAppointmentTime = new Label();
            lblStart = new Label();
            lblEnd = new Label();
            tbEndTime = new TextBox();
            lblCustomer = new Label();
            lblTitle = new Label();
            lblDescription = new Label();
            lblLocation = new Label();
            lblContact = new Label();
            lblType = new Label();
            lblUrl = new Label();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // cmbCustomers
            // 
            cmbCustomers.FormattingEnabled = true;
            cmbCustomers.Location = new Point(173, 30);
            cmbCustomers.Name = "cmbCustomers";
            cmbCustomers.Size = new Size(121, 23);
            cmbCustomers.Sorted = true;
            cmbCustomers.TabIndex = 0;
            cmbCustomers.SelectionChangeCommitted += cmbCustomers_SelectionCommitted;
            // 
            // tbTitle
            // 
            tbTitle.Location = new Point(173, 68);
            tbTitle.Name = "tbTitle";
            tbTitle.Size = new Size(121, 23);
            tbTitle.TabIndex = 1;
            tbTitle.TextChanged += tbTitle_TextChanged;
            // 
            // tbDescription
            // 
            tbDescription.Location = new Point(173, 109);
            tbDescription.Name = "tbDescription";
            tbDescription.Size = new Size(121, 23);
            tbDescription.TabIndex = 2;
            tbDescription.TextChanged += tbDescription_TextChanged;
            // 
            // tbLocation
            // 
            tbLocation.Location = new Point(173, 154);
            tbLocation.Name = "tbLocation";
            tbLocation.Size = new Size(121, 23);
            tbLocation.TabIndex = 3;
            tbLocation.TextChanged += tbLocation_TextChanged;
            // 
            // tbContact
            // 
            tbContact.Location = new Point(173, 198);
            tbContact.Name = "tbContact";
            tbContact.Size = new Size(121, 23);
            tbContact.TabIndex = 4;
            tbContact.TextChanged += tbContact_TextChanged;
            // 
            // tbType
            // 
            tbType.Location = new Point(173, 241);
            tbType.Name = "tbType";
            tbType.Size = new Size(121, 23);
            tbType.TabIndex = 5;
            tbType.TextChanged += tbType_TextChanged;
            // 
            // tbUrl
            // 
            tbUrl.Location = new Point(173, 285);
            tbUrl.Name = "tbUrl";
            tbUrl.Size = new Size(121, 23);
            tbUrl.TabIndex = 6;
            tbUrl.TextChanged += tbUrl_TextChanged;
            // 
            // cmbStartTimes
            // 
            cmbStartTimes.FormattingEnabled = true;
            cmbStartTimes.Location = new Point(300, 373);
            cmbStartTimes.Name = "cmbStartTimes";
            cmbStartTimes.Size = new Size(121, 23);
            cmbStartTimes.TabIndex = 7;
            // 
            // mcAppointmentDate
            // 
            mcAppointmentDate.Location = new Point(18, 345);
            mcAppointmentDate.MaxSelectionCount = 1;
            mcAppointmentDate.Name = "mcAppointmentDate";
            mcAppointmentDate.TabIndex = 8;
            mcAppointmentDate.DateChanged += mcAppointmentCalendar_DateChanged;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(371, 484);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Clicked;
            // 
            // lblAppointmentTime
            // 
            lblAppointmentTime.AutoSize = true;
            lblAppointmentTime.Location = new Point(303, 345);
            lblAppointmentTime.Name = "lblAppointmentTime";
            lblAppointmentTime.Size = new Size(107, 15);
            lblAppointmentTime.TabIndex = 10;
            lblAppointmentTime.Text = "Appointment Time";
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Location = new Point(256, 376);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(31, 15);
            lblStart.TabIndex = 11;
            lblStart.Text = "Start";
            // 
            // lblEnd
            // 
            lblEnd.AutoSize = true;
            lblEnd.Location = new Point(256, 410);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new Size(27, 15);
            lblEnd.TabIndex = 12;
            lblEnd.Text = "End";
            // 
            // tbEndTime
            // 
            tbEndTime.Location = new Point(303, 407);
            tbEndTime.Name = "tbEndTime";
            tbEndTime.ReadOnly = true;
            tbEndTime.Size = new Size(100, 23);
            tbEndTime.TabIndex = 13;
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Location = new Point(39, 33);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(59, 15);
            lblCustomer.TabIndex = 14;
            lblCustomer.Text = "Customer";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(39, 71);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(29, 15);
            lblTitle.TabIndex = 15;
            lblTitle.Text = "Title";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(39, 112);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(67, 15);
            lblDescription.TabIndex = 16;
            lblDescription.Text = "Description";
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Location = new Point(39, 157);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(53, 15);
            lblLocation.TabIndex = 17;
            lblLocation.Text = "Location";
            // 
            // lblContact
            // 
            lblContact.AutoSize = true;
            lblContact.Location = new Point(39, 201);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(49, 15);
            lblContact.TabIndex = 18;
            lblContact.Text = "Contact";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(39, 244);
            lblType.Name = "lblType";
            lblType.Size = new Size(31, 15);
            lblType.TabIndex = 19;
            lblType.Text = "Type";
            // 
            // lblUrl
            // 
            lblUrl.AutoSize = true;
            lblUrl.Location = new Point(39, 288);
            lblUrl.Name = "lblUrl";
            lblUrl.Size = new Size(22, 15);
            lblUrl.TabIndex = 20;
            lblUrl.Text = "Url";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(290, 484);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 21;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Clicked;
            // 
            // AddAppointment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(472, 525);
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
            Name = "AddAppointment";
            StartPosition = FormStartPosition.CenterScreen;
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
        private ComboBox cmbStartTimes;
        private MonthCalendar mcAppointmentDate;
        private Button btnAdd;
        private Label lblAppointmentTime;
        private Label lblStart;
        private Label lblEnd;
        private TextBox tbEndTime;
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