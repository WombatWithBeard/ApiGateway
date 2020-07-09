using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities.Routes;

namespace Application.CQRS.Ocelot.Routes.Commands.SaveRoutesJson
{
    public class AuthenticationOptionJsonSaveDto : IMapFrom<AuthenticationOption>
    {
        [JsonIgnore] public int AuthenticationOptionId { get; set; }
        [JsonIgnore] public int RouteId { get; set; }
        public string AuthenticationProviderKey { get; set; }
        public List<string> AllowedScopes { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AuthenticationOption, AuthenticationOptionJsonSaveDto>()
                .ForMember(d => d.AllowedScopes,
                    opt => opt.MapFrom(e => e.AllowedScopes.Select(scope => scope.ScopeName).ToList()));
        }
    }
}