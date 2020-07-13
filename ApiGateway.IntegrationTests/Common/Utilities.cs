using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EntitySeedData.Entities.Ocelot;
using Infrastructure.Tools;
using Newtonsoft.Json;

namespace ApiGateway.IntegrationTests.Common
{
    public class Utilities
    {
        public static StringContent GetRequestContent(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }

        public static async Task<T> GetResponseContent<T>(HttpResponseMessage response)
        {
            var stringResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(stringResponse);

            return result;
        }

        public static void InitializeDbForTests(ApiGatewayDbContext context)
        {
            context.Routes.AddRange(new SeedRoutes().Seed());
            context.AuthenticationOptions.AddRange(new SeedAuthenticationOptions().Seed());
            context.GlobalConfigurations.AddRange(new SeedGlobalConfigurations().Seed());
            context.LoadBalancerOptions.AddRange(new SeedLoadBalancerOptions().Seed());
            context.DownstreamHostAndPorts.AddRange(new SeedDownstreamHostAndPorts().Seed());
            context.RouteClaimsRequirements.AddRange(new SeedRouteClaimsRequirements().Seed());

            context.SaveChanges();
        }
    }
}