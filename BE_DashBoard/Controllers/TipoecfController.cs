using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_DashBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoecfController : ControllerBase
    {
        private readonly ITipoecfService _TipoecfService;

        public TipoecfController(ITipoecfService TipoecfService)
        {
            _TipoecfService = TipoecfService;
        }

        //[Obsolete]
        [HttpGet]
        [Route("ObtenerTipoEcf")]
        public IEnumerable<TipoEcf> Get()
        {
            return _TipoecfService.GetTipoEcf();
        }
    }
}
