using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Routes
{
    public class DownstreamHostAndPort
    {
        public int DownstreamHostAndPortId { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        
        [ForeignKey(nameof(Route))]
        public int RouteId { get; set; }
    }
}