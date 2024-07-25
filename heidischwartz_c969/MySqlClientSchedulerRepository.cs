using heidischwartz_c969.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heidischwartz_c969
{
    public class MySqlClientSchedulerRepository : IClientSchedulerRepository
    {
        public ClientSchedulerContext _context { get; }

        public MySqlClientSchedulerRepository(ClientSchedulerContext context)
        {
            if (context ==  null) throw new ArgumentNullException("context");
            _context = context;
        }
    }
}
