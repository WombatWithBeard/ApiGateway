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

namespace Application.CQRS.Ocelot.Routes.Commands.SaveRoutesJson
{
    public class SaveRoutesJsonCommand : IRequest
    {
        public class Handler : IRequestHandler<SaveRoutesJsonCommand>
        {
            private readonly IApiGatewayDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IApiGatewayDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(SaveRoutesJsonCommand request, CancellationToken cancellationToken)
            {
                var json = new RoutesJsonSaveViewModel
                {
                    ReRoutes = await _context.Routes
                        .Include(p => p.AuthenticationOptions)
                        .Include(p => p.LoadBalancerOptions)
                        .Include(p => p.DownstreamHostAndPorts)
                        .Where(r => r.Enabled)
                        .ProjectTo<RoutesJsonSaveDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken),
                    GlobalConfiguration = await _context.GlobalConfigurations.FindAsync()
                };

                File.WriteAllText(Directory.GetCurrentDirectory() + @"\ocelot2.json", JsonSerializer.Serialize(json));

                return Unit.Value;
            }
        }
    }
}