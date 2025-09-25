using Microsoft.Extensions.Logging;
using Veterinaria.MAUIApp.Services;

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

            // HttpClient hacia tu API en IntelliJ
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8080/")

            });

            // Registrar servicios
            builder.Services.AddScoped<DiaService>();
            builder.Services.AddScoped<EstadoDiaService>();

            return builder.Build();
        }
    }
}
