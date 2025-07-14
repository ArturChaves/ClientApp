using ClientApp.Models;
using ClientApp.Services;
using ClientApp.Helpers;
using System.Windows.Input;

namespace ClientApp.ViewModels
{
    public class EditClientViewModel : BaseViewModel
    {
        private readonly ClientService _clientService;
        private Client _originalClient;

        private Window _currentWindow;

        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public EditClientViewModel(ClientService clientService)
        {
            _clientService = clientService;

            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);
        }

        public void SetWindow(Window window)
        {
            _currentWindow = window;
        }

        public void LoadClient(Client client)
        {
            _originalClient = client;

            Name = client.Name;
            Lastname = client.Lastname;
            Age = client.Age.ToString();
            Address = client.Address;

            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Lastname));
            OnPropertyChanged(nameof(Age));
            OnPropertyChanged(nameof(Address));
        }

        private void Save()
        {
            if (!int.TryParse(Age, out int parsedAge))
            {
                _ = Application.Current.MainPage.DisplayAlert("Error", "Age must be a number.", "OK");
                return;
            }

            var updated = new Client
            {
                Name = Name,
                Lastname = Lastname,
                Age = parsedAge,
                Address = Address
            };

            _clientService.UpdateClient(_originalClient, updated);

            if (_currentWindow is not null)
                Application.Current.CloseWindow(_currentWindow);
        }

        private void Cancel()
        {
            if (_currentWindow is not null)
                Application.Current.CloseWindow(_currentWindow);
        }
    }
}
