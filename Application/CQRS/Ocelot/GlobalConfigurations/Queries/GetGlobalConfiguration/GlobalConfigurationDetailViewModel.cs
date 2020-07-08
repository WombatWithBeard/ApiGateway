using Application.Common.Responses;

namespace Application.CQRS.Ocelot.GlobalConfigurations.Queries.GetGlobalConfiguration
{
    public class GlobalConfigurationDetailViewModel : BaseResponse
    {
        public GlobalConfigurationDetailDto Dto { get; set; }
    }
}