using CA.Core.Interfaces.Base;
using CA.Infrastructure.Persistence.DbContexts;
using CA.Infrastructure.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CA.Infrastructure.Persistence.ServiceCollection
{
    public static class ServiceExtension
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            /* Contextos de Bases de Datos. */
            services.AddDbContext<AppDbContext>(options => { options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")); options.UseLazyLoadingProxies(); });

            /* DbFactory pattern. */
            /* Agregar aquí las implementaciones de Factory Pattern, asociadas a cada conexto de Base de Datos... */
            services.AddScoped<Func<AppDbContext>>((provider) => () => provider.GetService<AppDbContext>()!);

            /*Repositorios */
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
