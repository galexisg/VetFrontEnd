using Microsoft.Extensions.Logging;
<<<<<<< HEAD
using Veterinaria.MAUIApp.Services;
=======
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using VetApp.Services;
using Veterinaria.MAUIApp.Services;
using Veterinaria.MAUIApp.Utils;
using Veterinaria.MAUIApplication.Services;
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981

namespace Veterinaria.MAUIApp
{
    // Handler simple para loguear URL y respuestas (útil para diagnosticar)
    public sealed class HttpLoggingHandler : DelegatingHandler
    {
        public HttpLoggingHandler() : base(new HttpClientHandler()) { }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            System.Diagnostics.Debug.WriteLine($"[HTTP] {request.Method} {request.RequestUri}");
            var response = await base.SendAsync(request, cancellationToken);
            var payload = await response.Content.ReadAsStringAsync(cancellationToken);
            System.Diagnostics.Debug.WriteLine($"[HTTP] {(int)response.StatusCode} {response.ReasonPhrase} -> {payload}");
            return response;
        }
    }

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

<<<<<<< HEAD
            // HttpClient hacia tu API en IntelliJ
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8080/")

            });

            // Registrar servicios
            builder.Services.AddScoped<DiaService>();
            builder.Services.AddScoped<EstadoDiaService>();

            // Instanciar HttpClient una sola vez
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8080/") // o la URL correcta para tu API
            };

            // Registrar el HttpClient como un singleton
            builder.Services.AddSingleton(httpClient);

            // Registrar tu servicio, pasándole la instancia de HttpClient
            builder.Services.AddSingleton<AgendaService>();

            builder.Services.AddSingleton<BloqueHorarioService>();

=======
            // ========= BASE URL por plataforma =========
            // ApiBase.Get() debe devolver SIN el sufijo "/api"
            // ANDROID -> http://10.0.2.2:8080/
            // WINDOWS -> http://localhost:8080/
            var baseUrl = ApiBase.Get();
            builder.Services.AddSingleton(new ApiOptions { BaseUrl = baseUrl });

            // ========= HttpClient (singleton) =========
            // Inyectable como HttpClient directamente en tus servicios
            builder.Services.AddSingleton(sp =>
            {
                var opts = sp.GetRequiredService<ApiOptions>();
                var handler = new HttpLoggingHandler(); // opcional: quítalo si no quieres logs
                var http = new HttpClient(handler)
                {
                    BaseAddress = new Uri(opts.BaseUrl) // SIN /api
                };
                return http;
            });

            // ========= HttpClientFactory (opcional) =========
            // Cliente nombrado "api" (si alguno de tus servicios quiere usar IHttpClientFactory)
            builder.Services.AddHttpClient("api", (sp, http) =>
            {
                var opts = sp.GetRequiredService<ApiOptions>();
                http.BaseAddress = new Uri(opts.BaseUrl); // SIN /api
            })
            .AddHttpMessageHandler(() => new HttpLoggingHandler());

            // ========= Servicios =========
            builder.Services.AddScoped<FacturaService>();
            builder.Services.AddScoped<PagoService>();
            builder.Services.AddScoped<MotivoService>();
            builder.Services.AddScoped<ServicioService>();
            builder.Services.AddScoped<UsuarioService>();
            builder.Services.AddScoped<AuthService>();
            builder.Services.AddScoped<DiagnosticoService>();
            builder.Services.AddScoped<TratamientosAplicadosService>();
            builder.Services.AddScoped<CitaService>();
            builder.Services.AddScoped<VacunaService>();
            builder.Services.AddScoped<TratamientoService>();
            builder.Services.AddScoped<MotivoCitaService>();
            builder.Services.AddScoped<EstadoDiaService>();
            builder.Services.AddScoped<DiaService>();
            builder.Services.AddScoped<AgendaService>();
            builder.Services.AddScoped<VeterinarioService>();

            builder.Services.AddScoped<RazaService>();
            builder.Services.AddScoped<EspecieService>();
            builder.Services.AddScoped<EspecialidadService>();
            builder.Services.AddSingleton<BloqueHorarioService>();

            builder.Services.AddScoped<ProveedorService>();
            builder.Services.AddScoped<MedicamentoService>();

            builder.Services.AddScoped<CompraService>();
>>>>>>> cce7d4c545429baff3534df3b6bc33f01fcbd981


            return builder.Build();
        }
    }
}