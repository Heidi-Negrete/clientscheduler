﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heidischwartz_c969.Views
{
    public interface IView
    {
        public SchedulerService Scheduler { get; set; }
    }
}
