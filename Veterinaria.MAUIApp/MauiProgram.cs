//BUENOO

using Microsoft.Extensions.Logging;
using Veterinaria.MAUIApp.Services;
using Veterinaria.MAUIApplication.Services;

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

            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8080/") // Ajusta la URL si cambias de puerto/servidor
            });

            // ✅ Servicios que usan HttpClient
            builder.Services.AddScoped<DiaService>();
            builder.Services.AddScoped<EstadoDiaService>();
            builder.Services.AddScoped<AgendaService>();
            builder.Services.AddScoped<BloqueHorarioService>();
            builder.Services.AddScoped<ProveedorService>();
            builder.Services.AddScoped<MedicamentoService>();


            return builder.Build();
        }
    }
}



