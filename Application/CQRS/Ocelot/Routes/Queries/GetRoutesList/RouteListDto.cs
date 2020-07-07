using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities.Routes;

namespace Application.CQRS.Ocelot.Routes.Queries.GetRoutesList
{
    public class RouteListDto : BaseRouteDto, IMapFrom<Route>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Route, RouteListDto>()
                .ForMember(d => d.RouteId, opt => opt.MapFrom(e => e.RouteId));
        }
    }
}