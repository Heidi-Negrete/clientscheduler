﻿using heidischwartz_c969.Models;
using Serilog;

namespace heidischwartz_c969.Forms
{
    public partial class MainDashboard : Form
    {
        private readonly IClientSchedulerRepository _repository;
        private readonly ILogger _logger;

        // Today's Appointments
        private List<Appointment> Appointments { get; set; } = new List<Appointment>();
        
        // Date Selected
        private DateTime dateSelected = DateTime.Now;
        
        // Report Options
        private List<string> Reports { get; set; } = new List<string>();
        
        // Client List
        private List<Customer> Clients { get; set; } = new List<Customer>();
        
        // ui elements
        public string Username { get => this.lblUserStamp.Text; set => lblUserStamp.Text = value; }
        public string LoginTime { get => this.lblLoginStamp.Text; set => lblLoginStamp.Text = value; }
        private bool notificationsChecked = false;



        public MainDashboard(IClientSchedulerRepository repository, ILogger logger)
        {
            InitializeComponent();
            _logger = logger;
            _repository = repository;
            
            lblLoginStamp.Text = "Logged in at \n" + DateTime.Now.ToString();
            lblUserStamp.Text = UserContext.Name;
            lblAppointmentsClient.Visible = false;
            
            cbReports.DropDownStyle = ComboBoxStyle.DropDownList;
            // report options hardcoded for now
            List<string> availableReports = new List<string> { "Appointment Types", "Full Schedule", "Customer Activity" };
            Reports.AddRange(availableReports);
            
            // Call the asynchronous method synchronously
            Task.Run(() => InitializeAsync()).GetAwaiter().GetResult();
            
            BindData();
            
        }
        
        private async Task InitializeAsync()
        {
            Appointments = await _repository.GetDaysAppointments(dateSelected);
            Clients = await _repository.GetCustomers();
            
        }

        public void BindData()
        {
    
            dgvAppointments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAppointments.ReadOnly = true;
            
           dgvAppointments.AutoGenerateColumns = false;

            cbReports.DataSource = Reports;
            UpdateBindingSources();
        }
        
        public async Task UpdateBindingSources()
        {
            await InitializeAsync();
            
            dgvAppointments.DataSource = null;
            dgvAppointments.DataSource = Appointments;
            lblHeadline.Text = $"{UserContext.Name}, you have {Appointments.Count} appointment{(Appointments.Count == 1 ? String.Empty : 's')} {(dateSelected.Date == DateTime.Now.Date ? "today" : $"on {dateSelected:MMMM dd, yyyy}")}";
            
            if (!notificationsChecked)
            {
                CheckNotifications();
                notificationsChecked = true;
            }
        }
        
