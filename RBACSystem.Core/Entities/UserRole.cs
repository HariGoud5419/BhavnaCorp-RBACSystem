using System;
using System.ComponentModel.DataAnnotations;

namespace RBACSystem.Core.Entities
{
    /// <summary>
    /// Join table representing the many-to-many relationship between User and Roles.
    /// Supports role assignment metadata.
    /// </summary>
    public class UserRole
    {

        /// <summary>
        /// Date when the role was assigned.
        /// </summary>
        public DateTime AssignedDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Whether this role assignment is currently active.
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Foreign key: to the User.
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Navigation property: Related Employee.
        /// </summary>
        public required User User { get; set; }

        /// <summary>
        /// Foreign key: Role.
        /// </summary>
        public Guid RoleId { get; set; }

        /// <summary>
        /// Navigation property: Related Role.
        /// </summary>
        public required Role Role { get; set; }

    }
}
