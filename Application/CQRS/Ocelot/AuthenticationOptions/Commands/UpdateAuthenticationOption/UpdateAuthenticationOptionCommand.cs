using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities.Routes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Ocelot.AuthenticationOptions.Commands.UpdateAuthenticationOption
{
    public class UpdateAuthenticationOptionCommand : BaseAuthenticationOptionsDto, IRequest
    {
        public class Handler : IRequestHandler<UpdateAuthenticationOptionCommand>
        {
            private readonly IApiGatewayDbContext _context;

            public Handler(IApiGatewayDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateAuthenticationOptionCommand request,
                CancellationToken cancellationToken)
            {
                var entity =
                    await _context.AuthenticationOptions.SingleOrDefaultAsync(
                        r => r.AuthenticationOptionId == request.AuthenticationOptionId, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(AuthenticationOption), request.AuthenticationOptionId);
                }

                entity.AllowedScopes = request.AllowedScopes;
                entity.AuthenticationProviderKey = request.AuthenticationProviderKey;
                entity.RouteId = request.RouteId;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}