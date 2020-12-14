using AWS.Insurance.Operations.Api.Middlewares;
using AWS.Insurance.Operations.Api.StartupExtensions;
using AWS.Insurance.Operations.Application.Cars;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace AWS.Insurance.Operations.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(cfg =>
                {
                    cfg.RegisterValidatorsFromAssemblyContaining<Create>();
                }); ;

            services
                    .ConfigureDatabaseConn(Configuration)
                    .ConfigureHttpClients(Configuration)
                    .ConfigureHttpContextAcessor()
                    .ConfigureDistributedCached(Configuration)
                    .ConfigureIOC()
                    .ConfigureHealthzCheck(Configuration)
                    .ConfigureSwaggerOperation();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Log.Information($"Hosting enviroment = {env.EnvironmentName}");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseSwaggerOperation();
            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseErrorHandlerMiddleware();
            app.UseEndpointz(env);
        }
    }
}
