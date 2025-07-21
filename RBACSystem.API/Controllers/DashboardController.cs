using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RBACSystem.Core.Interfaces;
using RBACSystem.Core.DTOs.Dashboard;

namespace RBACSystem.API.Controllers
{
    /// <summary>
    /// Role-based dashboards for Admin, Editor, Viewer users.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<AdminDashboardDto>> GetAdminDashboard()
        {
            var result = await _dashboardService.GetAdminDashboardAsync();
            return Ok(result);
        }

        [HttpGet("editor")]
        [Authorize(Roles = "Editor")]
        public async Task<ActionResult<EditorDashboardDto>> GetEditorDashboard()
        {
            var result = await _dashboardService.GetEditorDashboardAsync();
            return Ok(result);
        }

        [HttpGet("viewer")]
        [Authorize(Roles = "Viewer")]
        public async Task<ActionResult<ViewerDashboardDto>> GetViewerDashboard()
        {
            var result = await _dashboardService.GetViewerDashboardAsync();
            return Ok(result);
        }
    }
}
