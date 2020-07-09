using System.Collections.Generic;
using System.Text.Json.Serialization;
using Domain.Entities.Common;
using Domain.Entities.Routes;

namespace Application.CQRS.Ocelot.Routes
{
    public class BaseRouteDto
    {
        public BaseRouteDto()
        {
            DownstreamHostAndPorts = new HashSet<DownstreamHostAndPort>();
            UpstreamHttpMethod = new HashSet<UpstreamHttpsMethod>();
        }

        [JsonIgnore] public int RouteId { get; set; }
        [JsonIgnore] public bool Enabled { get; set; }
        public string DownstreamPathTemplate { get; set; }
        public string DownstreamScheme { get; set; }
        public ICollection<DownstreamHostAndPort> DownstreamHostAndPorts { get; set; }
        public string UpstreamPathTemplate { get; set; }
        public ICollection<UpstreamHttpsMethod> UpstreamHttpMethod { get; set; }
        public AuthenticationOption AuthenticationOptions { get; set; }
        public LoadBalancerOption LoadBalancerOptions { get; set; }
        public int Priority { get; set; }
    }
}