using Microsoft.AspNetCore.Mvc;
using RBACSystem.Core.DTOs.Auth;
using RBACSystem.Core.Entities;
using RBACSystem.Core.Interfaces;
using RBACSystem.Core.Utilities;

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

        /// <summary>
        /// Handles authentication-related endpoints like login and registration.
        /// </summary>
        [HttpPost("register")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ApiResponse<string>.Failure("Invalid input."));

            // Map DTO to Entity
            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = dto.Password // will be hashed in service
            };

            await _authService.RegisterUserAsync(user, dto.Roles);

            return CreatedAtAction(nameof(Register), ApiResponse<string>.SuccessResponse("User registered successfully."));
        }

    }
}
