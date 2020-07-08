using Application.Common.Interfaces;
using Infrastructure.Tools.Consts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Tools
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service,
            IConfiguration configuration)
        {
            service.AddDbContext<ApiGatewayDbContext>(builder =>
                builder.UseNpgsql(configuration.GetConnectionString(ConnectionConsts.ApiGatewayConnectionString),
                    b =>
                    {
                        b.MigrationsAssembly("ApiGateway");
                        b.SetPostgresVersion(9,6);
                    }));

            service.AddScoped<IApiGatewayDbContext>(provider => provider.GetService<ApiGatewayDbContext>());

            return service;
        }
    }
}