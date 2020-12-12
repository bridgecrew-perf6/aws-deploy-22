using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace AWS.EBDeploy.Api.Tests.IntegrationTests.Config
{
    public class AWSAppFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseSetting("https_port", "5001");
            builder.UseStartup<TStartup>();
            builder.UseEnvironment("Testing");
        }
    }

}
