using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities.Routes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Ocelot.LoadBalancerOptions.Commands.UpdateLoadBalancerOption
{
    public class UpdateLoadBalancerOptionCommand : BaseLoadBalancerOptionDto, IRequest
    {
        public class Handler : IRequestHandler<UpdateLoadBalancerOptionCommand>
        {
            private readonly IApiGatewayDbContext _context;

            public Handler(IApiGatewayDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateLoadBalancerOptionCommand request, CancellationToken cancellationToken)
            {
                var entity =
                    await _context.LoadBalancerOptions.SingleOrDefaultAsync(
                        r => r.LoadBalancerOptionId == request.LoadBalancerOptionId, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(LoadBalancerOption), request.LoadBalancerOptionId);
                }

                entity.Type = request.Type;
                entity.RouteId = request.RouteId;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}