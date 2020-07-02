using Domain.Entities.Enums;

namespace Domain.Entities.Ocelot
{
    public class LoadBalancerOption
    {
        public int LoadBalancerOptionId { get; set; }
        public int RouteId { get; set; }
        public LoadBalancerTypes Type { get; set; }
        // public string Key { get; set; }
        // public int Expiry { get; set; }
    }
}