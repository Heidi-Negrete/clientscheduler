using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using heidischwartz_c969.Models;
using heidischwartz_c969.Views;

namespace heidischwartz_c969.Forms
{
    public partial class AddAppointment : Form, IAddAppointment
    {
        private ErrorProvider errorProvider = new ErrorProvider();
        private readonly IClientSchedulerRepository _repository;
        
        private List<DateTime> _availableTimes = new List<DateTime>();
        private DateTime selectedDate = DateTime.Now;

        // TODO get this list on construction from Dashboard Presenter?
        private readonly List<Customer> _clients;
        //private readonly SchedulerService _scheduler;
        // Not implementing IView atm


        // private readonly AddAppointmentPresenter _addAppointmentPresenter;

        public Appointment selectedAppointment = new Appointment();
        public Customer client = new Customer();
        public DateTime dateSelection = DateTime.Now;


        public AddAppointment(IClientSchedulerRepository repository, List<Customer> clients, Appointment? appointment = null)
        {
            InitializeComponent();
            _repository = repository;
            _clients = clients;

            // set cmbCustomers max dropdown to count of Clients :o?
            // customers should be sorted alphabetically ascending
            // Client NAME property not each client object
            cmbCustomers.DataSource = _clients;
            cmbCustomers.DisplayMember = "CustomerName";
            cmbCustomers.DropDownStyle = ComboBoxStyle.DropDownList;

            
            if (appointment != null)
            {
                selectedAppointment = appointment;
                PopulateFormFields();
                btnAdd.Text = "Update";
            }
            else
            {
                btnAdd.Text = "Add";
            }

            btnAdd.Enabled = false;
            
            btnAdd.Enabled = false;
            GetAvailableTimes();

        }
        
        private async Task GetAvailableTimes()
        {
            // TODO get available times from repo
            var availableTimes = await _repository.GetAvailableTimes(selectedDate);
            // if list is empty then show error no available time for the date selected. 
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
            // Set other fields as necessary
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cmbCustomers_SelectionCommitted(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(client.CustomerName) && client.CustomerName != cmbCustomers.SelectedValue)
            {
                // clear start times cmb and get available apts for new client selection
            }
            btnAdd.Enabled = validateAppointment();
        }

        private void tbTitle_TextChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = validateAppointment();
        }

        private void tbDescription_TextChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = validateAppointment();
        }

        private void tbLocation_TextChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = validateAppointment();
        }

        private void tbContact_TextChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = validateAppointment();
        }

        private void tbType_TextChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = validateAppointment();
        }

        private void tbUrl_TextChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = validateAppointment();
        }

        private void mcAppointmentCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            selectedDate = e.Start;
            GetAvailableTimes();
        }

        private void btnAdd_Clicked(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"Please confirm your new appointment.", "Add Appointment", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
            {
                return;
            }

            // _scheduler.AddAppointment(appointment);
            // instead, raise event and pass appointment to dashboard presenter
            // however need to unsubscribe from events before closing form
            this.Close();
        }

        private void btnCancel_Clicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validateAppointment()
        {
            bool isValid = true;

            // Validate title
            if (string.IsNullOrWhiteSpace(tbTitle.Text))
            {
                selectedAppointment.Title = "";
            }
            else
            {
                // optional? any business logic here
                selectedAppointment.Title = tbTitle.Text;
            }

            // Validate description
            if (string.IsNullOrWhiteSpace(tbDescription.Text))
            {
                selectedAppointment.Description = "";
            }
            else
            {
                // optional? any business logic here
                selectedAppointment.Description = tbDescription.Text;
            }

            // Validate Location
            if (string.IsNullOrWhiteSpace(tbLocation.Text))
            {
                selectedAppointment.Location = "";
            }
            else
            {
                // optional? any business logic here
                selectedAppointment.Location = tbLocation.Text;
            }

            // Validate Contact
            if (string.IsNullOrWhiteSpace(tbContact.Text))
            {
                selectedAppointment.Contact = "";
            }
            else
            {
                // optional? any business logic here
                selectedAppointment.Contact = tbContact.Text;
            }

            // Validate Type
            if (string.IsNullOrWhiteSpace(tbType.Text))
            {
                selectedAppointment.Type = "";
            }
            else
            {
                // optional? any business logic here
                selectedAppointment.Type = tbType.Text;
            }

            // Validate Url
            if (string.IsNullOrWhiteSpace(tbTitle.Text))
            {
                selectedAppointment.Title = "";
            }
            else
            {
                // optional? any business logic here
                selectedAppointment.Title = tbTitle.Text;
            }

            // Validate Client ComboBox
            //if (cmbCustomers.SelectedIndex == 0)
            //{
            //    isValid = false;
            //    errorProvider.SetError(cmbCustomers, "Please select a valid client");
            //}
            //else
            //{
            //    errorProvider.SetError(cmbCustomers, String.Empty);
            //}

            // Validate Start Times ComboBox
            if (cmbStartTimes.SelectedIndex == 0)
            {
                isValid = false;
                errorProvider.SetError(cmbStartTimes, "Please select from available times");
            }
            else
            {
                errorProvider.SetError(cmbStartTimes, String.Empty);
            }

            return isValid;
        }

        private void UpdateView()
        {
            // basically set data sources to null and back again
        }
    }
}
