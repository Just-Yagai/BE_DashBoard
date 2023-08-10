using BE_DashBoard.Interfaces;
using BE_DashBoard.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BE_DashBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DelegacionDbController : ControllerBase
    {
        private readonly IDelegacionesService _delegacion;
        public DelegacionDbController(IDelegacionesService delegacion )
        {
            _delegacion = delegacion;
        }

        [HttpGet]
        [Route("ObtenerDelegacionesDb")]
        public async Task<IActionResult> GetDelegacioniones()
        {
                var lisdelegaciones = await _delegacion.GetDelegaciones();
                return Ok(lisdelegaciones);
        }
    }
}

