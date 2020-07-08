using System;
using Application.Common.Mapping;
using AutoMapper;
using Infrastructure.Tools;

namespace Application.UnitTests.Common
{
    public class TestBase : IDisposable
    {
        protected readonly ApiGatewayDbContext Context;
        protected readonly IMapper Mapper;

        public TestBase()
        {
            Context = ContextFactory.Create();

            var config = new MapperConfiguration(cfg => { cfg.AddProfile<AutoMappingProfile>(); });

            Mapper = config.CreateMapper();
        }

        public void Dispose()
        {
            ContextFactory.Destroy(Context);
        }
    }
}