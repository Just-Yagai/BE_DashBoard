using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using BE_DashBoard.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BE_DashBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContribuyenteController : ControllerBase
    {
       private readonly IConexionContribuyenteService _conexionContribuyenteService;
        public ContribuyenteController(IConexionContribuyenteService conexionContribuyenteService)
        {
            _conexionContribuyenteService = conexionContribuyenteService;
        }

        [HttpGet]
        [Route("ObtenerContribuyente")]
        public async Task<IActionResult> GetContribuyente( string rnc)
        {
            var contribuyentes = await _conexionContribuyenteService.GetContribuyente(rnc);

            if (contribuyentes == null)
            {
                return NotFound();
            }
            return Ok(contribuyentes);
        }

        [HttpGet]
        public async Task <IActionResult> GetAllContribuyentes()
        {
            var contribuyentes = await _conexionContribuyenteService.GetAllContribuyentes().ToListAsync();
            return Ok(contribuyentes);
        }
    }
}
