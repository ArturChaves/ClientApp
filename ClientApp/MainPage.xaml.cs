using ClientApp.Views;

namespace ClientApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnAddClientClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddClientPage));
    }

    private async void OnViewClientsClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ClientListPage));
    }


}
