using Domain.Entities.Enums;
using Domain.Entities.Routes;

namespace Application.CQRS.Ocelot.LoadBalancerOptions
{
    public class BaseLoadBalancerOptionDto
    {
        public int LoadBalancerOptionId { get; set; }
        public LoadBalancerTypes Type { get; set; }

        public int RouteId { get; set; }
    }
}