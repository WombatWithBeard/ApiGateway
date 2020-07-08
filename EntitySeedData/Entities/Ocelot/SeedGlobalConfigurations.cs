using System.Collections.Generic;
using Domain.Entities.Routes;

namespace EntitySeedData.Entities.Ocelot
{
    public class SeedGlobalConfigurations : ISeedData<GlobalConfiguration>
    {
        public IEnumerable<GlobalConfiguration> Seed()
        {
            var list = new List<GlobalConfiguration>();

            for (int i = 10; i < 20; i++)
            {
                list.Add(new GlobalConfiguration()
                {
                    BaseUrl = $"BaseUrl{i}",
                    GlobalConfigurationId = i
                });
            }

            return list;
        }
    }
}