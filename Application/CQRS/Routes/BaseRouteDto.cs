using System.Collections.Generic;
using System.Net.Http;
using Domain.Entities.Routes;

namespace Application.CQRS.Routes
{
    public class BaseRouteDto
    {
        public int RouteId { get; set; }
        public bool Enabled { get; set; }
        public string DownstreamPathTemplate { get; set; }
        public string DownstreamScheme { get; set; }
        public List<DownstreamHostAndPort> DownstreamHostAndPorts { get; set; }
        public LoadBalancerOption LoadBalancerOptions { get; set; }
        public string UpstreamPathTemplate { get; set; }
        public List<HttpMethod> UpstreamHttpMethod { get; set; }
        public AuthenticationOption AuthenticationOptions { get; set; }
    }
}