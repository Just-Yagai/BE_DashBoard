using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BE_DashBoard.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BE_DashBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public UsuarioController(IConfiguration configuration) 
        {
            _configuration = configuration;
        }
        public dynamic IniciarSesion([FromBody] object optData)
        {
            var data = JsonConvert.DeserializeObject<dynamic>(optData.ToString());

            string user = data.usuario.ToString();
            string password = data.password.ToString();

            Credencial _usuario = Credencial.DB().Where(x => x.usuario == user && x.password == password).FirstOrDefault();

            if(_usuario == null)
            {
                return new
                {
                    success = false,
                    message = "Credenciales incorrectas",
                    result = ""
                };
            }

            var jwt = _configuration.GetSection("Jwt").Get<Jwt>();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("id",_usuario.idusuario),
                new Claim("usuario",_usuario.usuario)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: singIn
                );

            return new
            {
                success = true,
                message = "exito",
                result = new JwtSecurityTokenHandler().WriteToken(token)
            };  
        }
    }
}
