namespace heidischwartz_c969.Forms
{
    public partial class Report : Form
    {
        private readonly IClientSchedulerRepository _repository;
        private string reportType;
        public Report(IClientSchedulerRepository repository, string reportType)
        {
            InitializeComponent();
            _repository = repository;
            this.reportType = reportType;
        }

        // REPORTS
        // the number of appointment types by month
        //	the schedule for each user
        // one additional report of your choice Clients by active / inactive?

        // thoughts for after basic implementation: caching to reduce load on db?
        // Get new appointments after deleting (put logic in presenter)
    }
}