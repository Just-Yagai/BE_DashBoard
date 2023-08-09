using BE_DashBoard.Models;
using Microsoft.AspNetCore.Mvc;

namespace BE_DashBoard.Interfaces
{
    public interface IMarcasService
    {
        IEnumerable<Marcas> GetMarcas();
        IEnumerable<Marcas> GetMarcasBy(string rnc, int AmbienteID, int CanalID);
        IActionResult UpdateMarcas(string rnc, Marcas updateMarcas);
    }
}
