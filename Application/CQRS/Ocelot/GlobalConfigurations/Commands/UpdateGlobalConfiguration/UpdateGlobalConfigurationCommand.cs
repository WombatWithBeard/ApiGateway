using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities.Routes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.CQRS.Ocelot.GlobalConfigurations.Commands.UpdateGlobalConfiguration
{
    public class UpdateGlobalConfigurationCommand : BaseGlobalConfigurationDto, IRequest
    {
        public class Handler : IRequestHandler<UpdateGlobalConfigurationCommand>
        {
            private readonly IApiGatewayDbContext _context;
            private readonly ILogger<Handler> _logger;

            public Handler(IApiGatewayDbContext context, ILogger<Handler> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<Unit> Handle(UpdateGlobalConfigurationCommand request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var entity =
                        await _context.GlobalConfigurations.SingleOrDefaultAsync(
                            r => r.GlobalConfigurationId == request.GlobalConfigurationId, cancellationToken);

                    if (entity == null)
                        throw new NotFoundException(nameof(GlobalConfiguration), request.GlobalConfigurationId);

                    entity.BaseUrl = request.BaseUrl;

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