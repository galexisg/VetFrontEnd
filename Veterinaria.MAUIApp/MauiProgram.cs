using Microsoft.Extensions.Logging;
using Veterinaria.MAUIApp.Services;
using Veterinaria.MAUIApp.Utils;

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

            // ======== BASE URL por plataforma ========
            var baseUrl = ApiBase.Get(); // ANDROID -> http://10.0.2.2:8080/api/ ; WINDOWS -> http://localhost:8080/api/
            builder.Services.AddSingleton(new ApiOptions { BaseUrl = baseUrl });

            // ======== HttpClient (dos opciones) ========

            // Opción A: UN HttpClient compartido (si tus servicios reciben HttpClient en el ctor)
            builder.Services.AddSingleton(sp =>
            {
                var opts = sp.GetRequiredService<ApiOptions>();
                return new HttpClient { BaseAddress = new Uri(opts.BaseUrl) };
            });

            // Opción B (recomendada a futuro): IHttpClientFactory con cliente nombrado "api"
            builder.Services.AddHttpClient("api", (sp, http) =>
            {
                var opts = sp.GetRequiredService<ApiOptions>();
                http.BaseAddress = new Uri(opts.BaseUrl);
            });

            // ======== Tus servicios ========
            builder.Services.AddSingleton<FacturaService>();
            builder.Services.AddSingleton<PagoService>();
            builder.Services.AddSingleton<MotivoService>();
            builder.Services.AddSingleton<ServicioService>();
            builder.Services.AddSingleton<UsuarioService>();

            return builder.Build();
        }
    }
}
