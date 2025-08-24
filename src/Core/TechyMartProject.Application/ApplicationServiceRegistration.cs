

using System.Reflection;

namespace TechyMartProject.Application;
public static class ApplicationServiceRegistration
{

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
       


        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IProductService, ProductService>();
     
        services.AddScoped<ICategoryService, CategoryService>();
       
       
        return services;
    }
}
