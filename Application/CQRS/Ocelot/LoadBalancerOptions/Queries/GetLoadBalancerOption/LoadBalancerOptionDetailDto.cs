using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities.Routes;

namespace Application.CQRS.Ocelot.LoadBalancerOptions.Queries.GetLoadBalancerOption
{
    public class LoadBalancerOptionDetailDto : BaseLoadBalancerOptionDto, IMapFrom<LoadBalancerOption>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoadBalancerOption, LoadBalancerOptionDetailDto>()
                .ForMember(d => d.LoadBalancerOptionId, opt => opt.MapFrom(e => e.LoadBalancerOptionId));
        }
    }
}