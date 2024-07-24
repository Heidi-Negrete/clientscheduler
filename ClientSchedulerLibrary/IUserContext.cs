using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heidischwartz_c969.Forms
{
    public class IUserContext
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public IUserContext(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
