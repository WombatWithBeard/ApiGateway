using System.Collections.Generic;
using Domain.Entities.Enums;
using Domain.Entities.Routes;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Tools
{
    public class TestSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            for (int i = 1; i <= 2; i++)
            {
                SeedRoutes(modelBuilder, i);
                SeedAuthOptions(modelBuilder, i);
                SeedLoadBalancer(modelBuilder, i);
                SeedDownstreamHostAndPort(modelBuilder, i);
            }

            SeedGlobalConfig(modelBuilder);
        }

        private static void SeedGlobalConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GlobalConfiguration>().HasData(new GlobalConfiguration
                {GlobalConfigurationId = 1, BaseUrl = "https://localhost:6900"});
        }

        private static void SeedDownstreamHostAndPort(ModelBuilder modelBuilder, in int i)
        {
            modelBuilder.Entity<DownstreamHostAndPort>().HasData(new DownstreamHostAndPort
            {
                Host = "localhost",
                Port = i == 2 ? 4003 : 3001,
                DownstreamHostAndPortId = i,
                RouteId = i
            });
        }

        private static void SeedLoadBalancer(ModelBuilder modelBuilder, in int i)
        {
            modelBuilder.Entity<LoadBalancerOption>().HasData(new LoadBalancerOption
            {
                LoadBalancerOptionId = i,
                Type = LoadBalancerTypes.RoundRobin,
                RouteId = i
            });
        }

        private static void SeedAuthOptions(ModelBuilder modelBuilder, in int i)
        {
            modelBuilder.Entity<AuthenticationOption>().HasData(new AuthenticationOption
            {
                AuthenticationOptionId = i,
                AllowedScopes = new List<string>
                {
                    "ApiOne",
                    "ApiTwo"
                }.ToArray(),
                AuthenticationProviderKey = "TestKey",
                RouteId = i
            });
        }

        private static void SeedRoutes(ModelBuilder modelBuilder, in int i)
        {
            var id = i;
            modelBuilder.Entity<Route>().HasData(new List<Route>
            {
                new Route
                {
                    Enabled = true,
                    RouteId = id,
                    DownstreamScheme = "https",
                    DownstreamPathTemplate = "/{url}",
                    UpstreamPathTemplate = i == 2 ? "/ServiceTwo/{url}" : "/ServiceOne/{url}",
                    UpstreamHttpMethod = new List<string>
                    {
                        "GET",
                        "POST",
                        "PUT",
                        "DELETE"
                    }.ToArray()
                }
            });
        }
    }
}