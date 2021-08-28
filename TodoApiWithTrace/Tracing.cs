using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Trace;

namespace TodoApiWithTrace
{
    public class AllTheTrace
    {
        public static void InstallTracingInServices(IServiceCollection services)
        {
            services.AddOpenTelemetryTracing(
                (builder) => builder
                    .AddAspNetCoreInstrumentation()
                    .AddJaegerExporter()
                    .AddConsoleExporter()
                    .AddHttpClientInstrumentation()
                );
        }
    }
}