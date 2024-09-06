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

        // TODO get this list on construction from Dashboard Presenter?
        private readonly List<Customer> _clients;
        //private readonly SchedulerService _scheduler;
        // Not implementing IView atm


        // private readonly AddAppointmentPresenter _addAppointmentPresenter;

        public Appointment appointment = new Appointment();
        public Customer client = new Customer();
        public DateTime dateSelection = DateTime.Now;


        public AddAppointment(List<Customer> clients)
        {
            InitializeComponent();
            _clients = clients;

            // set cmbCustomers max dropdown to count of Clients :o?
            // customers should be sorted alphabetically ascending
            // Client NAME property not each client object
            cmbCustomers.DataSource = _clients;
            cmbCustomers.DisplayMember = "CustomerName";
            cmbCustomers.DropDownStyle = ComboBoxStyle.DropDownList;

            btnAdd.Enabled = false;
           // _scheduler = scheduler;


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
            // scheduler get all appointments on selecte date w. this client and
            // establish available appointment times (30 min intervals & within the business hours see requirements.)
            // scheduler return ? and assign it to the cmbStartTimes
            // WHAT IF THERE ARE NO AVAILABLE APPOINTMENT TIMES? (add to start of list like Client so that option 0)
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
                appointment.Title = "";
            }
            else
            {
                // optional? any business logic here
                appointment.Title = tbTitle.Text;
            }

            // Validate description
            if (string.IsNullOrWhiteSpace(tbDescription.Text))
            {
                appointment.Description = "";
            }
            else
            {
                // optional? any business logic here
                appointment.Description = tbDescription.Text;
            }

            // Validate Location
            if (string.IsNullOrWhiteSpace(tbLocation.Text))
            {
                appointment.Location = "";
            }
            else
            {
                // optional? any business logic here
                appointment.Location = tbLocation.Text;
            }

            // Validate Contact
            if (string.IsNullOrWhiteSpace(tbContact.Text))
            {
                appointment.Contact = "";
            }
            else
            {
                // optional? any business logic here
                appointment.Contact = tbContact.Text;
            }

            // Validate Type
            if (string.IsNullOrWhiteSpace(tbType.Text))
            {
                appointment.Type = "";
            }
            else
            {
                // optional? any business logic here
                appointment.Type = tbType.Text;
            }

            // Validate Url
            if (string.IsNullOrWhiteSpace(tbTitle.Text))
            {
                appointment.Title = "";
            }
            else
            {
                // optional? any business logic here
                appointment.Title = tbTitle.Text;
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
