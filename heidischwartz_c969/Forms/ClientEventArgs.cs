using heidischwartz_c969.Models;

namespace heidischwartz_c969.Forms
{
    public class ClientEventArgs
    {
        public Customer client { get; private set; }
        public ClientEventArgs(Customer customer)
        {
            client = customer;
        }
    }
}