using System;
using System.Text.Json.Serialization;

namespace Domain.Entities.Routes
{
    [Serializable]
    public class LoadBalancerOption
    {
        [JsonIgnore] public int LoadBalancerOptionId { get; set; }

        public string Type { get; set; }
        // public string Key { get; set; }
        // public int Expiry { get; set; }

        [JsonIgnore] public int RouteId { get; set; }
    }
}