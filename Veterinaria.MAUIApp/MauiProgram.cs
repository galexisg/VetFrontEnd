using Microsoft.Extensions.Logging;
using Veterinaria.MAUIApp.Models;
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

            // Instanciar HttpClient una sola vez
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8080/") // <-- usar HTTP
            };

            // Registrar el HttpClient como un singleton
            builder.Services.AddSingleton(httpClient);

            // Registrar servicios
            builder.Services.AddScoped<MotivoCitaService>();
            builder.Services.AddScoped<DiaService>();
            builder.Services.AddScoped<EstadoDiaService>();
            builder.Services.AddSingleton<AgendaService>();
            builder.Services.AddSingleton<BloqueHorarioService>();

            return builder.Build();
        }
    }
}
