using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechyMartProject.Application.DTOs.AuthDTO;
using TechyMartProject.Application.DTOs.OtpCode;
using TechyMartProject.Application.Services.Implementations;
using TechyMartProject.Application.Services.Services;

namespace TechyMartProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authServices;

        public AuthController(IAuthService authServices)
        {
            _authServices = authServices;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid registration data.");
            }
            try
            {
                string result = await _authServices.Registerasync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Registration failed: {ex.Message}");
            }
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Loginasync(LoginDto dto)
        {
            if (dto is null)
            {
                return BadRequest("xetaaaa");
            }
            try
            {
                string lginResult = await _authServices.Loginasync(dto);
                return Ok(lginResult);

            }
            catch (Exception ex)
            {

                return BadRequest($"Login failed: {ex.Message}");
            }
        }

        [HttpPost("verify-otp")]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpDto dto)
        {
            bool isValid = await _authServices.VerifyOtpAsync(dto.Email, dto.Code, dto.Type);
            if (!isValid)
                return BadRequest("Kod etibarsızdır və ya vaxtı keçib.");

            return Ok("Kod təsdiqləndi.");
        }
    }
}
