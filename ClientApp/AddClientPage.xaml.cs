using ClientApp.ViewModels;

namespace ClientApp.Views;

public partial class AddClientPage : ContentPage
{
    public AddClientPage(AddClientViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
