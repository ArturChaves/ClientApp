using ClientApp.Models;
using ClientApp.Services;
using ClientApp.Helpers;
using System.Windows.Input;

namespace ClientApp.ViewModels
{
    public class AddClientViewModel : BaseViewModel
    {
        private readonly ClientService _clientService;

        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public AddClientViewModel(ClientService clientService)
        {
            _clientService = clientService;

            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);
        }

        private async void Save()
        {
            if (!int.TryParse(Age, out int parsedAge))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Age must be a number.", "OK");
                return;
            }

            var newClient = new Client
            {
                Name = Name,
                Lastname = Lastname,
                Age = parsedAge,
                Address = Address
            };

            _clientService.AddClient(newClient);
            await Shell.Current.GoToAsync(".."); // Volta à tela anterior
        }

        private async void Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
