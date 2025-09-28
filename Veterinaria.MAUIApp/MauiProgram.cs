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

            // Instanciar HttpClient una sola vez
            

            // Registrar tu servicio, pasándole la instancia de HttpClient
            builder.Services.AddSingleton<AgendaService>();

            builder.Services.AddSingleton<BloqueHorarioService>();

            builder.Services.AddScoped<AlmacenService>();



            // También puedes registrar otros servicios si los necesitas
            builder.Services.AddScoped<UsuarioService>();
            builder.Services.AddScoped<DispensaService>();

            //builder.Services.AddScoped<AlmacenService>();
            //builder.Services.AddScoped<LoteService>();
            //builder.Services.AddScoped<PrescripcionService>();


            return builder.Build();
        }
    }
}