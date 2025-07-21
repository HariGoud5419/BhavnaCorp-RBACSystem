namespace RBACSystem.Core.Configuration
{
    /// <summary>
    /// Strongly typed JWT configuration options bound from appsettings.json.
    /// Used for token generation and validation throughout the application.
    /// </summary>
    public class JwtSettings
    {
        /// <summary>
        /// Secret key used to sign the JWT token using HMAC SHA256 algorithm.
        /// Must be long, random, and stored securely (not in source control).
        /// </summary>
        public string Key { get; set; } = string.Empty;

        /// <summary>
        /// Token issuer — identifies the authority that issues the token.
        /// Usually the application or authentication server's identifier.
        /// </summary>
        public string Issuer { get; set; } = string.Empty;

        /// <summary>
        /// Token audience — specifies the recipient(s) that the token is intended for.
        /// Used to validate that the token is meant for this API.
        /// </summary>
        public string Audience { get; set; } = string.Empty;

        /// <summary>
        /// Duration in minutes for which the token remains valid.
        /// Used to set the token expiration (exp claim).
        /// </summary>
        public int ExpiresInMinutes { get; set; }
    }
}
