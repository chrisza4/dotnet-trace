using System.Diagnostics;
using Amazon.XRay.Recorder.Handlers.AwsSdk;
using Microsoft.AspNetCore.Builder;
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

        public static void InstallXRayTracing(IApplicationBuilder app) 
        {
            app.UseXRay("App");
            AWSSDKHandler.RegisterXRayForAllServices();
        }
    }
}
