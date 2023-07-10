using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BE_DashBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly IMarcasService _marcasService;

        public MarcasController(IMarcasService marcasService)
        {
            _marcasService = marcasService;
        }

        [HttpGet]
        [Route("ObtenerMarcas")]
        public IEnumerable <Marcas> Get()
        {
            return _marcasService.GetMarcas();
        }

        [HttpGet]
        [Route("ObtenerMarcasBy")]
        public IActionResult Get(string rnc, int AmbienteID, int CanalID)
        {
            var marcasFiltradas = _marcasService.GetMarcasBy(rnc, AmbienteID, CanalID);
            if(marcasFiltradas == null || !marcasFiltradas.Any())
            {
                return NoContent();           
            }
            return Ok(marcasFiltradas);    
        }

        [HttpPut]
        [Route("ActualizarMarcas/{rnc}")]
        public IActionResult Put(string rnc, [FromBody] Marcas updateMarcas)
        {
            IActionResult resultado = _marcasService.UpdateMarcas(rnc, updateMarcas);

            return resultado;
        }
    }
}
