using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;

namespace AWS.Insurance.Operations.Api.StartupExtensions
{
    public static class EndPointz
    {
        public static IApplicationBuilder UseEndpointz(this IApplicationBuilder builder, IWebHostEnvironment env)
        {
            builder.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapHealthChecks("/health/lively", new HealthCheckOptions
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
                });

                endpoints.MapHealthChecks("/health/ready", new HealthCheckOptions()
                {
                    Predicate = reg => reg.Tags.Contains("ready"),
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                }).RequireHost("127.0.0.1:5000");

                endpoints.MapHealthChecksUI(setup =>
                {
                    setup.UIPath = "/healthchecks-ui";
                    setup.ApiPath = "/healthchecks-ui-api";
                });

                endpoints.Map("/", async (context) =>
                {
                    var result = JsonSerializer.Serialize(new
                    {
                        machineName = Environment.MachineName,
                        appName = env.ApplicationName,
                        environment = env.EnvironmentName
                    });

                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(result.ToString());
                });
            });

            return builder;
        }
    }
}