using BE_DashBoard.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PB_Dashboard.Constant;
using PB_Dashboard.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PB_Dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ICredenciales _credencialesServices;

        public LoginController(IConfiguration configuration, ICredenciales credenciales) 
        {
            _configuration = configuration;
            _credencialesServices = credenciales;
        }

        [HttpPost]
        public IActionResult Login(LoginUser userLogin)
        {
            var usuarios = Authenticate(userLogin);

            if  (usuarios != null)
            {
                var token = Generate(usuarios);

                return Ok(token);  
            }

            // return 401 authorized
            return Unauthorized();
        }

        // mover para services credenciales el metodo de Authenticate
        private UsersModel Authenticate(LoginUser userLogin)
        {
            var currentUser = _credencialesServices.GetUsers().FirstOrDefault( user => 
                user.Username.ToLower() == userLogin.Username.ToLower() &&
                user.Password == userLogin.Password );

            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }

        // agregar a un servicio y utilizar la manera que se implemento anteriormente el jwt
        private string Generate(UsersModel usuarios)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Reclamaciones = Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuarios.Username),
               // new Claim(ClaimTypes.Role, usuarios.Rol)
            };

            // Crear Token
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
