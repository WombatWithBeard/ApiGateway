using System.Text.Json.Serialization;
using Domain.Entities.Routes;

namespace Application.CQRS.Ocelot.DownstreamHostAndPorts
{
    public class BaseDownstreamHostAndPortDto
    {
        [JsonIgnore] public int DownstreamHostAndPortId { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        
        [JsonIgnore] public int RouteId { get; set; }
        [JsonIgnore] public Route Route { get; set; }
    }
}