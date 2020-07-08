using System.Collections.Generic;
using System.Text.Json.Serialization;
using Domain.Entities.Common;

namespace Domain.Entities.Routes
{
    public class AuthenticationOption
    {
        public AuthenticationOption()
        {
            AllowedScopes = new HashSet<Scope>();
        }

        [JsonIgnore] public int AuthenticationOptionId { get; set; }
        public string AuthenticationProviderKey { get; set; }
        public ICollection<Scope> AllowedScopes { get; set; }
        
        [JsonIgnore] public int RouteId { get; set; }
    }
}