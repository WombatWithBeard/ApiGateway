using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities.Routes;

namespace Application.CQRS.Ocelot.LoadBalancerOptions.Queries.GetLoadBalancerOptionsList
{
    public class LoadBalancerOptionsListDto : BaseLoadBalancerOptionDto, IMapFrom<LoadBalancerOption>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoadBalancerOption, LoadBalancerOptionsListDto>()
                .ForMember(d => d.LoadBalancerOptionId, opt => opt.MapFrom(e => e.LoadBalancerOptionId));
        }
    }
}