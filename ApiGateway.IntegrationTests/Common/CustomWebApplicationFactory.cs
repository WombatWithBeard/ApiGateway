using System;
using System.Linq;
using Application.Common.Interfaces;
using Infrastructure.Tools;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ApiGateway.IntegrationTests.Common
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                var descriptor = services.SingleOrDefault(d =>
                    d.ServiceType == typeof(DbContextOptions<ApiGatewayDbContext>));
                if (descriptor != null)
                    services.Remove(descriptor);

                services.AddDbContext<ApiGatewayDbContext>(optionsBuilder =>
                {
                    optionsBuilder.UseInMemoryDatabase("InMemoryDb");
                });

                services.AddScoped<IApiGatewayDbContext>(provider => provider.GetService<ApiGatewayDbContext>());

                var sp = services.BuildServiceProvider();

                using var scope = sp.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<ApiGatewayDbContext>();
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                context.Database.EnsureCreated();

                try
                {
                    Utilities.InitializeDbForTests(context);
                }
                catch (Exception e)
                {
                    logger.LogError(e, "An error occurred seeding the " +
                                       "database with test messages. Error: {Message}", e.Message);
                }

                services.AddAuthentication("Test")
                    .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(
                        "Test", options => { });
            });
            base.ConfigureWebHost(builder);
        }
    }
}