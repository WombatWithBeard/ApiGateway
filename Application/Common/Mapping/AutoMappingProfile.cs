using System;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace Application.Common.Mapping
{
    public class AutoMappingProfile : Profile
    {
        private const string MappingMethodName = "Mapping";

        public AutoMappingProfile()
        {
            ApplyMappingFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingFromAssembly(Assembly getExecutingAssembly)
        {
            var types = getExecutingAssembly.GetExportedTypes()
                .Where(type =>
                    type.GetInterfaces()
                        .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>))).ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod(MappingMethodName);
                methodInfo?.Invoke(instance, new object[] {this});
            }
        }
    }
}