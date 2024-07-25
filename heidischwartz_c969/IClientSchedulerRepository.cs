using heidischwartz_c969.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heidischwartz_c969
{
    public interface IClientSchedulerRepository
    {
        public ClientSchedulerContext _context { get; }

        // return raw entities from the persistence store, and
        // ISchedulerService will apply business logic such as time zone conversions
    }
}
