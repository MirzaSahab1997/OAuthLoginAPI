using Microsoft.IdentityModel.Tokens;
using OAuthLoginAPI.Domain.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OAuthLoginAPI.Helper
{
    public class JwtTokenGenerator
    {
        public static string GenerateToken(UserDto user, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username)
        };

            claims.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role)));
            claims.Add(new Claim("regions", string.Join(",", user.AccessibleRegions)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
