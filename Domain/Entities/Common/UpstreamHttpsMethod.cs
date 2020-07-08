using System.Text.Json.Serialization;
using Domain.Entities.Routes;

namespace Domain.Entities.Common
{
    public class UpstreamHttpsMethod
    {
        [JsonIgnore] public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore] public int RouteId { get; set; }
    }
}