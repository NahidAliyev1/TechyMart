using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechyMartProject.Application.DTOs.AuthDTO;
public class ForgotPasswordDto
{
    public string Email { get; set; }

}
public class ResetPasswordDto
{
    public string NewPassword { get; set; }
   
    public string Token { get; set; }
    public string Email { get; set; }
}