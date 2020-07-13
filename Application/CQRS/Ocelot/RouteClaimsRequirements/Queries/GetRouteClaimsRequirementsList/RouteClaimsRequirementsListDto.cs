using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities.Routes;

namespace Application.CQRS.Ocelot.RouteClaimsRequirements.Queries.GetRouteClaimsRequirementsList
{
    public class RouteClaimsRequirementsListDto : BaseRouteClaimsRequirementDto, IMapFrom<RouteClaimsRequirement>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<RouteClaimsRequirement, RouteClaimsRequirementsListDto>()
                .ForMember(d => d.RouteClaimsRequirementId, opt => opt.MapFrom(e => e.RouteClaimsRequirementId));
        }
    }
}