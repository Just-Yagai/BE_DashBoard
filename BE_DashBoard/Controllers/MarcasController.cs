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
        public async Task<IActionResult> Put(string Rnc, Marcas updateMarcas)
        {
            try
            {
                string claveBusqueda = Rnc + "" + updateMarcas.Tipo;

                if (Rnc != updateMarcas.Rnc)
                {
                    return BadRequest();
                }

                // Buscar la entidad por la clave primaria
                var MarcaUpdate = await _dbcontext.Marcas.FirstOrDefaultAsync(r => (r.Rnc + "" + r.Tipo) == claveBusqueda);

                if (MarcaUpdate == null)
                {
                    return NotFound();
                }
                MarcaUpdate.Estado = updateMarcas.Estado;

                await _dbcontext.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /* private readonly IMarcasService _marcasService;

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
         public IActionResult Put(string rnc, [FromBody]Marcas updateMarcas)
         {
             IActionResult resultado = _marcasService.UpdateMarcas(rnc, updateMarcas);

             return resultado;
         }*/
    }
}
