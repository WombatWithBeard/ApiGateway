using Application.Common.Responses;

namespace Application.CQRS.Ocelot.Routes.Queries.GetRoute
{
    public class RouteDetailViewModel : BaseResponse
    {
        public RouteDetailDto Dto { get; set; }
    }
}