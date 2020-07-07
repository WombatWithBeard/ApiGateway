using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities.Routes;
using MediatR;

namespace Application.CQRS.Ocelot.AuthenticationOptions.Commands.DeleteAuthenticationOption
{
    public class DeleteAuthenticationOptionCommand : IRequest
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<DeleteAuthenticationOptionCommand>
        {
            private readonly IApiGatewayDbContext _context;

            public Handler(IApiGatewayDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteAuthenticationOptionCommand request,
                CancellationToken cancellationToken)
            {
                var entity = await _context.AuthenticationOptions.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(AuthenticationOption), request.Id);
                }

                _context.AuthenticationOptions.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}