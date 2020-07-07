using Domain.Entities.Routes;

namespace Application.CQRS.Ocelot.AuthenticationOptions
{
    public class BaseAuthenticationOptionsDto
    {
        public int AuthenticationOptionId { get; set; }
        public string AuthenticationProviderKey { get; set; }
        public string[] AllowedScopes { get; set; }
        
        public int RouteId { get; set; }
        
        public Route Route { get; set; }
    }
}