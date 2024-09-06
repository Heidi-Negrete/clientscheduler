using heidischwartz_c969.Forms;
using heidischwartz_c969.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heidischwartz_c969.Views
{
    public interface IManageClientsView: IView
    {
        public event EventHandler<ClientEventArgs> AddClient;
        public event EventHandler<ClientEventArgs> EditClient;
        public event EventHandler<ClientEventArgs> DeleteClient;
        public List<Customer> Clients { get; set; }
        public Customer Client { get; set; }
        public bool addingClient { get; set; }
        public void updateView();
        public void successfullySubmitClientChanges();
    }
}
