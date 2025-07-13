using ClientApp.Models;
using System.Collections.ObjectModel;

namespace ClientApp.Services
{
    public class ClientService
    {
        private readonly ObservableCollection<Client> _clients;

        public ClientService()
        {
            _clients = new ObservableCollection<Client>();
        }

        public ObservableCollection<Client> GetClients()
        {
            return _clients;
        }

        public void AddClient(Client client)
        {
            _clients.Add(client);
        }

        public void RemoveClient(Client client)
        {
            _clients.Remove(client);
        }

        public void UpdateClient(Client original, Client update)
        {
            var index = _clients.IndexOf(original);
            if (index >= 0)
                _clients[index] = update;
        }
    }
}
