using BE_DashBoard.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PB_Dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {      
        private readonly ICredenciales _credencialesServices;
        private readonly IToken _tokenService;
        public LoginController( ICredenciales credenciales, IToken token) 
        {      
            _credencialesServices = credenciales;
            _tokenService = token;
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var AutenticacionFiltrada = _credencialesServices.GetAutentication(username, password);

            if  (AutenticacionFiltrada == null || !AutenticacionFiltrada.Any())
            {  
                return Unauthorized();
            }
            var generartoken = _tokenService.GenerateToken(AutenticacionFiltrada.First());
            return Ok(generartoken);
        }
    }
}
