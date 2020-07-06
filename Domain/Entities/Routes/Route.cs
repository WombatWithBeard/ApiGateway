using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.Entities.Routes
{
    public class Route
    {
        [JsonIgnore] public int RouteId { get; set; }
        [JsonIgnore] public bool Enabled { get; set; }
        public string DownstreamPathTemplate { get; set; }
        public string DownstreamScheme { get; set; }
        public List<DownstreamHostAndPort> DownstreamHostAndPorts { get; set; }
        public string UpstreamPathTemplate { get; set; }
        public string[] UpstreamHttpMethod { get; set; }
        public AuthenticationOption AuthenticationOptions { get; set; }
        public LoadBalancerOption LoadBalancerOptions { get; set; }
    }
}