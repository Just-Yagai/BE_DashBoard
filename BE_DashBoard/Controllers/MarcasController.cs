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
    public class MarcasController : ControllerBase
    {

        private readonly IMarcasService _marcasservice;
        private readonly AplicacionDbContextBlue _dbcontext;
        public MarcasController(IMarcasService marcasservice, AplicacionDbContextBlue dbcontext)
        {
           _marcasservice = marcasservice;
            _dbcontext = dbcontext;
        }

        [HttpGet]
        [Route("ObtenerMarca")]
        public async Task<IActionResult> Getmarcas(int ambiente, string rnc, int canal)
        {
            var Marca = await _marcasservice.GetMarcasBy((DbType)ambiente, rnc, canal);
            return Ok(Marca);
        }

        [HttpPut]
        [Route("ActualizarMarcas/{Rnc}")]
        public async Task<IActionResult> Put(string Rnc, [FromBody] Marcas updateMarcas, int ambiente)
        {
            try
            {
                var result = await _marcasservice.ActualizarMarcas(Rnc, updateMarcas, ambiente);

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

