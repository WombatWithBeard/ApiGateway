using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities.Routes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.CQRS.Ocelot.LoadBalancerOptions.Commands.UpdateLoadBalancerOption
{
    public class UpdateLoadBalancerOptionCommand : BaseLoadBalancerOptionDto, IRequest
    {
        public class Handler : IRequestHandler<UpdateLoadBalancerOptionCommand>
        {
            private readonly IApiGatewayDbContext _context;
            private readonly ILogger<Handler> _logger;

            public Handler(IApiGatewayDbContext context, ILogger<Handler> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<Unit> Handle(UpdateLoadBalancerOptionCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var entity =
                        await _context.LoadBalancerOptions.SingleOrDefaultAsync(
                            r => r.LoadBalancerOptionId == request.LoadBalancerOptionId, cancellationToken);

                    if (entity == null)
                        throw new NotFoundException(nameof(LoadBalancerOption), request.LoadBalancerOptionId);

                    entity.Type = request.Type;
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