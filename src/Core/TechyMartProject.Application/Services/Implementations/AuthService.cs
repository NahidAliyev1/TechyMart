using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Data;
using TechyMartProject.Application.DTOs.AuthDTO;
using TechyMartProject.Application.Services.Services;
using TechyMartProject.Domain.Entities;

namespace TechyMartProject.Application.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

      

        public AuthService(UserManager<AppUser> userManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;

        }




       
        public async Task<string> Loginasync(LoginDto dto)
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

            var roles = await _userManager.GetRolesAsync(appUser);
            return _jwtTokenGenerator.GenerateToken(appUser, roles);
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
