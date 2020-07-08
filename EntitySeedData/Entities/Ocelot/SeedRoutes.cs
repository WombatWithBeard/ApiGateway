using System.Collections.Generic;
using Domain.Entities.Routes;

namespace EntitySeedData.Entities.Ocelot
{
    public class SeedRoutes : ISeedData<Route>
    {
        public IEnumerable<Route> Seed()
        {
            var list = new List<Route>();

            for (int i = 10; i < 20; i++)
            {
                list.Add(new Route
                {
                    Enabled = true,
                    DownstreamScheme = $"scheme{i}",
                    DownstreamPathTemplate = $"DownTemplate{i}",
                    UpstreamPathTemplate = $"UpTemplate{i}",
                    RouteId = i
                });
            }

            return list;
        }
    }
}