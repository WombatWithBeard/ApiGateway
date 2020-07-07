using Application.Common.Responses;

namespace Application.CQRS.Ocelot.DownstreamHostAndPorts.Queries.GetDownstreamHostAndPort
{
    public class DownstreamHostAndPortDetailViewModel : BaseResponse
    {
        public DownstreamHostAndPortDetailDto Dto { get; set; }
    }
}