using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities.Routes;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.CQRS.Ocelot.Routes.Commands.CreateRoute
{
    public class CreateRouteCommand : BaseRouteDto, IRequest, IMapFrom<CreateRouteCommand>
    {
        public class Handler : IRequestHandler<CreateRouteCommand>
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

            public async Task<Unit> Handle(CreateRouteCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var entity = _mapper.Map<Route>(request);

                    await _context.Routes.AddAsync(entity, cancellationToken);

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
            profile.CreateMap<CreateRouteCommand, Route>()
                .ForMember(d => d.RouteId, opt => opt.MapFrom(e => e.RouteId));
        }
    }
}