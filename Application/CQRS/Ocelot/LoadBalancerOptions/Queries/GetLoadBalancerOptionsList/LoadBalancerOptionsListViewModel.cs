using System.Collections.Generic;
using Application.Common.Responses;

namespace Application.CQRS.Ocelot.LoadBalancerOptions.Queries.GetLoadBalancerOptionsList
{
    public class LoadBalancerOptionsListViewModel : BaseResponse
    {
        public List<LoadBalancerOptionsListDto> ListDtos { get; set; }
    }
}