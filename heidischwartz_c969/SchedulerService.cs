using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heidischwartz_c969
{
    public class SchedulerService : ISchedulerService
    {
        // use an IClientSchedulerRepository instance to retrieve things needed from db
        public IClientSchedulerRepository _repository;
        public string? user;

        public SchedulerService(IClientSchedulerRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");
            _repository = repository;
        }

        public bool Login(string username, string password)
        {
            // hardcoded atm, need to check w values returned from repository 
            if (username == "test" &&  password == "test") return true;
            return false;
        }
        // add update and delete client records
        // get all clients where user is user
        // add update and delete appointments
        // get all appointments where user is user
        // the number of appointment types by month
        //	the schedule for each user
        // one additional report of your choice Clients by active / inactive?

    }
}
