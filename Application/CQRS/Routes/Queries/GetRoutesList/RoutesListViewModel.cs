using System.Collections.Generic;
using Application.Common.Responses;

namespace Application.CQRS.Routes.Queries.GetRoutesList
{
    public class RoutesListViewModel : BaseResponse
    {
        public List<RouteListDto> ListDtos { get; set; }
    }
}