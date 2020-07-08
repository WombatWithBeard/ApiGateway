using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Ocelot.LoadBalancerOptions.Queries.GetLoadBalancerOptionsList
{
    public class GetLoadBalancerOptionsListQuery : IRequest<LoadBalancerOptionsListViewModel>
    {
        public class Handler : IRequestHandler<GetLoadBalancerOptionsListQuery, LoadBalancerOptionsListViewModel>
        {
            private readonly IApiGatewayDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IApiGatewayDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<LoadBalancerOptionsListViewModel> Handle(GetLoadBalancerOptionsListQuery request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var vm = new LoadBalancerOptionsListViewModel
                    {
                        ListDtos = await _context.LoadBalancerOptions.AsNoTracking()
                            .ProjectTo<LoadBalancerOptionsListDto>(_mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken)
                    };

                    return vm;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return new LoadBalancerOptionsListViewModel {Success = false, Message = e.Message};
                }
            }
        }
    }
}