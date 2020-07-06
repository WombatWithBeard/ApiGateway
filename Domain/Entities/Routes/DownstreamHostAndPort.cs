using System.Text.Json.Serialization;

namespace Domain.Entities.Routes
{
    public class DownstreamHostAndPort
    {
        [JsonIgnore] public int DownstreamHostAndPortId { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        
        [JsonIgnore] public int RouteId { get; set; }
        [JsonIgnore] public Route Route { get; set; }
    }
}