using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using BE_DashBoard.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_DashBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecuenciaController : ControllerBase
    {

        public readonly ISecuencuasService _secuencuasService;

        public SecuenciaController(ISecuencuasService secuencuasService)
        {
            _secuencuasService = secuencuasService;

        }

        [HttpGet]
        [Route("GetSecuencias")]
        public IEnumerable<Secuencias> Get() {

            return _secuencuasService.GetSecuencias();

        }

        [HttpGet]
        [Route("GetSecuenciaBy")]
        public IActionResult Get(string rnc, int AmbienteID, int CanalID, int TipoECF)
        {
            {
                var SecuenciasFiltrada = _secuencuasService.GetSecuenciasRnc(rnc, AmbienteID, CanalID, TipoECF);
                if(SecuenciasFiltrada == null | !SecuenciasFiltrada.Any())
                {
                    return NoContent();
                
                }
                return Ok(SecuenciasFiltrada);
            }

        }

    }
}
