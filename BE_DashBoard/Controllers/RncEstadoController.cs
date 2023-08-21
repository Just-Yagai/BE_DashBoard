using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using BE_DashBoard.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static BE_DashBoard.Services.RncEstadosService;

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
        public async Task<IActionResult> GetSecuencia(int ambiente, string rnc, int CanalID)
        {
            var secuencia = await _rncestadoservice.GetRncEstado((DbType2)ambiente, rnc, CanalID);
            return Ok(secuencia);
        }
    }
}
