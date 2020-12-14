using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AWS.Insurance.Operations.Api.StartupExtensions
{
    public static class Factoriesz
    {
        public static IServiceCollection ConfigureHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            var locationService = configuration.GetSection("ExternalAPIs:LocationApi").Value;
            services.AddHttpClient("LocationService", client =>
            {
                client.BaseAddress = new Uri($"{locationService}/");
                client.Timeout = TimeSpan.FromSeconds(20);
            });

            return services;
        }
    }
}