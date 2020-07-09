using System;
using System.Linq;
using Infrastructure.Tools;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ApiGateway.IntegrationTests.Common
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(d =>
                    d.ServiceType == typeof(DbContextOptions<ApiGatewayDbContext>));
                if (descriptor != null)
                    services.Remove(descriptor);

                services.AddDbContext<ApiGatewayDbContext>(optionsBuilder =>
                {
                    optionsBuilder.UseInMemoryDatabase("InMemoryDb");
                });

                var sp = services.BuildServiceProvider();

                using var scope = sp.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<ApiGatewayDbContext>();
                var logger = scope.ServiceProvider
                    .GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                db.Database.EnsureCreated();

                try
                {
                    Utilities.InitializeDbForTests(db);
                }
                catch (Exception e)
                {
                    logger.LogError(e, "An error occurred seeding the " +
                                       "database with test messages. Error: {Message}", e.Message);
                }
            });
            base.ConfigureWebHost(builder);
        }
    }
}