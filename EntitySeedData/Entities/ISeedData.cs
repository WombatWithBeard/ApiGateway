using System.Collections.Generic;

namespace EntitySeedData.Entities
{
    public interface ISeedData<T>
    {
        IEnumerable<T> Seed();
    }
}