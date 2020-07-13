using System;
using EntitySeedData.Entities.Ocelot;
using Infrastructure.Tools;
using Microsoft.EntityFrameworkCore;

namespace Application.UnitTests.Common
{
    public class ContextFactory
    {
        public static ApiGatewayDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ApiGatewayDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new ApiGatewayDbContext(options);

            context.Database.EnsureCreated();

            context.Routes.AddRange(new SeedRoutes().Seed());
            context.AuthenticationOptions.AddRange(new SeedAuthenticationOptions().Seed());
            context.GlobalConfigurations.AddRange(new SeedGlobalConfigurations().Seed());
            context.LoadBalancerOptions.AddRange(new SeedLoadBalancerOptions().Seed());
            context.DownstreamHostAndPorts.AddRange(new SeedDownstreamHostAndPorts().Seed());
            context.RouteClaimsRequirements.AddRange(new SeedRouteClaimsRequirements().Seed());

            context.SaveChanges();

            return context;
        }

        public static void Destroy(ApiGatewayDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}