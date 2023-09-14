using BE_DashBoard.Context;
using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static BE_DashBoard.ClaseEnumerable.AmbienteEnum;

namespace BE_DashBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DelegacionDbController : ControllerBase
    {
        private readonly IConexionDelegacionesServices _conexiondelegacionservices;
  
        public DelegacionDbController(IConexionDelegacionesServices conexionDelegacionesServices)
        {
            _conexiondelegacionservices = conexionDelegacionesServices;
          
        }

        [HttpGet]
        [Route("ObtenerDelegaciones")]
        public async Task<IActionResult> GetDelegaciones(int ambiente, string rnc, int canal)
        {
            var delegaciones = await _conexiondelegacionservices.GetDelegaciones((DbType)ambiente, rnc, canal);
            return Ok(delegaciones);
        }

        [HttpPut]
        [Route("ActualizarDelegacion/{Rnc}")]
        public async Task<IActionResult> Put(string Rnc, [FromBody] Delegacion updatedelegaciones, int ambiente)
        {
            try
            {
                var result = await _conexiondelegacionservices.ActualizarDelegaciones(Rnc, updatedelegaciones, ambiente);

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

