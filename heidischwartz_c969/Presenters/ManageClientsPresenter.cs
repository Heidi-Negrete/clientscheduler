using heidischwartz_c969.Forms;
using heidischwartz_c969.Views;

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

        public async void updateClients()
        {
            _view.Clients = await _view.Scheduler.getCustomers();
            _view.updateView();
        }
        
        private async void addClient(object sender, ClientEventArgs e)
        {
            // check that Client does not already exist (a client by this name already exists, are you sure you want to add?)
            try
            {
                await _view.Scheduler.addCustomer(e.client);
                updateClients();
                _view.successfullySubmitClientChanges();
                _view.Client = null;
                _view.addingClient = false;
            }
            catch (Exception ex)
            {
                _view.ShowError("Error adding client: " + ex.Message);
            }
        }

        private async void editClient(object sender, ClientEventArgs e)
        {
            try
            {
                await _view.Scheduler.updateCustomer(e.client);
                updateClients();
                _view.successfullySubmitClientChanges();
            }
            catch (Exception ex)
            {
                _view.ShowError("Error editing client: " + ex.Message);
            }
        }

        private async void deleteClient(object sender, ClientEventArgs e)
        {
            try
            {
                Console.WriteLine(e.client.CreatedBy);
                await _view.Scheduler.deleteCustomer(e.client);
                updateClients();
                _view.successfullySubmitClientChanges();
            }
            catch (Exception ex)
            {
                _view.ShowError("Error deleting client: " + ex.Message);
            }
        }
    }
}
