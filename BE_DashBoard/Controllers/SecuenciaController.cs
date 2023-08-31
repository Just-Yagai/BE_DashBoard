using BE_DashBoard.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static BE_DashBoard.ClaseEnumerable.AmbienteEnum;

namespace BE_DashBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecuenciaController : ControllerBase
    {
        private readonly ISecuencuasService _secuencuaservice;
        public SecuenciaController(ISecuencuasService secuencuaservice)
        {
            _secuencuaservice = secuencuaservice;
        }

        [HttpGet]
        [Route("ObtenerSecuencia")]
        public async Task<IActionResult> GetSecuencia(int ambiente, string rnc, int CanalID, int TipoECF)
        {
            var secuencia = await _secuencuaservice.GetSecuencias((DbType)ambiente, rnc, CanalID, TipoECF);
            return Ok(secuencia);
        }


        /* public readonly ISecuencuasService _secuencuasService;

         public SecuenciaController(ISecuencuasService secuencuasService)
         {
             _secuencuasService = secuencuasService;

         }

         [HttpGet]
         [Route("GetSecuencias")]
         public IEnumerable<Secuencias> Get() {

             return _secuencuasService.GetSecuencias();

         }

         [HttpGet]
         [Route("GetSecuenciaBy")]
         public IActionResult Get(string rnc, int AmbienteID, int CanalID, int TipoECF)
         {
             {
                 var SecuenciasFiltrada = _secuencuasService.GetSecuenciasRnc(rnc, AmbienteID, CanalID, TipoECF);
                 if(SecuenciasFiltrada == null | !SecuenciasFiltrada.Any())
                 {
                     return NoContent();

                 }
                 return Ok(SecuenciasFiltrada);
             }

         }*/

    }
}
