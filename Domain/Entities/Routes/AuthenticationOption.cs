using System.Text.Json.Serialization;

namespace Domain.Entities.Routes
{
    public class AuthenticationOption
    {
        [JsonIgnore] public int AuthenticationOptionId { get; set; }
        public string AuthenticationProviderKey { get; set; }
        public string[] AllowedScopes { get; set; }
        
        [JsonIgnore] public int RouteId { get; set; }
        
        [JsonIgnore] public Route Route { get; set; }
    }
}