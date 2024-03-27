using DemoApp.Handlers;
using DemoApp.ViewModal;
using Microsoft.Extensions.Logging;
using Sharpnado.Tabs;
using SQLite;
using System.Diagnostics;

namespace DemoApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseSharpnadoTabs(loggerEnable: false)
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.ConfigureMauiHandlers(handlers =>
            {
                handlers.AddHandler<Shell, CustomShellHandler>();
            });
            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
           
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddSingleton<MainViewModal>();

            builder.Services.AddTransient<DetailPage>();
            builder.Services.AddTransient<DetailViewModel>();

            // Sqlite path 
            
            string dbFileName = "GetItDone.db3";
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), dbFileName);
            // Check if the database file exists
            if (File.Exists(dbPath))
            {
                Debug.WriteLine($"Database file exists at {dbPath}");
            }
            else
            {
                Debug.WriteLine($"Database file does not exist at {dbPath}");
            }
           
            TaskDatabase database = Task.Run(() => TaskDatabase.CreateAsync(dbPath)).Result;
            builder.Services.AddScoped<TaskDatabase>(_ => database);


            builder.Services.AddSingleton<TaskItem>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
