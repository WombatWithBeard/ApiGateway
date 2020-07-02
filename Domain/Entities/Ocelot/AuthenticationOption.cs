using System.Collections.Generic;

namespace Domain.Entities.Ocelot
{
    public class AuthenticationOption
    {
        public string AuthenticationOptionId { get; set; }
        public int RouteId { get; set; }
        public string AuthenticationProviderKey { get; set; }
        public List<string> AllowedScopes { get; set; }
    }
}