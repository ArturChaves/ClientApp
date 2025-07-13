using ClientApp.Services;
using ClientApp.ViewModels;
using ClientApp;
using ClientApp.Views; 

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>();

        builder.Services.AddSingleton<ClientService>();
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<AddClientPage>();
        builder.Services.AddTransient<AddClientViewModel>();
        builder.Services.AddTransient<ClientListPage>();
        builder.Services.AddTransient<ClientListViewModel>();
        builder.Services.AddTransient<EditClientPage>();
        builder.Services.AddTransient<EditClientViewModel>();



        return builder.Build();
    }
}
