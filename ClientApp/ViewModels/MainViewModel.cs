using ClientApp.Helpers;
using ClientApp.Models;
using ClientApp.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ClientApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ClientService _clientService;

        public ObservableCollection<Client> Clients { get; }

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

        private Client _selectedClient;
        public Client SelectedClient
        {
            get => _selectedClient;
            set => SetProperty(ref _selectedClient, value);
        }

        public MainViewModel(ClientService clientService)
        {
            _clientService = clientService;
            Clients = _clientService.GetClients();

            AddCommand = new RelayCommand(OnAdd);
            DeleteCommand = new RelayCommand(OnDelete, () => SelectedClient != null);
        }

        private void OnAdd()
        {
            var newClient = new Client
            {
                Name = "New",
                Lastname = "Client",
                Age = 0,
                Address = "..."
            };
            _clientService.AddClient(newClient);
        }

        private void OnDelete()
        {
            if (SelectedClient != null)
                _clientService.RemoveClient(SelectedClient);
        }
    }
}
