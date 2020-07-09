namespace Application.CQRS.Ocelot.LoadBalancerOptions
{
    public class BaseLoadBalancerOptionDto
    {
        public int LoadBalancerOptionId { get; set; }
        public string Type { get; set; }

        public int RouteId { get; set; }
    }
}