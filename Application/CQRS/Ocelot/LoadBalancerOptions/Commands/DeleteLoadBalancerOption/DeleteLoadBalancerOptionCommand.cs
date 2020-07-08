using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities.Routes;
using MediatR;

namespace Application.CQRS.Ocelot.LoadBalancerOptions.Commands.DeleteLoadBalancerOption
{
    public class DeleteLoadBalancerOptionCommand : IRequest
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<DeleteLoadBalancerOptionCommand>
        {
            private readonly IApiGatewayDbContext _context;

            public Handler(IApiGatewayDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteLoadBalancerOptionCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.LoadBalancerOptions.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(LoadBalancerOption), request.Id);
                }

                _context.LoadBalancerOptions.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}