using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using TechyMartProject.Application.DTOs.AuthDTO;
using TechyMartProject.Application.Services.Services;
using TechyMartProject.Domain.Entities;

namespace TechyMartProject.Application.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        


        public AuthService(UserManager<AppUser> userManager )
        {
            _userManager = userManager;
           
        }




       
        public Task<string> Loginasync(LoginDto dto)
        {
         AppUser? appUser = _userManager.FindByEmailAsync(dto.Email).Result;
            if (appUser == null)
            {
                throw new Exception("User not found");
            }
            var result = _userManager.CheckPasswordAsync(appUser, dto.Password).Result;
            if (!result)
            {
                throw new Exception("Invalid password");
            }
            // Here you would typically generate a JWT token or session for the user
            // For simplicity, we are returning a success message
            return Task.FromResult("Login successful");
        }

        public Task<string> Registerasync(RegisterDto dto)
        {
           AppUser? user = new AppUser()
           {
               Fullname = dto.Fullname,
               Email = dto.Email,
               UserName = dto.Email // Assuming UserName is the same as Email

           };
            IdentityResult result = _userManager.CreateAsync(user,dto.Password).Result;
            if (!result.Succeeded)
            {
                string errors=string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"User registration failed: {errors}");
            }
            return Task.FromResult("User registered successfully");
        }
    }
}
