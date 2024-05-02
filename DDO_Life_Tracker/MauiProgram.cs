using CommunityToolkit.Maui;
using DDO_Life_Tracker.Database;
using DDO_Life_Tracker.Database.Tables;
using DDO_Life_Tracker.Pages;
using DDO_Life_Tracker.Services;
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
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<IncarnationDatabase>();
            builder.Services.AddSingleton<IncarnationDBService>();

            builder.Services.AddTransient<AddCharacterPage>();
            builder.Services.AddTransient<AddCharacterViewModel>();
            builder.Services.AddTransient<AddIncarnationPage>();
            builder.Services.AddTransient<AddIncarnationViewModel>();

            builder.Logging.AddStreamingFileLogger(options =>
            {
                options.FolderPath = Path.Combine(AppContext.BaseDirectory, "Logs");
                options.MinLevel = LogLevel.Information;
                options.RetainDays = 30;
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
