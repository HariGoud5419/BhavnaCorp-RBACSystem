namespace RBACSystem.Core.DTOs.Users
{
    /// <summary>
    /// DTO for exposing authenticated user's profile.
    /// </summary>
    public class UserProfileDto
    {
        public string Username { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public List<string> Roles { get; set; } = [];
    }
}
