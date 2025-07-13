using ClientApp.Models;
using ClientApp.ViewModels;

namespace ClientApp.Views;

[QueryProperty(nameof(Client), "client")]
public partial class EditClientPage : ContentPage
{
    public EditClientPage(EditClientViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    public Client Client
    {
        set
        {
            if (BindingContext is EditClientViewModel vm && value != null)
                vm.LoadClient(value);
        }
    }
}
