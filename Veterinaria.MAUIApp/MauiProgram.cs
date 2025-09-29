using Microsoft.Extensions.Logging;
using System.Globalization; // <- necesario para la cultura
using Veterinaria.MAUIApp.Models;

namespace Veterinaria.MAUIApp
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
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            builder.Services.AddScoped(http => new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8080/") // <-- usar HTTP
            });

            builder.Logging.AddDebug();

            builder.Services.AddScoped<Veterinaria.MAUIApp.Services.MotivoCitaService>();

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es-ES");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("es-ES");

            return builder.Build();
        }
    }
}
