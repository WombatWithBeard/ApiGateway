using System.Text.Json.Serialization;

namespace Domain.Entities.Routes
{
    public class RouteClaimsRequirement
    {
        [JsonIgnore] public int RouteClaimsRequirementId { get; set; }
        [JsonIgnore] public int RouteId { get; set; }

        public string Role { get; set; }
        //TODO: UserType ??? Another claims check
        //TODO: also need to make auto fetch from authDB
    }
}