using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Reflection;
using System.Text;
using TechyMartProject.Application.Profiles;
using TechyMartProject.Application.Services.Implementations;
using TechyMartProject.Application.Services.Services;
using TechyMartProject.Domain.Entities;
using TechyMartProject.Domain.Interfaces.Repositories;
using TechyMartProject.Domain.Interfaces.Repositories.Common;
using TechyMartProject.Persistence.Contexts;
using TechyMartProject.Persistence.Repositories;
using TechyMartProject.Persistence.Repositories.Common;

namespace TechyMartProject.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {

                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "JWT Authorization header. \r\n\r\n Write 'Bearer {token}'"
                });

                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
            });


            builder.Services.AddHttpContextAccessor();
            // 🔹 DbContext əlavə edirik
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());





            //builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            builder.Services.AddScoped<IProductService, ProductService>();

            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICartItemService, CartItemService>();
            builder.Services.AddScoped<IWishlistService, WishlistService>();
            builder.Services.AddScoped<IOtpService, OtpService>();
            builder.Services.AddScoped<IOtpRepository, OtpRepository>();
            builder.Services.AddScoped<IMailService, MailService>();

            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderService, OrderService>();

            builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
            builder.Services.AddScoped<IWishlistRepository, WishlistRepository>();
            builder.Services.AddScoped(typeof(IRepository<Product>), typeof(Repository<Product>));
            builder.Services.AddScoped(typeof(IRepository<Category>), typeof(Repository<Category>));
            string connectionString = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<TechyMartDbContext>(options =>
                options.UseSqlServer(connectionString)
            );

            // 🔹 Identity konfiqurasiyası
            builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 8;
                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.MaxFailedAccessAttempts = 5;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(1);
            })
            .AddEntityFrameworkStores<TechyMartDbContext>()
            .AddDefaultTokenProviders();



            var configuration = builder.Configuration;


            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = configuration["Jwt:Issuer"],
        ValidAudience = configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(configuration["Jwt:Key"])
        )
    };
});

            builder.Services.AddAuthorization();



            var app = builder.Build();

            // Səhvlər burada idi. Middleware-lərin düzgün sıralaması aşağıdakı kimi olmalıdır.
            app.UseHttpsRedirection();

            // Öncə marşrutlaşdırma
            app.UseRouting();

            // Sonra təhlükəsizlik
            app.UseAuthentication();
            app.UseAuthorization();

            // Konfiqurasiya
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Axırda kontrolerləri map etmə
            app.MapControllers();

            app.Run();




            static async Task SeedAdminAsync(IServiceProvider serviceProvider)
            {
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

                // --- 1️⃣ Admin rolunu yarat ---
                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                }

                // --- 2️⃣ Admin istifadəçini yoxla ---
                string adminEmail = "nnahidd770@gmail.com";
                string adminPassword = "nahid_123!";

                var adminUser = await userManager.FindByEmailAsync(adminEmail);

                // --- 3️⃣ Əgər yoxdursa yarat ---
                if (adminUser == null)
                {
                    var user = new AppUser
                    {
                        UserName = "admin",
                        Email = adminEmail,
                        EmailConfirmed = true,
                    
                        PhoneNumber = "+994708279847",
                        
                    };

                    var result = await userManager.CreateAsync(user, adminPassword);

                    // --- 4️⃣ Admin rolunu əlavə et ---
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, "Admin");
                    }
                }
            }

        }
    }
}