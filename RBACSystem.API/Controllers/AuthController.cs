using Microsoft.AspNetCore.Mvc;
using RBACSystem.Core.DTOs.Auth;
using RBACSystem.Core.Interfaces;

namespace RBACSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        /// <summary>
        /// Authenticates user and returns JWT token if valid.
        /// </summary>
        [Produces("application/json")]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _authService.ValidateUserAsync(request.Email, request.Password);

            if (user == null)
                return Unauthorized("Invalid email or password.");

            var token = await _authService.GenerateJwtTokenAsync(user);

            var response = new LoginResponseDto
            {
                Token = token,
                Username = user.Username,
                Email = user.Email,
                Roles = user.UserRoles?
                        .Where(ur => ur.IsActive)
                        .Select(ur => ur.Role.Name)
                        .ToList() ?? []
            };

            return Ok(response);
        }
    }
}
