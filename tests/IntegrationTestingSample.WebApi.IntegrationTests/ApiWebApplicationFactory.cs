using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTestingSample.WebApi.IntegrationTests
{
    public class ApiWebApplicationFactory : WebApplicationFactory<WebApi.Startup>
    {
        public IConfiguration Configuration { get; private set; }

        public Action<IServiceCollection> ContainerOverride { get; set; }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(config =>
            {
                Configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();

                config.AddConfiguration(Configuration);
            });

            builder.ConfigureTestServices(services =>
            {
                //services.AddMvc(options => options.Filters.Add(new AllowAnonymousFilter()));
                ContainerOverride?.Invoke(services);
            });
        }
    }
}
