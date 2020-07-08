using Application.Common.Responses;

namespace Application.CQRS.Ocelot.LoadBalancerOptions.Queries.GetLoadBalancerOption
{
    public class LoadBalancerOptionDetailViewModel : BaseResponse
    {
        public LoadBalancerOptionDetailDto Dto { get; set; }
    }
}