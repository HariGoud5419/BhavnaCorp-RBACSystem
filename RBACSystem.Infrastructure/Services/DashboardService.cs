using RBACSystem.Core.DTOs.Dashboard;
using RBACSystem.Core.Interfaces;

namespace RBACSystem.Infrastructure.Services
{
    /// <summary>
    /// Provides mock dashboard data for different user roles.
    /// Demonstrates service layer abstraction for role-based dashboards.
    /// </summary>
    public class DashboardService : IDashboardService
    {
        public Task<AdminDashboardDto> GetAdminDashboardAsync()
        {
            return Task.FromResult(new AdminDashboardDto
            {
                TotalUsers = 42,
                RolesManaged = 5,
                SystemHealth = "Healthy"
            });
        }

        public Task<EditorDashboardDto> GetEditorDashboardAsync()
        {
            return Task.FromResult(new EditorDashboardDto
            {
                ContentToEdit = 9,
                PendingApprovals = 2
            });
        }

        public Task<ViewerDashboardDto> GetViewerDashboardAsync()
        {
            return Task.FromResult(new ViewerDashboardDto
            {
                ReadOnlyContent = 18
            });
        }
    }
}
