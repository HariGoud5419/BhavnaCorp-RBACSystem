using System;

namespace RBACSystem.Core.DTOs.Users
{
    /// <summary>
    /// Represents a simplified user object returned from admin-level queries.
    /// we decouple entity model (User) from returned data, avoiding leaking database fields
    /// All sensitive data like PasswordHash is hidden
    /// Future frontend views can also safely bind to these DTO's 
    /// </summary>
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public List<string> Roles { get; set; } = [];
    }
}
