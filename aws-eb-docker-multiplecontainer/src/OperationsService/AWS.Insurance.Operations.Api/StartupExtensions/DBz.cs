using AWS.Insurance.Operations.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AWS.Insurance.Operations.Api.StartupExtensions
{
    public static class DBz
    {
        public static IServiceCollection ConfigureDatabaseConn(this IServiceCollection services, IConfiguration configuration)
        {
            var connString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<OpDbContext>(opt =>
            {
                opt.UseLazyLoadingProxies();
                opt.UseMySql(connString);
            });

            return services;
        }
    }
}