using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.CQRS.Ocelot.Routes.Commands.SaveRoutesJson
{
    public class SaveRoutesJsonCommand : IRequest
    {
        public class Handler : IRequestHandler<SaveRoutesJsonCommand>
        {
            private readonly IApiGatewayDbContext _context;
            private readonly IMapper _mapper;
            private readonly ILogger<Handler> _logger;

            public Handler(IApiGatewayDbContext context, IMapper mapper, ILogger<Handler> logger)
            {
                _context = context;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<Unit> Handle(SaveRoutesJsonCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var json = new RoutesJsonSaveViewModel
                    {
                        Routes = await _context.Routes.AsNoTracking()
                            .Include(p => p.LoadBalancerOptions)
                            .Include(p => p.DownstreamHostAndPorts)
                            .Include(p => p.UpstreamHttpMethod)
                            .Include(p => p.AuthenticationOptions)
                            .ThenInclude(option => option.AllowedScopes)
                            .Where(r => r.Enabled)
                            .ProjectTo<RoutesJsonSaveDto>(_mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken),
                        GlobalConfiguration =
                            await _context.GlobalConfigurations.FirstOrDefaultAsync(
                                cancellationToken: cancellationToken)
                    };

                    File.WriteAllText(Directory.GetCurrentDirectory() + @"\ocelot.json",
                        JsonSerializer.Serialize(json));

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