using BE_DashBoard.Models;
using BE_DashBoard.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_DashBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmbienteController : ControllerBase
    {
        private readonly IAmbienteService _AmbienteService;

        public AmbienteController(IAmbienteService ambienteService)
        {
            _AmbienteService = ambienteService;
        }

        [HttpGet]
        [Route("ObtenerCanal")]
        public IEnumerable<Ambiente> Get()
        {
            return _AmbienteService.GetAmbiente();
        }
    }
}
