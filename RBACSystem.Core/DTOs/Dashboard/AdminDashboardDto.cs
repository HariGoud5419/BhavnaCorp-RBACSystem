using System;

namespace RBACSystem.Core.DTOs.Dashboard
{
    /// <summary>
    /// DTO representing data shown to Admin on the dashboard.
    /// </summary>
    public class AdminDashboardDto
    {
        public string Message { get; set; } = "Welcome to Admin Dashboard";
        public int TotalUsers { get; set; }
        public int RolesManaged { get; set; }
        public string SystemHealth { get; set; } = string.Empty;
    }
}
