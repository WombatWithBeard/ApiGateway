namespace Application.CQRS.Ocelot.DownstreamHostAndPorts
{
    public class BaseDownstreamHostAndPortDto
    {
        public int DownstreamHostAndPortId { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        
        public int RouteId { get; set; }
    }
}