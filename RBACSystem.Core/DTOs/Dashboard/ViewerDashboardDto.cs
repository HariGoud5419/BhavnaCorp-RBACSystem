using System;
namespace RBACSystem.Core.DTOs.Dashboard
{
    /// <summary>
    /// DTO representing data shown to Viewers on the dashboard.
    /// </summary>
    public class ViewerDashboardDto
    {
        public string Message { get; set; } = "Welcome to Viewer Dashboard";
        public int ReadOnlyContent { get; set; }
    }
}
