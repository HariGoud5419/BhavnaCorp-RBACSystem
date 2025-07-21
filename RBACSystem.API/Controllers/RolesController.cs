using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RBACSystem.Core.DTOs.Roles;
using RBACSystem.Core.Interfaces;

namespace RBACSystem.API.Controllers
{
    /// <summary>
    /// Handles role-related API endpoints. Accessible to Admins or for open role listing.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// Lists all roles in the system. Used during user registration or admin views.
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin")] // Can make this [AllowAnonymous] if needed in registration page
        public async Task<ActionResult<List<RoleDto>>> GetRoles()
        {
            var roles = await _roleService.GetAllRolesAsync();
            return Ok(roles);
        }
    }
}
