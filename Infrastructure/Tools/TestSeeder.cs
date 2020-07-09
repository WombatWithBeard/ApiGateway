using System.Collections.Generic;
using Domain.Entities.Common;
using Domain.Entities.Enums;
using Domain.Entities.Routes;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Tools
{
    public class TestSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            SeedRoutes(modelBuilder);
            SeedAuthOptions(modelBuilder);
            SeedLoadBalancer(modelBuilder);
            SeedDownstreamHostAndPort(modelBuilder);

            SeedScopes(modelBuilder);
            SeedHttpMethods(modelBuilder);

            SeedGlobalConfig(modelBuilder);
        }

        private static void SeedHttpMethods(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UpstreamHttpsMethod>()
                .HasData(new UpstreamHttpsMethod {Id = 1, RouteId = 1, Name = "Get"});            
            modelBuilder.Entity<UpstreamHttpsMethod>()
                .HasData(new UpstreamHttpsMethod {Id = 2, RouteId = 1, Name = "Post"});            
            modelBuilder.Entity<UpstreamHttpsMethod>()
                .HasData(new UpstreamHttpsMethod {Id = 3, RouteId = 1, Name = "Put"});            
            modelBuilder.Entity<UpstreamHttpsMethod>()
                .HasData(new UpstreamHttpsMethod {Id = 4, RouteId = 1, Name = "Delete"});            
            modelBuilder.Entity<UpstreamHttpsMethod>()
                .HasData(new UpstreamHttpsMethod {Id = 5, RouteId = 2, Name = "Get"});
            
        }

        private static void SeedScopes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Scope>().HasData(new Scope
                {ScopeId = 1, AuthenticationOptionId = 1, ExternalId = 1, ScopeName = "ApiOne"});            
            modelBuilder.Entity<Scope>().HasData(new Scope
                {ScopeId = 2, AuthenticationOptionId = 1, ExternalId = 2, ScopeName = "ApiTwo"});            
            modelBuilder.Entity<Scope>().HasData(new Scope
                {ScopeId = 3, AuthenticationOptionId = 2, ExternalId = 1, ScopeName = "ApiOne"});
        }

        private static void SeedGlobalConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GlobalConfiguration>().HasData(new GlobalConfiguration
                {GlobalConfigurationId = 1, BaseUrl = "https://localhost:6900"});
        }

        private static void SeedDownstreamHostAndPort(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DownstreamHostAndPort>().HasData(new DownstreamHostAndPort
            {
                Host = "localhost",
                Port = 3001,
                DownstreamHostAndPortId = 1,
                RouteId = 1
            });            
            modelBuilder.Entity<DownstreamHostAndPort>().HasData(new DownstreamHostAndPort
            {
                Host = "localhost",
                Port = 3010,
                DownstreamHostAndPortId = 2,
                RouteId = 1
            });            
            modelBuilder.Entity<DownstreamHostAndPort>().HasData(new DownstreamHostAndPort
            {
                Host = "localhost",
                Port = 4003,
                DownstreamHostAndPortId = 3,
                RouteId = 2
            });
        }

        private static void SeedLoadBalancer(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoadBalancerOption>().HasData(new LoadBalancerOption
            {
                LoadBalancerOptionId = 1,
                Type = LoadBalancerTypes.RoundRobin.ToString(),
                RouteId = 1
            });            
            modelBuilder.Entity<LoadBalancerOption>().HasData(new LoadBalancerOption
            {
                LoadBalancerOptionId = 2,
                Type = LoadBalancerTypes.RoundRobin.ToString(),
                RouteId = 2
            });
        }

        private static void SeedAuthOptions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthenticationOption>().HasData(new AuthenticationOption
            {
                AuthenticationOptionId = 1,
                AuthenticationProviderKey = "TestKey",
                RouteId = 1
            });            
            modelBuilder.Entity<AuthenticationOption>().HasData(new AuthenticationOption
            {
                AuthenticationOptionId = 2,
                AuthenticationProviderKey = "TestKey",
                RouteId = 2
            });
        }

        private static void SeedRoutes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Route>().HasData(new List<Route>
            {
                new Route
                {
                    Enabled = true,
                    RouteId = 1,
                    DownstreamScheme = "https",
                    DownstreamPathTemplate = "/{url}",
                    UpstreamPathTemplate = "/ServiceOne/{url}"
                }
            });            
            modelBuilder.Entity<Route>().HasData(new List<Route>
            {
                new Route
                {
                    Enabled = true,
                    RouteId = 2,
                    DownstreamScheme = "https",
                    DownstreamPathTemplate = "/{url}",
                    UpstreamPathTemplate = "/ServiceTwo/{url}"
                }
            });
        }
    }
}