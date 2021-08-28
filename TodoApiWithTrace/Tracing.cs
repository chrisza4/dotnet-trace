using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Trace;

namespace TodoApiWithTrace
{
    public class AllTheTrace
    {
        public static void InstallOpenTelemetryTracing(IServiceCollection services)
        {
            services.AddOpenTelemetryTracing(
                (builder) => builder
                    .AddAspNetCoreInstrumentation()
                    .AddSource(nameof(Controllers.MyController))
                    .AddJaegerExporter()
                    .AddConsoleExporter()
                    .AddHttpClientInstrumentation()
                );
        }
    }
}