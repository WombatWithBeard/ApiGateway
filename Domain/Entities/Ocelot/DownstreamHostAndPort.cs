namespace Domain.Entities.Ocelot
{
    public class DownstreamHostAndPort
    {
        public int DownstreamHostAndPortId { get; set; }
        public int RouteId { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}