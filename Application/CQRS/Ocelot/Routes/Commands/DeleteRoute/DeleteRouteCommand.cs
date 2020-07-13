﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities.Routes;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.CQRS.Ocelot.Routes.Commands.DeleteRoute
{
    public class DeleteRouteCommand : IRequest
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<DeleteRouteCommand>
        {
            private readonly IApiGatewayDbContext _context;
            private readonly ILogger<Handler> _logger;

            public Handler(IApiGatewayDbContext context, ILogger<Handler> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<Unit> Handle(DeleteRouteCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var entity = await _context.Routes.FindAsync(request.Id);

                    if (entity == null)
                        throw new NotFoundException(nameof(Route), request.Id);

                    _context.Routes.Remove(entity);

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