using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities.Routes;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.CQRS.Ocelot.DownstreamHostAndPorts.Commands.CreateDownstreamHostAndPort
{
    public class CreateDownstreamHostAndPortCommand : BaseDownstreamHostAndPortDto, IRequest,
        IMapFrom<CreateDownstreamHostAndPortCommand>
    {
        public class Handler : IRequestHandler<CreateDownstreamHostAndPortCommand>
        {
            private readonly IApiGatewayDbContext _context;
            private readonly IMapper _mapper;
            private readonly ILogger<Handler> _logger;

            public Handler(IApiGatewayDbContext context, IMapper mapper, ILogger<Handler> logger)
            {
                _context = context;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<Unit> Handle(CreateDownstreamHostAndPortCommand request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var entity = _mapper.Map<DownstreamHostAndPort>(request);

                    await _context.DownstreamHostAndPorts.AddAsync(entity, cancellationToken);

                    await _context.SaveChangesAsync(cancellationToken);

                    return Unit.Value;
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                    throw;
                }
            }
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDownstreamHostAndPortCommand, DownstreamHostAndPort>()
                .ForMember(d => d.DownstreamHostAndPortId, opt => opt.MapFrom(e => e.DownstreamHostAndPortId));
        }
    }
}