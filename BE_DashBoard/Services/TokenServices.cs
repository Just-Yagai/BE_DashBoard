using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using Microsoft.IdentityModel.Tokens;
using PB_Dashboard.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BE_DashBoard.Services
{
    public class TokenServices : ITokenService
    {      
        private readonly Jwt _jwt;
        public Jwt Jwt => _jwt;
        public TokenServices( Jwt jwt)
        {
            _jwt = jwt;
        }

        public string GenerateToken(LoginUser _loginUser)
        {
           // var jwt = _configuration.GetSection("Jwt").Get<Jwt>();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Jwt.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Aud, Jwt.Audience),
            new Claim(JwtRegisteredClaimNames.Iss, Jwt.Issuer),
            new Claim(ClaimTypes.NameIdentifier, _loginUser.Username)
            };

            var token = new JwtSecurityToken(
                Jwt.Issuer,
                Jwt.Subject,
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            //yield return new JwtSecurityTokenHandler().WriteToken(token);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

