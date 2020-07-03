using System.ComponentModel.DataAnnotations.Schema;
using Domain.Entities.Enums;

namespace Domain.Entities.Routes
{
    public class LoadBalancerOption
    {
        public int LoadBalancerOptionId { get; set; }
        public LoadBalancerTypes Type { get; set; }
        // public string Key { get; set; }
        // public int Expiry { get; set; }
        
        [ForeignKey(nameof(Route))]
        public int RouteId { get; set; }
    }
}