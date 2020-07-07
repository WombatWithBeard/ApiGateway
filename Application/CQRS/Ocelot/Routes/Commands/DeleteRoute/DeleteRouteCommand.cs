using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities.Routes;
using MediatR;

namespace Application.CQRS.Ocelot.Routes.Commands.DeleteRoute
{
    public class DeleteRouteCommand : IRequest
    {
        public int Id { get; set; }
        
        public class Handler : IRequestHandler<DeleteRouteCommand>
        {
            private readonly IApiGatewayDbContext _context;

            public Handler(IApiGatewayDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteRouteCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Routes.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Route), request.Id);
                }

                _context.Routes.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}