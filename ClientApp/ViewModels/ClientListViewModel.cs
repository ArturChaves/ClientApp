using ClientApp.Models;
using ClientApp.Services;
using ClientApp.Helpers;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ClientApp.Views;

namespace ClientApp.ViewModels
{
    public class ClientListViewModel : BaseViewModel
    {
        private readonly ClientService _clientService;

        public ObservableCollection<Client> Clients { get; }

        private Client _selectedClient;
        public Client SelectedClient
        {
            get => _selectedClient;
            set
            {
                if (SetProperty(ref _selectedClient, value))
                {
                    OnPropertyChanged(nameof(IsClientSelected));
                    (EditCommand as RelayCommand)?.RaiseCanExecuteChanged();
                    (DeleteCommand as RelayCommand)?.RaiseCanExecuteChanged();
                }
            }
        }

        public bool IsClientSelected => SelectedClient != null;

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public ClientListViewModel(ClientService clientService)
        {
            _clientService = clientService;
            Clients = _clientService.GetClients();

            EditCommand = new RelayCommand(OnEdit, () => SelectedClient != null);
            DeleteCommand = new RelayCommand(OnDelete, () => SelectedClient != null);
        }

        private void OnEdit()
        {
            if (SelectedClient != null)
            {
                var page = ServiceHelper.GetService<EditClientPage>();
                var window = new Window(page);

                if (page.BindingContext is EditClientViewModel vm)
                {
                    vm.LoadClient(SelectedClient);
                    vm.SetWindow(window); // ✅ tem que estar AQUI dentro!
                }

                Application.Current.OpenWindow(window);
            }
        }

        private async void OnDelete()
        {
            if (SelectedClient != null)
            {
                bool confirm = await Application.Current.MainPage.DisplayAlert(
                    "Confirm Deletion",
                    $"Are you sure you want to delete {SelectedClient.Name} {SelectedClient.Lastname}?",
                    "Yes", "No");

                if (confirm)
                {
                    _clientService.RemoveClient(SelectedClient);
                    SelectedClient = null;
                }
            }
        }
    }
}
