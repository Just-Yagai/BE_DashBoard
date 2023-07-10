using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_DashBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RncEstadoController : ControllerBase
    {
        public readonly IrncEstado _rncEstado;

        public RncEstadoController(IrncEstado rncEstado)
        {
            _rncEstado = rncEstado;
        }

        [HttpGet]
        [Route("GetRncEstado")]

        public IEnumerable<RncEstado> Get()
        {
            return _rncEstado.GetRncEstados();

        }

        [HttpGet]
        [Route("GetRncEstadoBy")]

        public IActionResult Get(string rnc, int AmbienteID, int CanalID)
        {
            {
                var FiltadoRncEstado = _rncEstado.GetRncEstadosBy(rnc, AmbienteID,CanalID);
                if(FiltadoRncEstado == null | !FiltadoRncEstado.Any())
                {
                    return NoContent();
                }
                return Ok(FiltadoRncEstado);
            }
        }
    }
}
