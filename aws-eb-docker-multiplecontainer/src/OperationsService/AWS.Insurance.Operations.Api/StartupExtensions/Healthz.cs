using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;

namespace AWS.Insurance.Operations.Api.StartupExtensions
{
    public static class Healthz
    {
        public static IServiceCollection ConfigureHealthzCheck(this IServiceCollection services,
                                                                    IConfiguration configuration)
        {
            var uriServiceName = configuration.GetSection("UriServiceName").Value;

            services.AddHealthChecks()
                    .AddMySql(
                        connectionString: configuration.GetConnectionString("DefaultConnection"),
                        name: "MySql Server DB",
                        timeout: TimeSpan.FromSeconds(60),
                        tags: new string[] { "ready" },
                        failureStatus: HealthStatus.Unhealthy);

            services.AddHealthChecksUI(opt =>
            {
                opt.SetEvaluationTimeInSeconds(5);
                opt.MaximumHistoryEntriesPerEndpoint(60);
                opt.SetApiMaxActiveRequests(1);
                opt.AddHealthCheckEndpoint("Operations API", $"{uriServiceName}/health/lively");
            })
            .AddInMemoryStorage();

            return services;
        }
    }
}