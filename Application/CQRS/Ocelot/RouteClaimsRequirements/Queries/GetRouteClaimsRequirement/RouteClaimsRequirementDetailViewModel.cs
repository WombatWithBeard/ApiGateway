using Application.Common.Responses;

namespace Application.CQRS.Ocelot.RouteClaimsRequirements.Queries.GetRouteClaimsRequirement
{
    public class RouteClaimsRequirementDetailViewModel : BaseResponse
    {
        public RouteClaimsRequirementDetailDto Dto { get; set; }
    }
}