using ClientApp.Helpers;
using ClientApp.Views;

#if WINDOWS
using Microsoft.UI.Windowing;
using Microsoft.Maui.Platform;
using WinRT.Interop;
using Microsoft.UI;
#endif

namespace ClientApp;

public partial class MainPage : ContentPage
{
    private Window _clientListWindow;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnAddClientClicked(object sender, EventArgs e)
    {
        var page = ServiceHelper.GetService<AddClientPage>();
        var window = new Window(page);
        Application.Current.OpenWindow(window);
    }

    private void OnViewClientsClicked(object sender, EventArgs e)
    {
       
        if (_clientListWindow is not null &&
            Application.Current?.Windows.Any(w => w == _clientListWindow) == true)
        {
#if WINDOWS
            var mauiWindow = _clientListWindow.Handler?.PlatformView as Microsoft.UI.Xaml.Window;
            if (mauiWindow is not null)
            {
                var hwnd = WindowNative.GetWindowHandle(mauiWindow);
                var windowId = Win32Interop.GetWindowIdFromWindow(hwnd);
                var appWindow = AppWindow.GetFromWindowId(windowId);

                if (appWindow is not null)
                {
                    appWindow.Show(); 

                    if (appWindow.Presenter is OverlappedPresenter presenter)
                    {
                        presenter.Restore(); 
                    }
                }
            }
#endif
            return;
        }

        
        var page = ServiceHelper.GetService<ClientListPage>();
        _clientListWindow = new Window(page);

        
        _clientListWindow.Destroying += (s, e) =>
        {
            _clientListWindow = null;
        };

        Application.Current.OpenWindow(_clientListWindow);
    }
}
