using Microsoft.Extensions.DependencyInjection;
using TechyMartProject.Domain.Interfaces.Repositories;

namespace TechyMartProject.Domain;
public static class DomainServiceRegistartion
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
       services.AddScoped<ICartItemRepository>();
        services.AddScoped<IWishlistRepository>();
        return services;
    }


}
