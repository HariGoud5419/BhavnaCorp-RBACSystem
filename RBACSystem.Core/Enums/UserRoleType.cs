namespace RBACSystem.Core.Enums
{
    /// <summary>
    /// Enumeration representing different role types for system users.
    /// Useful for Role-Based Access Control (RBAC) and feature-based authorization.
    /// </summary>
    public enum UserRoleType
    {
        Admin = 0,
        Manager = 1,
        Viewer = 2,
        Editor = 3,
        Others = 4,
    }
}