        private async void CheckNotifications()
        {
            try
            {
                // Get the current time
                DateTime now = DateTime.Now.ToLocalTime();
                
                // Check for appointments starting within the next 15 minutes
                foreach (var appointment in Appointments)
                {
                    if (appointment.Start > now && appointment.Start <= now.AddMinutes(15))
                    {
  
                            MessageBox.Show($"You have an appointment with {appointment.Customer.CustomerName} starting at {appointment.Start.ToShortTimeString()}.", "Appointment Reminder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error checking notifications.");
                ShowError("Error checking notifications.");
            }
        }
        
        // UI Events
        
        // Launch Add Appointment Form
        private void btnAddAppt_Clicked(object sender, EventArgs e)
        {
            var AddAptForm = new AddAppointment(_repository, Clients, null);
            AddAptForm.Show();

            // prevent user from interacting with dashboard while adding appointment
            AddAptForm.FormClosed += (s, args) => 
            {
                this.Enabled = true;
                ManageAppointments();
            };
        }
        
        private void btnDeleteApt_Clicked(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentCell == null || !dgvAppointments.CurrentCell.Selected)
            {
                MessageBox.Show("Please select an appointment to delete.");
                return;
            }
            DialogResult result = MessageBox.Show("Are you sure you want to delete this appointment?", "Delete Appointment", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DeleteAppointment((Appointment)dgvAppointments.CurrentRow.DataBoundItem);
            }     
        }
        
        private void btnEditAppointment_Clicked(object sender, EventArgs e)
        {
            if (dgvAppointments.CurrentCell == null || !dgvAppointments.CurrentCell.Selected)
            {
                MessageBox.Show("Please select an appointment to change.");
                return;
            }
            
            var selectedAppointment = (Appointment)dgvAppointments.CurrentRow.DataBoundItem;
            //var relevantClient = Clients.FirstOrDefault(c => c.CustomerId == selectedAppointment.CustomerId);
            var ChangeAptForm = new AddAppointment(_repository, Clients, selectedAppointment);
            ChangeAptForm.Show();

            // prevent user from interacting with dashboard while changing appointment
            ChangeAptForm.FormClosed += (s, args) =>
            {
                this.Enabled = true;
                UpdateBindingSources();
            };
        }
        
        private void dgvAppointments_Changed(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAppointments.CurrentCell == null || !dgvAppointments.CurrentCell.Selected)
            {
                return;
            }
            var selectedAppointment = (Appointment)dgvAppointments.CurrentRow.DataBoundItem;
            var relevantClient = Clients.FirstOrDefault(c => c.CustomerId == selectedAppointment.CustomerId);
            lblAppointmentsClient.Text = $"Client: {relevantClient.CustomerName}";
            lblAppointmentsClient.Visible = true;
        }

        private void btnManageClients_Clicked(object sender, EventArgs e)
        {
            var manageClientsForm = new ManageClients(_repository);
            manageClientsForm.Show();

            // prevent user from interacting with dashboard while managing clients
            this.Enabled = false;
            manageClientsForm.FormClosed += (s, args) =>
            {
                this.Enabled = true;
                ManageClients();
            };
        }

        private void btnGenerateReport_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (cbReports.SelectedItem is null )
                {
                    MessageBox.Show("Please select a report format.");
                    return;
                }
                var reportForm = new Report(_repository, cbReports.SelectedItem.ToString());
                reportForm.Show();

                // prevent user from interacting with dashboard while viewing report
                this.Enabled = false;
                reportForm.FormClosed += (s, args) =>
                {
                    this.Enabled = true;
                };
            }
            catch (Exception ex)
            {
                _logger.Error("Error generating report: {Message}", ex.Message);
                ShowError("An error occurred while generating the report.");
            }
        }

        private void btnLogout_Clicked(object sender, EventArgs e)
        {
            Logout();
        }
        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            lblAppointmentsClient.Visible = false;
            dateSelected = monthCalendar.SelectionRange.Start;
            UpdateBindingSources();
        }

        private void dgvAppointments_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvAppointments.ClearSelection();
        }
        
        // END UI EVENTS
        
        public void Logout()
        {
            UserContext.Name = null;
            this.Hide();
            var Login = new Login(_repository, _logger);
            Login.FormClosed += (s, args) => this.Close();
            Login.Show();
        }

        public void ShowError(string message)
        {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        private async void ChangeAppointment(Appointment appointment)
        {
            try
            {
                await _repository.UpdateAppointment(appointment);
                UpdateBindingSources();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error updating appointment");
                ShowError("Error updating appointment");
            }
        }
        
        private async void DeleteAppointment(Appointment appointment)
        {
            try
            {
                await _repository.DeleteAppointment(appointment);
                await UpdateBindingSources();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error deleting appointment.");
                ShowError("Error deleting appointment.");
            }
        }
        
        private async void ManageClients()
        {
            try
            {
                await UpdateBindingSources();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error updating client");
                ShowError("Error updating client");
            }
        }

        private async void ManageAppointments()
        {
            try
            {
                Appointments = await _repository.GetDaysAppointments(dateSelected);
                await UpdateBindingSources();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error updating appointment");
                ShowError("Error updating appointment");
            }
        }
    }
}
