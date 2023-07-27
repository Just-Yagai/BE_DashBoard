using BE_DashBoard.Models;
using Microsoft.AspNetCore.Mvc;

namespace BE_DashBoard.Interfaces
{
    public interface IDelegaciones
    {
        IEnumerable<Delegaciones> GetDelegaciones();
        IEnumerable<Delegaciones> GetDelegacionesBy(string rnc, int AmbienteID, int CanalID);
        IActionResult UpdateDelegaciones(string rnc, Delegaciones updateDelegaciones);
    }
}
