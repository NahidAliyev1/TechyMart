

namespace TechyMartProject.Application;
public static class ApplicationServiceRegistration
{

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IProductService, ProductService>();
      /*  services.AddScoped<IRepository<Product>, Repository<Product>>();
        services.AddScoped<IRepository<Category>, Repository<Category>>();*/
        services.AddScoped<ICategoryService, CategoryService>();
       
       
        return services;
    }
}
