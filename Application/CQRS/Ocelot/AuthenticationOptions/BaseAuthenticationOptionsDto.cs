using System.Collections.Generic;
using Domain.Entities.Common;
using Domain.Entities.Routes;

namespace Application.CQRS.Ocelot.AuthenticationOptions
{
    public class BaseAuthenticationOptionsDto
    {
  
        public int AuthenticationOptionId { get; set; }
        public string AuthenticationProviderKey { get; set; }
        public List<Scope> AllowedScopes { get; set; }
        
        public int RouteId { get; set; }
    }
}