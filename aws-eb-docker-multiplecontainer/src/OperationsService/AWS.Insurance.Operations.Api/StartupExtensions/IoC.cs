using AutoMapper;
using AWS.Insurance.Operations.Application.Cars;
using AWS.Insurance.Operations.Application.Gateways;
using AWS.Insurance.Operations.Data.Context;
using AWS.Insurance.Operations.Data.UoW;
using AWS.Insurance.Operations.Infra.Zones;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AWS.Insurance.Operations.Api.StartupExtensions
{
    public static class IoC
    {
        public static IServiceCollection ConfigureIOC(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Create.Handler).Assembly);
            services.AddAutoMapper(typeof(Create.Handler).Assembly);

            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<OpDbContext>();

            return services;
        }
    }
}