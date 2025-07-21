using RBACSystem.Core.DTOs.Dashboard;

namespace RBACSystem.Core.Interfaces
{
    /// <summary>
    /// Contract for providing role-based dashboard data.
    /// </summary>
    public interface IDashboardService
    {
        Task<AdminDashboardDto> GetAdminDashboardAsync();
        Task<EditorDashboardDto> GetEditorDashboardAsync();
        Task<ViewerDashboardDto> GetViewerDashboardAsync();
    }
}
