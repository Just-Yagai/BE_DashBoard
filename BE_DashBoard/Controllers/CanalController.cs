using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_DashBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanalController : ControllerBase
    {
        private readonly ICanalService _canalService;

        public CanalController(ICanalService canalService)
        {
            _canalService = canalService;
        }

        [HttpGet]
        [Route("ObtenerCanal")]
        public IEnumerable<Canal> Get()
        {
            return _canalService.GetCanal();
        }
    }
}
