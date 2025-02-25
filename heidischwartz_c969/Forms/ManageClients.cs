using heidischwartz_c969.Models;

namespace heidischwartz_c969.Forms
{
    public partial class ManageClients : Form
    {
        private readonly IClientSchedulerRepository _repository;
        
        private ErrorProvider _errorProvider = new ErrorProvider();
        public List<Customer> Clients { get; set; }
        
        private bool delete = false;

        public bool addingClient { get; set; }

        // client in question
        public Customer Client { get; set; }
        public ManageClients(IClientSchedulerRepository repository)
        {
            InitializeComponent();
            _repository = repository;
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.ReadOnly = true;
            tbCustomerName.Enabled = false;
            tbAddress1.Enabled = false;
            tbAddress2.Enabled = false;
            tbCity.Enabled = false;
            tbPostalCode.Enabled = false;
            tbCountry.Enabled = false;
            tbPhone.Enabled = false;
            btnSave.Enabled = false;
            addingClient = false;
            
            panelLoading.Visible = false;
            lblLoading.Visible = false;
            
            dgvClients.AutoGenerateColumns = false;
            
            dgvClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CustomerName",
                HeaderText = "Name",
                Name = "Name"
            });
            dgvClients.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "Active",
                HeaderText = "Active",
                Name = "Active"
            });
            dgvClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LastUpdate",
                HeaderText = "Last Update",
                Name = "LastUpdate"
            });
            dgvClients.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LastUpdateBy",
                HeaderText = "Last Update By",
                Name = "LastUpdateBy"
            });
            
            UpdateClients();
        }

        public void UpdateView()
        {
            dgvClients.DataSource = null;
            dgvClients.DataSource = Clients;
            dgvClients.ClearSelection();
        }
        
        // UI EVENTS
        
        private void tbCustomerName_Changed(object sender, EventArgs e)
        {
            btnSave.Enabled = validateClient();
        }

        private void tbAddress1_Changed(object sender, EventArgs e)
        {
            btnSave.Enabled = validateClient();
        }

        private void tbAddress2_Changed(object sender, EventArgs e)
        {
            btnSave.Enabled = validateClient();
        }

        private void tbCity_Changed(object sender, EventArgs e)
        {
            btnSave.Enabled = validateClient();
        }

        private void tbPostalCode_Changed(object sender, EventArgs e)
        {
            btnSave.Enabled = validateClient();
        }

        private void tbCountry_Changed(object sender, EventArgs e)
        {
            btnSave.Enabled = validateClient();
        }

        private void tbPhone_Changed(object sender, EventArgs e)
        {
            btnSave.Enabled = validateClient();
        }

        private void btnSave_Clicked(object sender, EventArgs e)
        {
            if (!validateClient())
            {
                return;
            }
            
            try
            {
                Client.CustomerName = tbCustomerName.Text;
                Client.Address.Address1 = tbAddress1.Text;
                Client.Address.Address2 = tbAddress2.Text;
                Client.Address.City.City1 = tbCity.Text;
                Client.Address.City.Country.Country1 = tbCountry.Text;
                Client.Address.PostalCode = tbPostalCode.Text;
                Client.Address.Phone = tbPhone.Text;

                if (addingClient)
                {
                    AddClient(Client);
                }
                else
                {
                    EditClient(Client);
                }

                successfullySubmitClientChanges();
            }
            catch (Exception ex)
            {
                ShowError("An error occurred while saving the client: " + ex.Message);
            }
        }

        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            if (addingClient)
            {
                MessageBox.Show("Please finish adding client before adding another.");
                return;
            }
            
            addingClient = true;

            dgvClients.ClearSelection();

            Client = new Customer
            {
                Address = new Address
                {
                    City = new City
                    {
                        Country = new Country()
                    }
                }
            };

            tbCustomerName.Text = "";
            tbAddress1.Text = "";
            tbAddress2.Text = "";
            tbCity.Text = "";
            tbPostalCode.Text = "";
            tbCountry.Text = "";
            tbPhone.Text = "";
            
            tbCustomerName.Enabled = true;
            tbAddress1.Enabled = true;
            tbAddress2.Enabled = true;
            tbCity.Enabled = true;
            tbPostalCode.Enabled = true;
            tbCountry.Enabled = true;
            tbPhone.Enabled = true;
        }

        private void btnEdit_Clicked(object sender, EventArgs e)
        {
            if (addingClient)
            {
                MessageBox.Show("Please finish adding client before editing.");
                return;
            }

            if (dgvClients.CurrentRow == null || !dgvClients.CurrentRow.Selected)
            {
                MessageBox.Show("Please select a client to edit.");
                return;
            }

            Client = dgvClients.CurrentRow.DataBoundItem as Customer;
            
            if (Client == null)
            {
                MessageBox.Show("Please select a client to edit.");
                return;
            }
            
            ValidateAndSetDefaults(Client);

            tbCustomerName.Enabled = true;
            tbAddress1.Enabled = true;
            tbAddress2.Enabled = true;
            tbCity.Enabled = true;
            tbPostalCode.Enabled = true;
            tbCountry.Enabled = true;
            tbPostalCode.Enabled = true;
            tbPhone.Enabled = true;


        }
        
        private void btnDelete_Clicked(object sender, EventArgs e)
        {
            if (addingClient)
            {
                MessageBox.Show("Please finish adding client before deleting.");
                return;
            }

            if (dgvClients.CurrentRow == null || !dgvClients.CurrentRow.Selected)
            {
                MessageBox.Show("Please select a client to delete.");
                return;
            }
            Customer client = dgvClients.CurrentRow.DataBoundItem as Customer;
            // raise event that attempting to delete client
            // check that client doesn't have any existing appointments
            if (client == null)
            {
                MessageBox.Show("Please select a client to delete.");
                return;
            }
            
            
            panelLoading.Visible = true;
            lblLoading.Visible = true;
            Task.Run(() => DeleteClientAsync(client)).GetAwaiter().GetResult();
            panelLoading.Visible = false;
            lblLoading.Visible = false;

            if (delete == true)
            {
                ValidateAndSetDefaults(client);
                DeleteClient(client);
            }
            
        }
        private void btnExit_Clicked(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit? Any unsaved changes will be lost.", "Exit", MessageBoxButtons.YesNo);
            this.Close();
        }
        
        public void dgvClients_CellClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (addingClient)
            {
                MessageBox.Show("Please finish adding client before selecting another.");
                return;
            }

            if (dgvClients.CurrentRow == null || !dgvClients.CurrentRow.Selected)
            {
                return;
            }

            Client = dgvClients.CurrentRow.DataBoundItem as Customer;
            
            tbCustomerName.Text = Client?.CustomerName ?? "";
            tbAddress1.Text = Client?.Address?.Address1 ?? "";
            tbAddress2.Text = Client?.Address?.Address2 ?? "";
            tbCity.Text = Client?.Address?.City?.City1 ?? "";
            tbPostalCode.Text = Client?.Address?.PostalCode ?? "";
            tbCountry.Text = Client?.Address?.City?.Country?.Country1 ?? "";
            tbPhone.Text = Client?.Address?.Phone ?? "";

        }
        
        // END UI EVENTS
        
        private void ValidateAndSetDefaults(Customer customer)
        {
            if (customer.Address != null)
            {
                if (customer.Address.CreateDate == default)
                {
                    customer.Address.CreateDate = DateTime.UtcNow;
                    customer.Address.CreatedBy = UserContext.Name;
                }
                customer.Address.LastUpdate = DateTime.UtcNow;
                customer.Address.LastUpdateBy = UserContext.Name;

                if (customer.Address.City != null)
                {
                    if (customer.Address.City.CreateDate == default)
                    {
                        customer.Address.City.CreateDate = DateTime.UtcNow;
                        customer.Address.City.CreatedBy = UserContext.Name;
                    }
                    customer.Address.City.LastUpdate = DateTime.UtcNow;
                    customer.Address.City.LastUpdateBy = UserContext.Name;

                    if (customer.Address.City.Country != null)
                    {
                        if (customer.Address.City.Country.CreateDate == default)
                        {
                            customer.Address.City.Country.CreateDate = DateTime.UtcNow;
                            customer.Address.City.Country.CreatedBy = UserContext.Name;
                        }
                        customer.Address.City.Country.LastUpdate = DateTime.UtcNow;
                        customer.Address.City.Country.LastUpdateBy = UserContext.Name;
                    }
                }
            }
        }

        private async Task DeleteClientAsync(Customer client)
        {
            try
            {
                var appointments = await _repository.GetAppointmentsByCustomerId(client.CustomerId);

                if (appointments.Any())
                {
                    DialogResult result = MessageBox.Show(
                        "This client has appointments. Are you sure you want to delete the client and all associated appointments?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.No)
                    {
                        return;
                    }
                    
                    delete = true;
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        public void successfullySubmitClientChanges()
        {
            tbCustomerName.Text = "";
            tbAddress1.Text = "";
            tbAddress2.Text = "";
            tbCity.Text = "";
            tbPostalCode.Text = "";
            tbCountry.Text = "";
            tbPhone.Text = "";
            
            tbCustomerName.Enabled = false;
            tbAddress1.Enabled = false;
            tbAddress2.Enabled = false;
            tbCity.Enabled = false;
            tbPostalCode.Enabled = false;
            tbCountry.Enabled = false;
            tbPhone.Enabled = false;
            btnSave.Enabled = false;
        }
        
        public void ShowError(string message)
        {
            Console.WriteLine(message);
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        public async void UpdateClients()
        {
            Clients = await _repository.GetCustomers();
            UpdateView();
        }
        
        private async void AddClient(Customer client)
        {
            // check that Client does not already exist (a client by this name already exists, are you sure you want to add?)
            try
            {
                await _repository.AddCustomer(client);
                UpdateClients();
                successfullySubmitClientChanges();
                Client = null;
                addingClient = false;
            }
            catch (Exception ex)
            {
                ShowError("Error adding client: " + ex.Message);
            }
        }
        
        private async void EditClient(Customer client)
        {
            try
            {
                await _repository.UpdateCustomer(client);
                UpdateClients();
                successfullySubmitClientChanges();
            }
            catch (Exception ex)
            {
                ShowError("Error editing client: " + ex.Message);
            }
        }
        
        private async void DeleteClient(Customer client)
        {
            try
            {
                await _repository.DeleteCustomer(client);
                UpdateClients();
                successfullySubmitClientChanges();
            }
            catch (Exception ex)
            {
                ShowError("Error deleting client: " + ex.Message);
            }
        }
        
        // VALIDATION
        private bool validateClient()
        {   
            bool isValid = true;

            // Validate Name
            if (string.IsNullOrEmpty(tbCustomerName.Text))
            {
                _errorProvider.SetError(tbCustomerName, "Customer name is required.");
                isValid = false;
            }
            else
            {
                _errorProvider.SetError(tbCustomerName, "");
            }

            // Validate Address
            if (string.IsNullOrEmpty(tbAddress1.Text))
            {
                _errorProvider.SetError(tbAddress1, "Address is required.");
                isValid = false;
            }
            else
            {
                _errorProvider.SetError(tbAddress1, "");
            }

            // Validate City
            if (string.IsNullOrEmpty(tbCity.Text))
            {
                _errorProvider.SetError(tbCity, "City is required.");
                isValid = false;
            }
            else
            {
                _errorProvider.SetError(tbCity, "");
            }

            // Validate Postal Code
            if (string.IsNullOrEmpty(tbPostalCode.Text))
            {
                _errorProvider.SetError(tbPostalCode, "Postal code is required.");
                isValid = false;
            }
            else if (!tbPostalCode.Text.All(char.IsDigit))
            {
                _errorProvider.SetError(tbPostalCode, "Postal code must be numeric.");
                isValid = false;
            }
            else if (tbPostalCode.Text.Length < 5 || tbPostalCode.Text.Length > 10)
            {
                _errorProvider.SetError(tbPostalCode, "Postal code must be between 5 and 10 digits.");
                isValid = false;
            }
            else
            {
                _errorProvider.SetError(tbPostalCode, "");
            }

            // Validate Country
            if (string.IsNullOrEmpty(tbCountry.Text))
            {
                _errorProvider.SetError(tbCountry, "Country is required.");
                isValid = false;
            }
            else
            {
                _errorProvider.SetError(tbCountry, "");
            }

            // Validate Phone
            if (string.IsNullOrEmpty(tbPhone.Text))
            {
                _errorProvider.SetError(tbPhone, "Phone number is required.");
                isValid = false;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(tbPhone.Text, @"^\d{3}-\d{3}-\d{4}$"))
            {
                _errorProvider.SetError(tbPhone, "Phone number must be in the format XXX-XXX-XXXX.");
                isValid = false;
            }
            else
            {
                _errorProvider.SetError(tbPhone, "");
            }

            return isValid;
        }
        
    }
}
