using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechyMartProject.Domain.Entities;

namespace TechyMartProject.Application.Services.Services;
public interface IJwtTokenGenerator
{
    string GenerateToken(AppUser user, IList<string> roles);

}
