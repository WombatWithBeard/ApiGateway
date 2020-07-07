using System.Collections.Generic;
using Application.Common.Responses;

namespace Application.CQRS.Ocelot.DownstreamHostAndPorts.Queries.GetDownstreamHostAndPortsList
{
    public class DownstreamHostAndPortsListViewModel : BaseResponse
    {
        public List<DownstreamHostAndPortsListDto> ListDtos { get; set; }
    }
}