using ClientApp.ViewModels;

namespace ClientApp.Views;

public partial class ClientListPage : ContentPage
{
    public ClientListPage(ClientListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}