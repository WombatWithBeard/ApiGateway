using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities.Routes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Ocelot.GlobalConfigurations.Commands.UpdateGlobalConfiguration
{
    public class UpdateGlobalConfigurationCommand : BaseGlobalConfigurationDto, IRequest
    {
        public class Handler : IRequestHandler<UpdateGlobalConfigurationCommand>
        {
            private readonly IApiGatewayDbContext _context;

            public Handler(IApiGatewayDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateGlobalConfigurationCommand request,
                CancellationToken cancellationToken)
            {
                var entity =
                    await _context.GlobalConfigurations.SingleOrDefaultAsync(
                        r => r.GlobalConfigurationId == request.GlobalConfigurationId, cancellationToken);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(GlobalConfiguration), request.GlobalConfigurationId);
                }

                entity.BaseUrl = request.BaseUrl;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}