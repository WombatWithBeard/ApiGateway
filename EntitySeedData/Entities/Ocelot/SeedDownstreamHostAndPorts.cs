using System.Collections.Generic;
using Domain.Entities.Routes;

namespace EntitySeedData.Entities.Ocelot
{
    public class SeedDownstreamHostAndPorts : ISeedData<DownstreamHostAndPort>
    {
        public IEnumerable<DownstreamHostAndPort> Seed()
        {
            var list = new List<DownstreamHostAndPort>();

            for (int i = 10; i < 20; i++)
            {
                list.Add(new DownstreamHostAndPort
                {
                    Host = $"host{i}",
                    Port = i,
                    DownstreamHostAndPortId = i,
                    RouteId = i
                });
            }

            return list;
        }
    }
}