using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using BE_DashBoard.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_DashBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DelegacionesController : ControllerBase
    {
        private readonly IDelegaciones _delegacioensService;

        public DelegacionesController(IDelegaciones delegacionesService)
        {
            _delegacioensService = delegacionesService;
        }

        [HttpGet]
        [Route("ObtenerDelegaciones")]
        public IEnumerable<Delegacion> Get()
        {
            return _delegacioensService.GetDelegaciones();
        }

        [HttpGet]
        [Route("ObtenerDelegacionesBy")]
        public IActionResult Get(string rnc, int AmbienteID, int CanalID)
        {
            var delegacionesFiltradas = _delegacioensService.GetDelegacionesBy(rnc, AmbienteID, CanalID);
            if (delegacionesFiltradas == null || !delegacionesFiltradas.Any())
            {
                return NoContent();
            }
            return Ok(delegacionesFiltradas);
        }
        [HttpPut]
        [Route("ActualizarDelegaciones/{rnc}")]
        public IActionResult Put(string rnc, [FromBody] Delegacion updateDelegaciones)
        {
            IActionResult resultado = _delegacioensService.UpdateDelegaciones(rnc, updateDelegaciones);

            return resultado;
        }
    }
}
