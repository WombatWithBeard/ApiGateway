using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities.Routes;

namespace Application.CQRS.Routes.Commands.CreateRoutesJsonCommand
{
    public class CreateRoutesJsonDto: BaseRouteDto, IMapFrom<Route>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Route, CreateRoutesJsonDto>()
                .ForMember(d => d.RouteId, opt => opt.MapFrom(e => e.RouteId));
        }
    }
}