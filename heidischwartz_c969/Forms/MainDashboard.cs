using heidischwartz_c969.Views;
using heidischwartz_c969.Models;
using Serilog;

namespace heidischwartz_c969.Forms
{
    public partial class MainDashboard : Form
    {
        private readonly IClientSchedulerRepository _repository;
        private readonly ILogger _logger;

        // Today's Appointments
        private List<Appointment> Appointments { get; set; } = new List<Appointment>();

        private IAddAppointment? AddAppointmentForm = null;

        // This Week's Appointments
        private List<WeekSummaryView> WeekSummary { get; set; } = new List<WeekSummaryView>();

        private Week week = new Week();
        
        // Report Options
        private List<string> Reports { get; set; } = new List<string>();
        
        // Client List
        private List<Customer> Clients { get; set; } = new List<Customer>();
        
        // ui elements
        public string Username { get => this.lblUserStamp.Text; set => lblUserStamp.Text = value; }
        public string LoginTime { get => this.lblLoginStamp.Text; set => lblLoginStamp.Text = value; }



        public MainDashboard(IClientSchedulerRepository repository, ILogger logger)
        {
            InitializeComponent();
            _logger = logger;
            _repository = repository;
            
            lblLoginStamp.Text = "Logged in at \n" + DateTime.Now.ToString();
            lblUserStamp.Text = UserContext.Name;
            
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
            week = await _repository.GetSchedule(DateTime.Now);
            Appointments = week.Today;
            WeekSummary = week.WeekSummary;
            Clients = await _repository.GetCustomers();
            
            // TODO
            // also start sleeps thread to check if any appointment time within 15 minutes OPTIONAL
            // At least get any appointments within 15 minutes of login
        }

        public void BindData()
        {
            dgvAppointments.AutoGenerateColumns = false;
            dgvWeekView.AutoGenerateColumns = false;
            dgvWeekView.ShowCellToolTips = false;
            dgvWeekView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvWeekView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            cbReports.DataSource = Reports;

            UpdateBindingSources();
        }
        
        public void UpdateBindingSources()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateBindingSources));
                return;
            }

            dgvAppointments.DataSource = null;
            dgvAppointments.DataSource = Appointments;
            dgvWeekView.DataSource = null;
            dgvWeekView.DataSource = WeekSummary;
            lblHeadline.Text = $"{UserContext.Name}, you have {Appointments.Count} appointment{(Appointments.Count == 1 ? String.Empty : 's')} today";
        }
        
        // UI Events
        
        // Launch Add Appointment Form
        private void btnAddAppt_Clicked(object sender, EventArgs e)
        {
            var AddAptForm = new AddAppointment(Clients);
            AddAppointmentForm = (IAddAppointment)AddAptForm;
            AddAptForm.Show();

            // prevent user from interacting with dashboard while adding appointment
            AddAptForm.FormClosed += (s, args) => 
            {
                this.Enabled = true;
                AddAppointmentForm = null;
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
        private void dgvAppointments_Changed(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAppointments.CurrentRow?.DataBoundItem is Appointment appointment)
            {
                ChangeAppointment(appointment);
            }
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
                if (cbReports.SelectedIndex == 0 )
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

        private void dgvWeekView_DayClicked(object sender, DataGridViewCellMouseEventArgs e)
        {
            ChangeWeekDay(e.ColumnIndex);
        }
        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime dateSelected = monthCalendar.SelectionRange.Start;
            ChangeCurrentDate(dateSelected);
        }

        private void dgvAppointments_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvAppointments.ClearSelection();
        }

        private void dgvWeekView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvWeekView.ClearSelection();
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
            if (AddAppointmentForm != null)
            {
                AddAppointmentForm.ShowError(message);
            }
            else
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void ChangeWeekDay(int weekDayIndex)
        {
            switch (weekDayIndex)
            {
                case 0:
                    week.Today = week.Sunday;
                    break;
                case 1:
                    week.Today = week.Monday;
                    break;
                case 2:
                    week.Today = week.Tuesday;
                    break;
                case 3:
                    week.Today = week.Wednesday;
                    break;
                case 4:
                    week.Today = week.Thursday;
                    break;
                case 5:
                    week.Today = week.Friday;
                    break;
                case 6:
                    week.Today = week.Saturday;
                    break;
                default: break;
            }
            Appointments = week.Today;
            UpdateBindingSources();

        }
        
        private async void ChangeAppointment(Appointment appointment)
        {
            try
            {
                await _repository.UpdateAppointment(appointment);
                week = await _repository.GetSchedule(week.TargetDate);
                Appointments = week.Today;
                WeekSummary = week.WeekSummary;
                UpdateBindingSources();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error updating appointment");
                ShowError("Error updating appointment");
            }
        }
        
        private async void AddAppointment(Appointment appointment)
        {
            try
            {
                await _repository.AddAppointment(appointment);
                week = await _repository.GetSchedule(week.TargetDate);
                Appointments = week.Today;
                WeekSummary = week.WeekSummary;
                UpdateBindingSources();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error adding appointment");
                ShowError("Error adding appointment");
            }
        }
        
        private async void DeleteAppointment(Appointment appointment)
        {
            try
            {
                await _repository.DeleteAppointment(appointment);
                week = await _repository.GetSchedule(week.TargetDate);
                Appointments = week.Today;
                WeekSummary = week.WeekSummary;
                UpdateBindingSources();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error deleting appointment.");
                ShowError("Error deleting appointment.");
            }
        }
        
        private void GenerateReport(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        
        private async void ManageClients()
        {
            try
            {
                week = await _repository.GetSchedule(week.TargetDate);
                Appointments = week.Today;
                WeekSummary = week.WeekSummary;
                UpdateBindingSources();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error updating appointment");
                ShowError("Error updating appointment");
            }
        }

        public bool IsWithinBusinessHours(DateTime start, DateTime end)
        {
            // TODO between 9AM - 5pm Monday - Friday, Eastern Standard Time
            // this shouldn't be necessary here, available start times will be given to form for validation
            return false;
        }

        public bool IsOverlappingAppointment(DateTime start)
        {
            // TODO Making an assumption that 1hr appointment slots, get appointments from db sorted by start date/time and use binary search to check?
            // again handled elsewhere
            return false;
        }

        private async void ChangeCurrentDate(DateTime start)
        {
            week = await _repository.GetSchedule(start);
            Appointments = week.Today;
            WeekSummary = week.WeekSummary;
            UpdateBindingSources();
        }
    }
}
