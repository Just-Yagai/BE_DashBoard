using BE_DashBoard.Models;
using BE_DashBoard.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_DashBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContribuyenteController : ControllerBase
    {
        private readonly IContribuyentesService _contribuyentesService;
        public ContribuyenteController(IContribuyentesService contribuyentesService)
        {
            _contribuyentesService = contribuyentesService;
        }

        [HttpGet]
        [Route("ObtenerContribuyentes")]
        public IEnumerable <Contribuyentes> Get()
        {
            return _contribuyentesService.GetContribuyentes();
        }
    }
}
