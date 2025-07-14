namespace ClientApp.Helpers
{
    public static class ServiceHelper
    {
        public static IServiceProvider Services =>
            Application.Current?.Handler?.MauiContext?.Services
            ?? throw new InvalidOperationException("Maui context not available");

        public static T GetService<T>() where T : notnull =>
            Services.GetRequiredService<T>();
    }
}
