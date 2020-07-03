using Application.Common.Interfaces;
using Domain.Entities.Routes;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Tools
{
    public class ApiGetwayDbContext : DbContext, IApiGatewayDbContext
    {
        public DbSet<Route> Routes { get; set; }
        public DbSet<LoadBalancerOption> LoadBalancerOptions { get; set; }
        public DbSet<AuthenticationOption> AuthenticationOptions { get; set; }
        public DbSet<DownstreamHostAndPort> DownstreamHostAndPorts { get; set; }
        public DbSet<GlobalConfiguration> GlobalConfigurations { get; set; }

        public ApiGetwayDbContext(DbContextOptions<ApiGetwayDbContext> options) : base(options)
        {
        }

        protected ApiGetwayDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiGetwayDbContext).Assembly);
        }
    }
}