
using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.EntityFrameworkCore;
using TechyMartProject.Application.Services.Implementations;
using TechyMartProject.Application.Services.Services;
using TechyMartProject.Domain.Entities;
using TechyMartProject.Persistence.Contexts;

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
            builder.Services.AddSwaggerGen();
           builder.Services.AddScoped <IAuthService,AuthService>();
            builder.Services.AddIdentity<AppUser, IdentityRole>()
     .AddEntityFrameworkStores<TechyMartDbContext>()
     .AddDefaultTokenProviders();

            string ? connectstr = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<TechyMartDbContext>(options =>
      options.UseSqlServer(connectstr));
            

            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
