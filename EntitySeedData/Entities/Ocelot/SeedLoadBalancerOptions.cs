using System.Collections.Generic;
using Domain.Entities.Enums;
using Domain.Entities.Routes;

namespace EntitySeedData.Entities.Ocelot
{
    public class SeedLoadBalancerOptions : ISeedData<LoadBalancerOption>
    {
        public IEnumerable<LoadBalancerOption> Seed()
        {
            var list = new List<LoadBalancerOption>();

            for (int i = 10; i < 20; i++)
            {
                list.Add(new LoadBalancerOption()
                {
                    Type = LoadBalancerTypes.RoundRobin.ToString(),
                    LoadBalancerOptionId = i,
                    RouteId = i
                });
            }

            return list;
        }
    }
}