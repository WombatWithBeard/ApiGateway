using System.Text.Json.Serialization;

namespace Domain.Entities.Routes
{
    public class GlobalConfiguration
    {
        [JsonIgnore] public int GlobalConfigurationId { get; set; }
        public string BaseUrl { get; set; }
    }
}