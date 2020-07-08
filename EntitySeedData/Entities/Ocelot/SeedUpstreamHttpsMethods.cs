using System.Collections.Generic;
using Domain.Entities.Common;

namespace EntitySeedData.Entities.Ocelot
{
    public class SeedUpstreamHttpsMethods : ISeedData<UpstreamHttpsMethod>
    {
        public IEnumerable<UpstreamHttpsMethod> Seed()
        {
            var list = new List<UpstreamHttpsMethod>();

            for (int i = 10; i < 20; i++)
            {
                list.Add(new UpstreamHttpsMethod
                {
                    Id = i,
                    RouteId = i,
                    Name = $"Method{i}"
                });
            }

            return list;
        }
    }
}