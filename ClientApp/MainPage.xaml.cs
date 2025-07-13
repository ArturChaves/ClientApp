using ClientApp.Helpers;
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
        var page = ServiceHelper.GetService<AddClientPage>();
        var window = new Window(page);
        Application.Current.OpenWindow(window);

    }

    private async void OnViewClientsClicked(object sender, EventArgs e)
    {
        var page = ServiceHelper.GetService<ClientListPage>();
        var window = new Window(page);
        Application.Current.OpenWindow(window);
    }



}
