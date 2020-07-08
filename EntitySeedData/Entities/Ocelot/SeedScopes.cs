using System.Collections.Generic;
using Domain.Entities.Common;

namespace EntitySeedData.Entities.Ocelot
{
    public class SeedScopes : ISeedData<Scope>
    {
        public IEnumerable<Scope> Seed()
        {
            var list = new List<Scope>();

            for (int i = 10; i < 20; i++)
            {
                list.Add(new Scope
                {
                    ScopeId = i,
                    ExternalId = i,
                    AuthenticationOptionId = i,
                    ScopeName = $"Scope{i}"
                });
            }

            return list;
        }
    }
}