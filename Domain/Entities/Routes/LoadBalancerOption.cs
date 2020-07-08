using System;
using System.Text.Json.Serialization;
using Domain.Entities.Enums;

namespace Domain.Entities.Routes
{
    [Serializable]
    public class LoadBalancerOption
    {
        [JsonIgnore] public int LoadBalancerOptionId { get; set; }
        public LoadBalancerTypes Type { get; set; }
        // public string Key { get; set; }
        // public int Expiry { get; set; }
        
        [JsonIgnore] public int RouteId { get; set; }
    }
}