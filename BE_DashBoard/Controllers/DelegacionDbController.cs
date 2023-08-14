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
        private readonly IDelegacionesService _delegacionservices;
        public DelegacionDbController(IDelegacionesService delegacion )
        {
            _delegacionservices = delegacion;
        }

        [HttpGet]
        [Route("ObtenerDelegacionesDb")]
        public async Task<IActionResult> GetDelegacioniones()
        {
                var lisdelegaciones = await _delegacionservices.GetDelegaciones();
                return Ok(lisdelegaciones);
        }
    }
}

