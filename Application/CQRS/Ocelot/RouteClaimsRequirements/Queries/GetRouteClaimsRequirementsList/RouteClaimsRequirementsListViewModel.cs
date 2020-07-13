using System.Collections.Generic;
using Application.Common.Responses;

namespace Application.CQRS.Ocelot.RouteClaimsRequirements.Queries.GetRouteClaimsRequirementsList
{
    public class RouteClaimsRequirementsListViewModel : BaseResponse
    {
        public List<RouteClaimsRequirementsListDto> ListDtos { get; set; }
    }
}