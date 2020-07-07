using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities.Routes;
using MediatR;

namespace Application.CQRS.Ocelot.DownstreamHostAndPorts.Commands.DeleteDownstreamHostAndPort
{
    public class DeleteDownstreamHostAndPortCommand : IRequest
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<DeleteDownstreamHostAndPortCommand>
        {
            private readonly IApiGatewayDbContext _context;

            public Handler(IApiGatewayDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteDownstreamHostAndPortCommand request,
                CancellationToken cancellationToken)
            {
                var entity = await _context.DownstreamHostAndPorts.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(DownstreamHostAndPort), request.Id);
                }

                _context.DownstreamHostAndPorts.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}