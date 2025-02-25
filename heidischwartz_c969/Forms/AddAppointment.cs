using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using heidischwartz_c969.Models;

namespace heidischwartz_c969.Forms
{
    public partial class AddAppointment : Form
    {
        private ErrorProvider errorProvider = new ErrorProvider();
        private readonly IClientSchedulerRepository _repository;
        private List<DateTime> _availableTimes = new List<DateTime>();
        private DateTime selectedDate = DateTime.Now;
        private readonly List<Customer> _clients;
        public Appointment selectedAppointment = new Appointment();
        public Customer client = new Customer();
        public DateTime dateSelection = DateTime.Now;
        public bool addingAppointment = false;

        public AddAppointment(IClientSchedulerRepository repository, List<Customer> clients, Appointment? appointment = null)
        {
            InitializeComponent();
            _repository = repository;
            _clients = clients;

            cmbCustomers.DataSource = _clients;
            cmbCustomers.DisplayMember = "CustomerName";
            cmbCustomers.DropDownStyle = ComboBoxStyle.DropDownList;

            if (appointment != null)
            {
                selectedAppointment = appointment;
                PopulateFormFields();
                mcAppointmentDate.SelectionStart = selectedAppointment.Start;
                btnAdd.Text = "Update";
            }
            else
            {
                addingAppointment = true;
                btnAdd.Text = "Add";
            }

            btnAdd.Enabled = false;
            tbEndTime.ReadOnly = true;
            GetAvailableTimes();
        }

        private async Task GetAvailableTimes()
        {
            var availableTimes = await _repository.GetAvailableTimes(selectedDate);
            if (availableTimes.Count == 0)
            {
                ShowError("No available times for the selected date.");
                return;
            }
            _availableTimes = availableTimes;
            cmbStartTimes.DataSource = _availableTimes;
            cmbStartTimes.DropDownStyle = ComboBoxStyle.DropDownList;
            
            
        }

        private void PopulateFormFields()
        {
            tbTitle.Text = selectedAppointment?.Title ?? "";
            tbDescription.Text = selectedAppointment?.Description ?? "";
            tbLocation.Text = selectedAppointment?.Location ?? "";
            tbContact.Text = selectedAppointment?.Contact ?? "";
            tbType.Text = selectedAppointment?.Type ?? "";
            tbUrl.Text = selectedAppointment?.Url ?? "";
            cmbCustomers.SelectedItem = _clients.FirstOrDefault(c => c.CustomerId == selectedAppointment.CustomerId);
            
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cmbCustomers_SelectionCommitted(object sender, EventArgs e)
        {
            if (cmbStartTimes.SelectedItem != null)
            {
                selectedAppointment.Start = (DateTime)cmbStartTimes.SelectedItem;
                selectedAppointment.End = selectedAppointment.Start.AddMinutes(30);
            }
            btnAdd.Enabled = ValidateAppointment();
        }

        private void tbTitle_TextChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = ValidateAppointment();
        }

        private void tbDescription_TextChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = ValidateAppointment();
        }

        private void tbLocation_TextChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = ValidateAppointment();
        }

        private void tbContact_TextChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = ValidateAppointment();
        }

        private void tbType_TextChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = ValidateAppointment();
        }

        private void tbUrl_TextChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = ValidateAppointment();
        }

        private void mcAppointmentCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            selectedDate = e.Start;
            GetAvailableTimes();
            if (cmbStartTimes.SelectedItem != null)
            {
                var startDate = (DateTime)cmbStartTimes.SelectedItem;
                selectedAppointment.End = startDate.AddMinutes(30);
                // need the string format to match the textbox
                tbEndTime.Text = selectedAppointment.End.ToString("MM/dd/yyyy h:mm tt");
            }
        }

        private void cmbStartTimes_SelectionCommitted(object sender, EventArgs e)
        {
            if (cmbStartTimes.SelectedItem != null)
            {
                var startDate = (DateTime)cmbStartTimes.SelectedItem;
                selectedAppointment.End = startDate.AddMinutes(30);
                tbEndTime.Text = selectedAppointment.End.ToString("MM/dd/yyyy h:mm tt");
            }
            btnAdd.Enabled = ValidateAppointment();
        }

        private bool ValidateAppointment()
        {
            bool isValid = true;

            // Validate title
            if (string.IsNullOrWhiteSpace(tbTitle.Text))
            {
                errorProvider.SetError(tbTitle, "Title is required.");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(tbTitle, string.Empty);
            }

            // Validate description
            if (string.IsNullOrWhiteSpace(tbDescription.Text))
            {
                errorProvider.SetError(tbDescription, "Description is required.");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(tbDescription, string.Empty);
            }

            // Validate location
            if (string.IsNullOrWhiteSpace(tbLocation.Text))
            {
                errorProvider.SetError(tbLocation, "Location is required.");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(tbLocation, string.Empty);
            }

            // Validate contact
            if (string.IsNullOrWhiteSpace(tbContact.Text))
            {
                errorProvider.SetError(tbContact, "Contact is required.");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(tbContact, string.Empty);
            }

            // Validate type
            if (string.IsNullOrWhiteSpace(tbType.Text))
            {
                errorProvider.SetError(tbType, "Type is required.");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(tbType, string.Empty);
            }

            // Validate URL
            if (string.IsNullOrWhiteSpace(tbUrl.Text))
            {
                errorProvider.SetError(tbUrl, "URL is required.");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(tbUrl, string.Empty);
            }

            // Validate customer selection
            if (cmbCustomers.SelectedIndex == -1)
            {
                errorProvider.SetError(cmbCustomers, "Please select a customer.");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(cmbCustomers, string.Empty);
            }
            
            if (cmbStartTimes.SelectedIndex == -1)
            {
                errorProvider.SetError(cmbStartTimes, "Please select a start time.");
                isValid = false;
            }
            else
            {
                errorProvider.SetError(cmbStartTimes, string.Empty);
            }

            return isValid;
        }

        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            if (!ValidateAppointment())
            {
                ShowError("Please correct the errors before proceeding.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Please confirm you want to save.", "Add/Edit Appointment", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
            {
                return;
            }

            selectedAppointment.Title = tbTitle.Text;
            selectedAppointment.Description = tbDescription.Text;
            selectedAppointment.Location = tbLocation.Text;
            selectedAppointment.Contact = tbContact.Text;
            selectedAppointment.Type = tbType.Text;
            selectedAppointment.Url = tbUrl.Text;
            selectedAppointment.CustomerId = ((Customer)cmbCustomers.SelectedItem).CustomerId;
            selectedAppointment.Start = (DateTime)cmbStartTimes.SelectedItem;
            
            if (addingAppointment)
            {
                AddApt(selectedAppointment);
            }
            else
            {
                UpdateApt(selectedAppointment);
            }
        }

        private async Task AddApt(Appointment appointment)
        {
            await _repository.AddAppointment(selectedAppointment);
            this.Close();
        }
        
        private async Task UpdateApt(Appointment appointment)
        {
            await _repository.UpdateAppointment(selectedAppointment);
            this.Close();
        }

        private void btnCancel_Clicked(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}