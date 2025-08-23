

namespace TechyMartProject.Application.Services.Services;
public interface IJwtTokenGenerator
{
    string GenerateToken(AppUser user, IList<string> roles);

}
