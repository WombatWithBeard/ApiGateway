using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities.Routes;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.CQRS.Ocelot.GlobalConfigurations.Commands.DeleteGlobalConfiguration
{
    public class DeleteGlobalConfigurationCommand : IRequest
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<DeleteGlobalConfigurationCommand>
        {
            private readonly IApiGatewayDbContext _context;
            private readonly ILogger<Handler> _logger;

            public Handler(IApiGatewayDbContext context, ILogger<Handler> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<Unit> Handle(DeleteGlobalConfigurationCommand request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var entity = await _context.GlobalConfigurations.FindAsync(request.Id);

                    if (entity == null)
                    {
                        throw new NotFoundException(nameof(GlobalConfiguration), request.Id);
                    }

                    _context.GlobalConfigurations.Remove(entity);

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