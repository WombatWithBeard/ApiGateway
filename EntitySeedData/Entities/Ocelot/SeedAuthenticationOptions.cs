using System.Collections.Generic;
using Domain.Entities.Routes;

namespace EntitySeedData.Entities.Ocelot
{
    public class SeedAuthenticationOptions : ISeedData<AuthenticationOption>
    {
        public IEnumerable<AuthenticationOption> Seed()
        {
            var list = new List<AuthenticationOption>();

            for (int i = 10; i < 20; i++)
            {
                list.Add(new AuthenticationOption
                {
                    AuthenticationOptionId = i,
                    AuthenticationProviderKey = $"key{i}",
                    RouteId = i
                });
            }

            return list;
        }
    }
}