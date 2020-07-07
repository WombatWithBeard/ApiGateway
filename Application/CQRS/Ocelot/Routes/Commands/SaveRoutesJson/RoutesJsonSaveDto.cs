using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities.Routes;

namespace Application.CQRS.Ocelot.Routes.Commands.SaveRoutesJson
{
    public class RoutesJsonSaveDto : BaseRouteDto, IMapFrom<Route>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Route, RoutesJsonSaveDto>()
                .ForMember(d => d.RouteId, opt => opt.MapFrom(e => e.RouteId));
        }
    }
}