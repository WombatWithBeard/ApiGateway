using System.Collections.Generic;
using Application.Common.Responses;

namespace Application.CQRS.Ocelot.GlobalConfigurations.Queries.GetGlobalConfigurationsList
{
    public class GlobalConfigurationsListViewModel : BaseResponse
    {
        public List<GlobalConfigurationsListDto> ListDtos { get; set; }
    }
}