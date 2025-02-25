using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heidischwartz_c969
{
    internal static class UserContext
    {
        static public string? Name {get; set;}
        static public int UserId { get; set; } = 0;
        
        static public string? Location { get; set; }
    }
}
