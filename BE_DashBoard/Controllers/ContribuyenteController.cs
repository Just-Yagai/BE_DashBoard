using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BE_DashBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContribuyenteController : ControllerBase
    {
        private readonly IContribuyentesService _contribuyentesService;
        public ContribuyenteController(IContribuyentesService contribuyentesService)
        {
            _contribuyentesService = contribuyentesService;
        }

        [HttpGet]
        [Route("Comporbando Permisos")]
        [Authorize]

        public dynamic permiso(Contribuyentes contribuyentes)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            var rToken = Jwt.ValidarToken(identity);

            if(!rToken.success)
                return rToken;

            Credencial credencial = rToken.result;

            if(credencial.rol != "administrador")
            {
                return new
                {
                    success = false,
                    message = "no tienes permiso",
                    result = ""
                };
            }

            return new
                {
                success = true,
                    message = "tienes permiso",
                    result = ""
                };
        }

        
        [HttpGet]
        [Route("ObtenerContribuyentesByRnc")]
          public IActionResult Get(string rnc)
          {
              var contribuyentesFiltrados = _contribuyentesService.GetContribuyentesByRnc(rnc);
              if(contribuyentesFiltrados == null || !contribuyentesFiltrados.Any())
              {
                  return NoContent();
              }
              return Ok(contribuyentesFiltrados);
          }
    }
}
