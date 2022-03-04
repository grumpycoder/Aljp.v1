using Aljp.Application.Interfaces;
using Aljp.Infrastructure.Persistence;
using Aljp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aljp.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        
        //services.AddScoped<DomainEventDispatcher>();

        services.AddDbContext<ApplicationDbContext>(options =>
            options
                //.AddInterceptors(services.BuildServiceProvider().GetService<DomainEventDispatcher>())
                .UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")
                )
        );
      
        services.AddScoped<IVendorRepository, VendorRepository>();
        services.AddScoped<IMiniBidRepository, MiniBidRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>(); 
        
        return services;
    }
}