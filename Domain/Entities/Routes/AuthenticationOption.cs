using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Routes
{
    public class AuthenticationOption
    {
        public string AuthenticationOptionId { get; set; }
        public string AuthenticationProviderKey { get; set; }
        public List<string> AllowedScopes { get; set; }
        
        [ForeignKey(nameof(Route))]
        public int RouteId { get; set; }
    }
}