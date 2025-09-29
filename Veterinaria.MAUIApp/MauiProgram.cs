using Microsoft.Extensions.Logging;

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
                BaseAddress = new Uri("http://localhost:8080/")
            });


            /*Añadir servicios Gisela*/
            builder.Services.AddScoped<Veterinaria.MAUIApp.Services.TratamientoService>();
            builder.Services.AddScoped<Veterinaria.MAUIApp.Services.TratamientoAplicadoService>();
            builder.Services.AddScoped<Veterinaria.MAUIApp.Services.ServicioTratamientoService>();



            return builder.Build();
        }
    }
}
