using System.Text.Json.Serialization;

namespace Application.CQRS.Ocelot.RouteClaimsRequirements
{
    public class BaseRouteClaimsRequirementDto
    {
        [JsonIgnore] public int RouteClaimsRequirementId { get; set; }
        [JsonIgnore] public int RouteId { get; set; }

        public string Role { get; set; }
    }
}