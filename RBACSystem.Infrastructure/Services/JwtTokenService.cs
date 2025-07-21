using System;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Options;
using RBACSystem.Core.Configuration;
using RBACSystem.Core.Entities;
using RBACSystem.Core.Interfaces;

namespace RBACSystem.Infrastructure.Services
{
    /// <summary>
    /// Implementation of IJwtTokenService to generate secure JWT tokens.
    /// </summary>
    public class JwtTokenService(IOptions<JwtSettings> jwtOptions) : IJwtTokenService
    {
        private readonly JwtSettings _jwtSettings = jwtOptions.Value;

        /// <summary>
        /// Generates a JWT token for the specified user, including their role claims.
        /// </summary>
        /// <param name="user">The user entity.</param>
        /// <returns>JWT token string</returns>
        public string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()), // subject
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Username),
            };

            // Add role claims
            if (user.UserRoles != null)
            {
                claims.AddRange(
                    user.UserRoles
                        .Where(ur => ur.IsActive)
                        .Select(ur => new Claim(ClaimTypes.Role, ur.Role.Name))
                );
            }

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiresInMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
