using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities.Routes;

namespace Application.CQRS.Ocelot.DownstreamHostAndPorts.Queries.GetDownstreamHostAndPortsList
{
    public class DownstreamHostAndPortsListDto: BaseDownstreamHostAndPortDto, IMapFrom<DownstreamHostAndPort>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<DownstreamHostAndPort, DownstreamHostAndPortsListDto>()
                .ForMember(d => d.DownstreamHostAndPortId, opt => opt.MapFrom(e => e.DownstreamHostAndPortId));
        }
    }
}