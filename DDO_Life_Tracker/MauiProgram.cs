using DDO_Life_Tracker.Database;
using DDO_Life_Tracker.Database.Tables;
using DDO_Life_Tracker.ViewModels;
using MetroLog.MicrosoftExtensions;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace DDO_Life_Tracker
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<IncarnationDatabase>();

            builder.Services.AddTransient<NewIncarnationPage>();
            builder.Services.AddTransient<NewIncarnationViewModel>();

            builder.Logging.AddStreamingFileLogger(options =>
            {
                options.FolderPath = Path.Combine(AppContext.BaseDirectory, "Logs");
                options.MinLevel = LogLevel.Information;
            });
#if DEBUG
            builder.Logging.AddTraceLogger(options =>
            {
                options.MinLevel = LogLevel.Debug;
            });
#endif

            return builder.Build();
        }
    }
}
