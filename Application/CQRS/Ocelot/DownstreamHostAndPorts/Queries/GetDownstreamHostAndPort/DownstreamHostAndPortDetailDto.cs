using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities.Routes;

namespace Application.CQRS.Ocelot.DownstreamHostAndPorts.Queries.GetDownstreamHostAndPort
{
    public class DownstreamHostAndPortDetailDto : BaseDownstreamHostAndPortDto, IMapFrom<DownstreamHostAndPort>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<DownstreamHostAndPort, DownstreamHostAndPortDetailDto>()
                .ForMember(d => d.DownstreamHostAndPortId, opt => opt.MapFrom(e => e.DownstreamHostAndPortId));
        }
    }
}