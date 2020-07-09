using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities.Routes;

namespace Application.CQRS.Ocelot.Routes.Commands.SaveRoutesJson
{
    public class RoutesJsonSaveDto : IMapFrom<Route>
    {
        [JsonIgnore] public int RouteId { get; set; }
        [JsonIgnore] public bool Enabled { get; set; }
        public string DownstreamPathTemplate { get; set; }
        public string DownstreamScheme { get; set; }
        public ICollection<DownstreamHostAndPort> DownstreamHostAndPorts { get; set; }
        public string UpstreamPathTemplate { get; set; }
        public List<string> UpstreamHttpMethod { get; set; }
        public AuthenticationOptionJsonSaveDto AuthenticationOptions { get; set; }
        public LoadBalancerOption LoadBalancerOptions { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Route, RoutesJsonSaveDto>()
                .ForMember(d => d.RouteId, opt => opt.MapFrom(e => e.RouteId));
            profile.CreateMap<Route, RoutesJsonSaveDto>()
                .ForMember(d => d.UpstreamHttpMethod,
                    opt => opt.MapFrom(e => e.UpstreamHttpMethod.Select(method => method.Name).ToList()));
        }
    }
}