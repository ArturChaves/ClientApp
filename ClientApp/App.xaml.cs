using ClientApp.Helpers;

#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Microsoft.Maui.Platform;
using Windows.Graphics;
using WinRT.Interop;
#endif



namespace ClientApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var mainPage = ServiceHelper.GetService<MainPage>();
        var window = new Window(mainPage);

#if WINDOWS
    window.Created += (s, e) =>
    {
        var mauiWinUIWindow = ((MauiWinUIWindow)(window.Handler?.PlatformView));
        var hwnd = WindowNative.GetWindowHandle(mauiWinUIWindow);
        var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(hwnd);
        var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);

        if (appWindow.Presenter is Microsoft.UI.Windowing.OverlappedPresenter presenter)
        {
            presenter.Maximize();
        }
    };
#endif

        return window;
    }

}
