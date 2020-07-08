using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities.Routes;

namespace Application.CQRS.Ocelot.GlobalConfigurations.Queries.GetGlobalConfigurationsList
{
    public class GlobalConfigurationsListDto : BaseGlobalConfigurationDto, IMapFrom<GlobalConfiguration>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<GlobalConfiguration, GlobalConfigurationsListDto>()
                .ForMember(d => d.GlobalConfigurationId, opt => opt.MapFrom(e => e.GlobalConfigurationId));
        }
    }
}