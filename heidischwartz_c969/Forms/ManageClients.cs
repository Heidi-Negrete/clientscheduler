using heidischwartz_c969.Models;
using heidischwartz_c969.Presenters;
using heidischwartz_c969.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace heidischwartz_c969.Forms
{
    public partial class ManageClients : Form, IManageClientsView
    {
        public SchedulerService Scheduler { get; set; }
        private ManageClientsPresenter _presenter;
        private ErrorProvider _errorProvider = new ErrorProvider();

        public event EventHandler<ClientEventArgs> AddClient;
        public event EventHandler<ClientEventArgs> EditClient;
        public event EventHandler<ClientEventArgs> DeleteClient;
        public List<Customer> Clients { get; set; }

        public bool addingClient { get; set; }

        // client in question
        public Customer Client { get; set; }
        public ManageClients(SchedulerService scheduler)
        {
            InitializeComponent();
            Scheduler = scheduler;
            _presenter = new ManageClientsPresenter(this);
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tbCustomerName.Enabled = false;
            tbAddress1.Enabled = false;
            tbAddress2.Enabled = false;
            tbCity.Enabled = false;
            tbPostalCode.Enabled = false;
            tbCountry.Enabled = false;
            tbPhone.Enabled = false;
            btnSave.Enabled = false;
            addingClient = false;
            dgvClients.ClearSelection();
        }

        public void updateView()
        {
            dgvClients.DataSource = null;
            dgvClients.DataSource = Clients;
        }

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

            Client.CustomerName = tbCustomerName.Text;
            Client.Address.Address1 = tbAddress1.Text;
            Client.Address.Address2 = tbAddress2.Text;
            Client.Address.City.City1 = tbCity.Text;
            Client.Address.City.Country.Country1 = tbCountry.Text;
            Client.Address.PostalCode = tbPostalCode.Text;
            Client.Address.Phone = tbPhone.Text;

            if (addingClient)
            {
                AddClient?.Invoke(this, new ClientEventArgs(Client));
                return;
            }
            
            EditClient?.Invoke(this, new ClientEventArgs(Client));
        }

        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            if (addingClient)
            {
                MessageBox.Show("Please finish adding client before adding another.");
                return;
            }

            dgvClients.ClearSelection();

            Client = new Customer();
            Client.Address = new Address();
            Client.Address.City = new City();
            Client.Address.City.Country = new Country();

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

            // raise event that client is being edited IF checking
            // ?
            // get client details (address, city, etc)



            // probably move all  this out into new method

            // some existing database data may be invalid so this is here to deal with corrupt data for assessment.
            if (Client.Address != null)
            {
                try
                {
                    tbAddress1.Text = Client.Address.Address1;
                    tbAddress2.Text = Client.Address.Address2;
                    tbCountry.Text = Client.Address.Phone;
                    tbPostalCode.Text = Client.Address.PostalCode;
                }
                catch
                { return; }
            }
            else
            {
                Client.Address = new Address();
            }

            if (Client.Address.City != null)
            {
                tbCity.Text = Client.Address.City.ToString();
            }
            else
            {
                Client.Address.City = new City();
            }

            tbCustomerName.Text = Client.CustomerName;


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
            DeleteClient?.Invoke(this, new ClientEventArgs(client));
        }

        private void btnExit_Clicked(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit? Any unsaved changes will be lost.", "Exit", MessageBoxButtons.YesNo);
            this.Close();
        }

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
            else if (tbPostalCode.Text.Length < 5)
            {
                _errorProvider.SetError(tbPostalCode, "Postal code must be at least 5 digits.");
                isValid = false;
            }
            else if (tbPostalCode.Text.Length > 10)
            {
                _errorProvider.SetError(tbPostalCode, "Postal code must be less than 10 digits.");
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
            else if (!tbPhone.Text.All(char.IsDigit))
            {
                _errorProvider.SetError(tbPhone, "Phone number must be numeric.");
                isValid = false;
            }
            else if (tbPhone.Text.Length < 10)
            {
                _errorProvider.SetError(tbPhone, "Phone number must be at least 10 digits.");
                isValid = false;
            }
            else if (tbPhone.Text.Length > 15)
            {
                _errorProvider.SetError(tbPhone, "Phone number must be less than 15 digits.");
                isValid = false;
            }
            else
            {
                _errorProvider.SetError(tbPhone, "");
            }
            return isValid;

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
            btnSave.Enabled = false;
        }

        private void dgvClients_CellClicked(object sender, DataGridViewCellEventArgs e)
        {
           //  
        }
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
