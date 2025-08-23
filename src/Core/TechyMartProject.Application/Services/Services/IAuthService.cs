

namespace TechyMartProject.Application.Services.Services
{
    public interface IAuthService
    {

        Task<string> Registerasync(RegisterDto dto);
        Task<string> Loginasync(LoginDto dto);
    }
}
