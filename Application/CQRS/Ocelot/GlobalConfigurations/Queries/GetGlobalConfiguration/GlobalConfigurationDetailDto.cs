using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities.Routes;

namespace Application.CQRS.Ocelot.GlobalConfigurations.Queries.GetGlobalConfiguration
{
    public class GlobalConfigurationDetailDto : BaseGlobalConfigurationDto, IMapFrom<GlobalConfiguration>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<GlobalConfiguration, GlobalConfigurationDetailDto>()
                .ForMember(d => d.GlobalConfigurationId, opt => opt.MapFrom(e => e.GlobalConfigurationId));
        }
    }
}