using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities.Routes;
using MediatR;

namespace Application.CQRS.Ocelot.DownstreamHostAndPorts.Commands.CreateDownstreamHostAndPort
{
    public class CreateDownstreamHostAndPortCommand : BaseDownstreamHostAndPortDto, IRequest,
        IMapFrom<CreateDownstreamHostAndPortCommand>
    {
        public class Handler : IRequestHandler<CreateDownstreamHostAndPortCommand>
        {
            private readonly IApiGatewayDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IApiGatewayDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(CreateDownstreamHostAndPortCommand request,
                CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<DownstreamHostAndPort>(request);

                await _context.DownstreamHostAndPorts.AddAsync(entity, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDownstreamHostAndPortCommand, DownstreamHostAndPort>()
                .ForMember(d => d.DownstreamHostAndPortId, opt => opt.MapFrom(e => e.DownstreamHostAndPortId));
        }
    }
}