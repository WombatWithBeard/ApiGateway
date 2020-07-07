using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities.Routes;

namespace Application.CQRS.Ocelot.Routes.Queries.GetRoute
{
    public class RouteDetailDto : BaseRouteDto, IMapFrom<Route>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Route, RouteDetailDto>()
                .ForMember(d => d.RouteId, opt => opt.MapFrom(e => e.RouteId));
        }
    }
}