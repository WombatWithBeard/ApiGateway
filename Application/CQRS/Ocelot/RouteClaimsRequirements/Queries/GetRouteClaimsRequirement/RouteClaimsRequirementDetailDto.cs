using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities.Routes;

namespace Application.CQRS.Ocelot.RouteClaimsRequirements.Queries.GetRouteClaimsRequirement
{
    public class RouteClaimsRequirementDetailDto : BaseRouteClaimsRequirementDto, IMapFrom<RouteClaimsRequirement>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<RouteClaimsRequirement, RouteClaimsRequirementDetailDto>()
                .ForMember(d => d.RouteClaimsRequirementId, opt => opt.MapFrom(e => e.RouteClaimsRequirementId));
        }
    }
}