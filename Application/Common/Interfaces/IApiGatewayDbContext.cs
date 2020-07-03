using Domain.Entities.Routes;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApiGatewayDbContext
    {
        DbSet<Route> Routes { get; set; }
        DbSet<LoadBalancerOption> LoadBalancerOptions { get; set; }
        DbSet<AuthenticationOption> AuthenticationOptions { get; set; }
        DbSet<DownstreamHostAndPort> DownstreamHostAndPorts { get; set; }
        DbSet<GlobalConfiguration> GlobalConfigurations { get; set; }
    }
}