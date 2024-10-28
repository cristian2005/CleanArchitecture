using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CA.Infrastructure.Application.ServiceCollection
{
    public static class ServiceExtension
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
