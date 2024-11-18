using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserAuth.Models.Responses.UserResponse;

namespace UserAuth.Services
{
    public class JwtService(IConfiguration configuration)
    {
        private readonly string? _secret = configuration["Jwt:Key"];
        private readonly int? _expirationMinutes = int.TryParse(configuration["Jwt:ExpirationMinutes"], out var minutes) ? minutes : null;

        public string GenerateToken(AuthUserResponse user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret ?? string.Empty));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(_expirationMinutes ?? 0),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}