using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RBACSystem.Core.DTOs.Users;
using RBACSystem.Core.Interfaces;
using System.Security.Claims;

namespace RBACSystem.API.Controllers
{
    /// <summary>
    /// API controller for managing users, fetching profile info and user administration.
    /// Jwt Autentication via [Authorize]
    /// Claims used: ClaimTypes.Email
    /// Role-based access policies: [Authorize(Roles = "...")]
    /// Secure endpoints with structured IUserService abstraction
    /// </summary>
    /// <remarks>
    /// Constructor with dependency injection of the user service.
    /// </remarks>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // 👈 Ensures all actions require authentication
    public class UsersController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        /// <summary>
        /// Get profile info for currently authenticated user.
        /// </summary>
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfileAsync()
        {
            var email = User.FindFirstValue(ClaimTypes.Email); // Fetch from token claims

            if (string.IsNullOrWhiteSpace(email))
                return Unauthorized("Invalid token - email not found.");

            var userDto = await _userService.GetUserProfileByEmailAsync(email);

            if (userDto == null)
                return NotFound("User not found.");

            return Ok(userDto);
        }

        /// <summary>
        /// Get list of all users (Admin, Manager only).
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        /// <summary>
        /// Get specific user by ID (Admin only).
        /// </summary>
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserByIdAsync(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
                return NotFound("User not found.");

            return Ok(user);
        }

        /// <summary>
        /// Soft-delete a user (Admin only).
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUserAsync(Guid id)
        {
            var success = await _userService.SoftDeleteUserAsync(id);

            if (!success)
                return NotFound("User not found or already deleted.");

            return NoContent();
        }
    }
}
