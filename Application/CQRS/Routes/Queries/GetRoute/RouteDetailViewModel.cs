using Application.Common.Responses;

namespace Application.CQRS.Routes.Queries.GetRoute
{
    public class RouteDetailViewModel : BaseResponse
    {
        public RouteDetailDto Dto { get; set; }
    }
}