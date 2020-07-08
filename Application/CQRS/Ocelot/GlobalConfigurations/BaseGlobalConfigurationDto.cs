using System.Text.Json.Serialization;

namespace Application.CQRS.Ocelot.GlobalConfigurations
{
    public class BaseGlobalConfigurationDto
    {
        [JsonIgnore] public int GlobalConfigurationId { get; set; }
        public string BaseUrl { get; set; }
    }
}