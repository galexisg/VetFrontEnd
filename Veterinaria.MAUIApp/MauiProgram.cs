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

            // Configuración de HttpClient
#if ANDROID
            var baseAddress = new Uri("http://10.0.2.2:8080/api/"); // Para Android Emulator -> Spring Boot
#else
            var baseAddress = new Uri("https://localhost:8080/api/"); // Para Windows o iOS simulador
#endif

            builder.Services.AddScoped(sp => new HttpClient
            { 
                BaseAddress = baseAddress
            });

            // 🔹 Registro de servicios (inyección de dependencias)
            builder.Services.AddScoped<UsuarioService>();
            builder.Services.AddScoped<FacturaService>();
            builder.Services.AddScoped<PagoService>();
            // Aquí luego puedes agregar ClienteService, MascotaService, etc.

            return builder.Build();
        }
    }
}
