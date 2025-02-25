namespace heidischwartz_c969.Forms
{
    partial class ManageClients
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
            lblAddress = new System.Windows.Forms.Label();
            lblCustomerName = new System.Windows.Forms.Label();
            dgvClients = new System.Windows.Forms.DataGridView();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            lblCountry = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            btnDelete = new System.Windows.Forms.Button();
            btnEdit = new System.Windows.Forms.Button();
            btnExit = new System.Windows.Forms.Button();
            btnSave = new System.Windows.Forms.Button();
            btnAdd = new System.Windows.Forms.Button();
            label6 = new System.Windows.Forms.Label();
            tbAddress1 = new System.Windows.Forms.TextBox();
            tbAddress2 = new System.Windows.Forms.TextBox();
            tbCity = new System.Windows.Forms.TextBox();
            tbPostalCode = new System.Windows.Forms.TextBox();
            tbCustomerName = new System.Windows.Forms.TextBox();
            tbCountry = new System.Windows.Forms.TextBox();
            tbPhone = new System.Windows.Forms.TextBox();
            panelLoading = new System.Windows.Forms.Panel();
            lblLoading = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            panelLoading.SuspendLayout();
            SuspendLayout();
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new System.Drawing.Point(21, 129);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new System.Drawing.Size(83, 15);
            lblAddress.TabIndex = 29;
            lblAddress.Text = "Address Line 1";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Location = new System.Drawing.Point(21, 91);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new System.Drawing.Size(39, 15);
            lblCustomerName.TabIndex = 28;
            lblCustomerName.Text = "Name";
            // 
            // dgvClients
            // 
            dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.Location = new System.Drawing.Point(305, 48);
            dgvClients.Name = "dgvClients";
            dgvClients.RowTemplate.Height = 25;
            dgvClients.Size = new System.Drawing.Size(483, 293);
            dgvClients.TabIndex = 35;
            dgvClients.CellClick += dgvClients_CellClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(21, 166);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(83, 15);
            label1.TabIndex = 37;
            label1.Text = "Address Line 2";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(21, 242);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(70, 15);
            label2.TabIndex = 41;
            label2.Text = "Postal Code";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(21, 205);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(28, 15);
            label3.TabIndex = 39;
            label3.Text = "City";
            // 
            // lblCountry
            // 
            lblCountry.AutoSize = true;
            lblCountry.Location = new System.Drawing.Point(21, 278);
            lblCountry.Name = "lblCountry";
            lblCountry.Size = new System.Drawing.Size(50, 15);
            lblCountry.TabIndex = 44;
            lblCountry.Text = "Country";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(101, 48);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(76, 15);
            label5.TabIndex = 45;
            label5.Text = "Client Details";
            // 
            // btnDelete
            // 
            btnDelete.Location = new System.Drawing.Point(713, 347);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(75, 23);
            btnDelete.TabIndex = 46;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Clicked;
            // 
            // btnEdit
            // 
            btnEdit.Location = new System.Drawing.Point(632, 347);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(75, 23);
            btnEdit.TabIndex = 47;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Clicked;
            // 
            // btnExit
            // 
            btnExit.Location = new System.Drawing.Point(657, 389);
            btnExit.Name = "btnExit";
            btnExit.Size = new System.Drawing.Size(131, 49);
            btnExit.TabIndex = 48;
            btnExit.Text = "Return to Dashboard";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Clicked;
            // 
            // btnSave
            // 
            btnSave.Enabled = false;
            btnSave.Location = new System.Drawing.Point(102, 347);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(75, 23);
            btnSave.TabIndex = 49;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Clicked;
            // 
            // btnAdd
            // 
            btnAdd.Location = new System.Drawing.Point(551, 347);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(75, 23);
            btnAdd.TabIndex = 50;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Clicked;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(21, 309);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(41, 15);
            label6.TabIndex = 52;
            label6.Text = "Phone";
            // 
            // tbAddress1
            // 
            tbAddress1.Location = new System.Drawing.Point(155, 126);
            tbAddress1.Name = "tbAddress1";
            tbAddress1.Size = new System.Drawing.Size(121, 23);
            tbAddress1.TabIndex = 22;
            tbAddress1.TextChanged += tbAddress1_Changed;
            // 
            // tbAddress2
            // 
            tbAddress2.Location = new System.Drawing.Point(155, 163);
            tbAddress2.Name = "tbAddress2";
            tbAddress2.Size = new System.Drawing.Size(121, 23);
            tbAddress2.TabIndex = 36;
            tbAddress2.TextChanged += tbAddress2_Changed;
            // 
            // tbCity
            // 
            tbCity.Location = new System.Drawing.Point(155, 202);
            tbCity.Name = "tbCity";
            tbCity.Size = new System.Drawing.Size(121, 23);
            tbCity.TabIndex = 38;
            tbCity.TextChanged += tbCity_Changed;
            // 
            // tbPostalCode
            // 
            tbPostalCode.Location = new System.Drawing.Point(155, 239);
            tbPostalCode.Name = "tbPostalCode";
            tbPostalCode.Size = new System.Drawing.Size(121, 23);
            tbPostalCode.TabIndex = 40;
            tbPostalCode.TextChanged += tbPostalCode_Changed;
            // 
            // tbCustomerName
            // 
            tbCustomerName.Location = new System.Drawing.Point(155, 88);
            tbCustomerName.Name = "tbCustomerName";
            tbCustomerName.Size = new System.Drawing.Size(121, 23);
            tbCustomerName.TabIndex = 42;
            tbCustomerName.TextChanged += tbCustomerName_Changed;
            // 
            // tbCountry
            // 
            tbCountry.Location = new System.Drawing.Point(155, 275);
            tbCountry.Name = "tbCountry";
            tbCountry.Size = new System.Drawing.Size(121, 23);
            tbCountry.TabIndex = 43;
            tbCountry.TextChanged += tbCountry_Changed;
            // 
            // tbPhone
            // 
            tbPhone.Location = new System.Drawing.Point(155, 306);
            tbPhone.Name = "tbPhone";
            tbPhone.Size = new System.Drawing.Size(121, 23);
            tbPhone.TabIndex = 51;
            tbPhone.TextChanged += tbPhone_Changed;
            // 
            // panelLoading
            // 
            panelLoading.Controls.Add(lblLoading);
            panelLoading.Location = new System.Drawing.Point(195, 103);
            panelLoading.Name = "panelLoading";
            panelLoading.Size = new System.Drawing.Size(401, 166);
            panelLoading.TabIndex = 53;
            // 
            // lblLoading
            // 
            lblLoading.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lblLoading.Location = new System.Drawing.Point(41, 32);
            lblLoading.Name = "lblLoading";
            lblLoading.Size = new System.Drawing.Size(315, 104);
            lblLoading.TabIndex = 0;
            lblLoading.Text = "Loading...";
            lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ManageClients
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(panelLoading);
            Controls.Add(label6);
            Controls.Add(tbPhone);
            Controls.Add(btnAdd);
            Controls.Add(btnSave);
            Controls.Add(btnExit);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(label5);
            Controls.Add(lblCountry);
            Controls.Add(tbCountry);
            Controls.Add(tbCustomerName);
            Controls.Add(label2);
            Controls.Add(tbPostalCode);
            Controls.Add(label3);
            Controls.Add(tbCity);
            Controls.Add(label1);
            Controls.Add(tbAddress2);
            Controls.Add(dgvClients);
            Controls.Add(lblAddress);
            Controls.Add(lblCustomerName);
            Controls.Add(tbAddress1);
            Text = "Manage Clients";
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            panelLoading.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Panel panelLoading;
        private System.Windows.Forms.Label lblLoading;

        #endregion

        private Label lblUrl;
        private Label lblType;
        private Label lblContact;
        private Label lblLocation;
        private Label lblDescription;
        private Label lblAddress;
        private Label lblCustomerName;
        private TextBox tbUrl;
        private TextBox tbType;
        private TextBox tbContact;
        private TextBox tbLocation;
        private TextBox tbDescription;
        private System.Windows.Forms.TextBox tbAddress1;
        private System.Windows.Forms.DataGridView dgvClients;
        private Label label1;
        private System.Windows.Forms.TextBox tbAddress2;
        private Label label2;
        private System.Windows.Forms.TextBox tbPostalCode;
        private Label label3;
        private System.Windows.Forms.TextBox tbCity;
        private System.Windows.Forms.TextBox tbCustomerName;
        private Label lblCountry;
        private System.Windows.Forms.TextBox tbCountry;
        private Label label5;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnExit;
        private Button btnSave;
        private Button btnAdd;
        private Label label6;
        private System.Windows.Forms.TextBox tbPhone;
    }
}