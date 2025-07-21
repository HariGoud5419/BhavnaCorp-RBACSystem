namespace RBACSystem.Core.DTOs.Roles
{
    /// <summary>
    /// Represents a basic role used for role dropdown selection or listing.
    /// </summary>
    public class RoleDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string RoleType { get; set; } = string.Empty;
    }
}
