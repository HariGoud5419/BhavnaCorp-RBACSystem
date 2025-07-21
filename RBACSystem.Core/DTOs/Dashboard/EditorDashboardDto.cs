using System;

namespace RBACSystem.Core.DTOs.Dashboard
{
    /// <summary>
    /// DTO representing data shown to Editors on the dashboard.
    /// </summary>
    public class EditorDashboardDto
    {
        public string Message { get; set; } = "Welcome to Editor Dashboard";
        public int ContentToEdit { get; set; }
        public int PendingApprovals { get; set; }
    }
}
