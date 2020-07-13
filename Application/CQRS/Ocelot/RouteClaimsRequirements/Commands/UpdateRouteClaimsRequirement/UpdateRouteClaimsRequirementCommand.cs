using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities.Routes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.CQRS.Ocelot.RouteClaimsRequirements.Commands.UpdateRouteClaimsRequirement
{
    public class UpdateRouteClaimsRequirementCommand : BaseRouteClaimsRequirementDto, IRequest
    {
        public class Handler : IRequestHandler<UpdateRouteClaimsRequirementCommand>
        {
            private readonly IApiGatewayDbContext _context;
            private readonly ILogger<Handler> _logger;

            public Handler(IApiGatewayDbContext context, ILogger<Handler> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<Unit> Handle(UpdateRouteClaimsRequirementCommand request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var entity =
                        await _context.RouteClaimsRequirements.SingleOrDefaultAsync(
                            r => r.RouteClaimsRequirementId == request.RouteClaimsRequirementId, cancellationToken);

                    if (entity == null)
                        throw new NotFoundException(nameof(RouteClaimsRequirement), request.RouteClaimsRequirementId);

                    entity.RouteClaimsRequirementId = request.RouteClaimsRequirementId;
                    entity.Role = request.Role;
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