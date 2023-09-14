using BE_DashBoard.Context;
using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using BE_DashBoard.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static BE_DashBoard.ClaseEnumerable.AmbienteEnum;

namespace BE_DashBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RncEstadoController : ControllerBase
    {
        private readonly IrncEstadoService _rncestadoservice;
        private readonly AplicacionDbContext _dbcontext;
        private readonly AplicacionDbContextBlue _dbcontextBlue;
        public RncEstadoController(IrncEstadoService rncestadoservice, AplicacionDbContext dbcontext, AplicacionDbContextBlue dbcontextBlue)
        {
            _rncestadoservice = rncestadoservice;
            _dbcontext = dbcontext;
            _dbcontextBlue = dbcontextBlue;
        }

        [HttpGet]
        [Route("ObtenerRncEstado")]
        public async Task<IActionResult> GetRncEstado(int ambiente, string rnc, int CanalID)
        {
            var RncEstado = await _rncestadoservice.GetRncEstado((DbType)ambiente, rnc, CanalID);
            return Ok(RncEstado);
        }

        [HttpPut]
        [Route("ActualizarRncEstado/{Rnc}")]
        public async Task<IActionResult> Put(string Rnc, [FromBody] RncEstado updaterncEstado, int ambiente)
        {
            try
            {
                var result = await _rncestadoservice.ActualizarRncEstado(Rnc, updaterncEstado, ambiente);

                if (result == null)
                {
                    return NotFound(); // Devuelve NotFound si no se encuentra el elemento o ambiente no es válido
                }

                return NoContent(); // Devuelve NoContent si se actualiza con éxito
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
