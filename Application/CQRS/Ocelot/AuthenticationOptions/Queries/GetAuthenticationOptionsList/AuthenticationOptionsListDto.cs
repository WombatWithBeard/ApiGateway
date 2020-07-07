using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities.Routes;

namespace Application.CQRS.Ocelot.AuthenticationOptions.Queries.GetAuthenticationOptionsList
{
    public class AuthenticationOptionsListDto : BaseAuthenticationOptionsDto, IMapFrom<AuthenticationOption>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AuthenticationOption, AuthenticationOptionsListDto>()
                .ForMember(d => d.AuthenticationOptionId, opt => opt.MapFrom(e => e.AuthenticationOptionId));
        }
    }
}