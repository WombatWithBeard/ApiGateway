﻿using Application.Common.Interfaces;
using Domain.Entities.Routes;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Tools
{
    public class ApiGatewayDbContext : DbContext, IApiGatewayDbContext
    {
        public DbSet<Route> Routes { get; set; }
        public DbSet<LoadBalancerOption> LoadBalancerOptions { get; set; }
        public DbSet<AuthenticationOption> AuthenticationOptions { get; set; }
        public DbSet<DownstreamHostAndPort> DownstreamHostAndPorts { get; set; }
        public DbSet<GlobalConfiguration> GlobalConfigurations { get; set; }
        public DbSet<RouteClaimsRequirement> RouteClaimsRequirements { get; set; }

        public ApiGatewayDbContext(DbContextOptions<ApiGatewayDbContext> options) : base(options)
        {
        }

        protected ApiGatewayDbContext()
        {
            //dotnet ef migrations add
            //dotnet ef database update
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            TestSeeder.Seed(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiGatewayDbContext).Assembly);
        }
    }
}