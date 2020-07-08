using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities.Routes;
using MediatR;

namespace Application.CQRS.Ocelot.GlobalConfigurations.Commands.CreateGlobalConfiguration
{
    public class CreateGlobalConfigurationCommand : BaseGlobalConfigurationDto, IRequest,
        IMapFrom<CreateGlobalConfigurationCommand>
    {
        public class Handler : IRequestHandler<CreateGlobalConfigurationCommand>
        {
            private readonly IApiGatewayDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IApiGatewayDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(CreateGlobalConfigurationCommand request,
                CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<GlobalConfiguration>(request);

                await _context.GlobalConfigurations.AddAsync(entity, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateGlobalConfigurationCommand, GlobalConfiguration>()
                .ForMember(d => d.GlobalConfigurationId, opt => opt.MapFrom(e => e.GlobalConfigurationId));
        }
    }
}