using BE_DashBoard.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static BE_DashBoard.ClaseEnumerable.AmbienteEnum;

namespace BE_DashBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DelegacionDbController : ControllerBase
    {
        private readonly IConexionDelegacionesServices _conexiondelegacionservices;
        public DelegacionDbController(IConexionDelegacionesServices conexionDelegacionesServices  )
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


    }
}

