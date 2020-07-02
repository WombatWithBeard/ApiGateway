namespace Domain.Entities.Enums
{
    public enum LoadBalancerTypes
    {
        LeastConnection,
        RoundRobin,
        NoLoadBalancer,
        CookieStickySessions
    }
}