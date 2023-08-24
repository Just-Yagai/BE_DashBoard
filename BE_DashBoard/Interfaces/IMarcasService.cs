using BE_DashBoard.Models;
using BE_DashBoard.Services;
using Microsoft.AspNetCore.Mvc;
using static BE_DashBoard.Services.MarcasService;
using static BE_DashBoard.Services.RncEstadosService;

namespace BE_DashBoard.Interfaces
{
    public interface IMarcasService
    {
        //IEnumerable<Marcas> GetMarcas();
        Task<IEnumerable<Marcas>> GetMarcasBy(DbType3 ambiente, string rnc, int CanalID);
       // IActionResult UpdateMarcas(string rnc, Marcas updateMarcas);
    }
}
