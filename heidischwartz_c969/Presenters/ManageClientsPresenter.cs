using heidischwartz_c969.Forms;
using heidischwartz_c969.Models;
using heidischwartz_c969.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace heidischwartz_c969.Presenters
{
    public class ManageClientsPresenter: Presenter
    {
        private readonly IManageClientsView _view;

        public ManageClientsPresenter(IManageClientsView view)
        {
            _view = view;
            updateClients();

            _view.AddClient += addClient;
            _view.EditClient += editClient;
            _view.DeleteClient += deleteClient;
    }

        public void updateClients()
        {
            _view.Clients = _view.Scheduler.getCustomers();
            _view.updateView();
        }
        private void addClient(object sender, ClientEventArgs e)
        {
            // check that Client does not already exist (a client by this name already exists, are you sure you want to add?)
            // dont forget to call successfullySubmitClientChanges or ShowError
            _view.Scheduler.addCustomer(e.client);
            updateClients();
            _view.successfullySubmitClientChanges();
            _view.Client = null;
            _view.addingClient = false;
        }

        private void editClient(object sender, ClientEventArgs e)
        {
            // dont forget to call successfullySubmitClientChanges or ShowError
                _view.Scheduler.updateCustomer(e.client);
                updateClients();
                _view.successfullySubmitClientChanges();
        }

        private void deleteClient(object sender, ClientEventArgs e)
        {
            // dont forget to call successfullySubmitClientChanges or ShowError
            _view.Scheduler.deleteCustomer(e.client);
            updateClients();
            _view.successfullySubmitClientChanges();
        }
    }
}
