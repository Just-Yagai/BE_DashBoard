using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using Microsoft.IdentityModel.Tokens;
using PB_Dashboard.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BE_DashBoard.Services
{
    public class TokenServices : IToken
    {
        private readonly IConfiguration _configuration;

        public TokenServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<string> GenerateToken(LoginUser AutenticacionFiltrada)
        {
            var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Aud, jwt.Audience),
            new Claim(JwtRegisteredClaimNames.Iss, jwt.Issuer),
            new Claim(ClaimTypes.NameIdentifier, AutenticacionFiltrada.Username)
        };

            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Subject,
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            yield return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

