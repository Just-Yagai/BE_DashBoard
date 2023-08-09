using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using BE_DashBoard.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_DashBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RncEstadoController : ControllerBase
    {
        public readonly IrncEstadoService _rncEstado;

        public RncEstadoController(IrncEstadoService rncEstado)
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

        [HttpPut]
        [Route("ActualizarDelegaciones/{rnc}")]
        public IActionResult Put(string rnc, [FromBody] RncEstado updaterncEstado)
        {
            IActionResult resultado = _rncEstado.UpdaterncEstado(rnc, updaterncEstado);

            return resultado;
        }
    }
}
