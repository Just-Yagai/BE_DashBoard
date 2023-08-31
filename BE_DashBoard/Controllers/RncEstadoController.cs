using BE_DashBoard.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static BE_DashBoard.ClaseEnumerable.AmbienteEnum;

namespace BE_DashBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RncEstadoController : ControllerBase
    {
        private readonly IrncEstadoService _rncestadoservice;
        public RncEstadoController(IrncEstadoService rncestadoservice)
        {
            _rncestadoservice = rncestadoservice;
        }

        [HttpGet]
        [Route("ObtenerRncEstado")]
        public async Task<IActionResult> GetRncEstado(int ambiente, string rnc, int CanalID)
        {
            var RncEstado = await _rncestadoservice.GetRncEstado((DbType)ambiente, rnc, CanalID);
            return Ok(RncEstado);
        }
    }
}
