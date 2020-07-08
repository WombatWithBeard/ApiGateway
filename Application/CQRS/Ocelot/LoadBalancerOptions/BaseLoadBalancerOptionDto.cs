using System.Text.Json.Serialization;
using Domain.Entities.Enums;
using Domain.Entities.Routes;

namespace Application.CQRS.Ocelot.LoadBalancerOptions
{
    public class BaseLoadBalancerOptionDto
    {
        [JsonIgnore] public int LoadBalancerOptionId { get; set; }
        public LoadBalancerTypes Type { get; set; }

        [JsonIgnore] public int RouteId { get; set; }
        
        [JsonIgnore] public Route Route { get; set; }
    }
}