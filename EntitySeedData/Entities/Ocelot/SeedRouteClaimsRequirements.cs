using System.Collections.Generic;
using Domain.Entities.Routes;

namespace EntitySeedData.Entities.Ocelot
{
    public class SeedRouteClaimsRequirements : ISeedData<RouteClaimsRequirement>
    {
        public IEnumerable<RouteClaimsRequirement> Seed()
        {
            var list = new List<RouteClaimsRequirement>();

            for (int i = 10; i < 20; i++)
            {
                list.Add(new RouteClaimsRequirement()
                {
                    RouteClaimsRequirementId = i,
                    Role = "Admin",
                    RouteId = i
                });
            }

            return list;
        }
    }
}