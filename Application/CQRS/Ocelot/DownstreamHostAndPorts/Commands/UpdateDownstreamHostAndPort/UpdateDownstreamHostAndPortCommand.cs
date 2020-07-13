using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities.Routes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.CQRS.Ocelot.DownstreamHostAndPorts.Commands.UpdateDownstreamHostAndPort
{
    public class UpdateDownstreamHostAndPortCommand : BaseDownstreamHostAndPortDto, IRequest
    {
        public class Handler : IRequestHandler<UpdateDownstreamHostAndPortCommand>
        {
            private readonly IApiGatewayDbContext _context;
            private readonly ILogger<Handler> _logger;

            public Handler(IApiGatewayDbContext context, ILogger<Handler> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<Unit> Handle(UpdateDownstreamHostAndPortCommand request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var entity =
                        await _context.DownstreamHostAndPorts.SingleOrDefaultAsync(
                            r => r.DownstreamHostAndPortId == request.DownstreamHostAndPortId, cancellationToken);

                    if (entity == null)
                    {
                        throw new NotFoundException(nameof(DownstreamHostAndPort), request.DownstreamHostAndPortId);
                    }

                    entity.Host = request.Host;
                    entity.Port = request.Port;
                    entity.RouteId = request.RouteId;

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
    }
}