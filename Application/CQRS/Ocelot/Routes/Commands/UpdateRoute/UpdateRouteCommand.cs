using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities.Routes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.CQRS.Ocelot.Routes.Commands.UpdateRoute
{
    public class UpdateRouteCommand : BaseRouteDto, IRequest
    {
        public class Handler : IRequestHandler<UpdateRouteCommand>
        {
            private readonly IApiGatewayDbContext _context;
            private readonly ILogger<Handler> _logger;

            public Handler(IApiGatewayDbContext context, ILogger<Handler> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<Unit> Handle(UpdateRouteCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var entity =
                        await _context.Routes.SingleOrDefaultAsync(r => r.RouteId == request.RouteId,
                            cancellationToken);

                    if (entity == null)
                        throw new NotFoundException(nameof(Route), request.RouteId);

                    entity.Enabled = request.Enabled;
                    entity.DownstreamScheme = request.DownstreamScheme;
                    entity.DownstreamPathTemplate = request.DownstreamPathTemplate;
                    entity.UpstreamHttpMethod = request.UpstreamHttpMethod;
                    entity.UpstreamPathTemplate = request.UpstreamPathTemplate;
                    entity.Priority = request.Priority;

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