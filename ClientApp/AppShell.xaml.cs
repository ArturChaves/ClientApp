using ClientApp.Views;

namespace ClientApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(AddClientPage), typeof(AddClientPage));
        Routing.RegisterRoute(nameof(ClientListPage), typeof(ClientListPage));
        Routing.RegisterRoute(nameof(EditClientPage), typeof(EditClientPage));
    }
}

