using BE_DashBoard.Models;
using Microsoft.AspNetCore.Mvc;

namespace BE_DashBoard.Interfaces
{
    public interface IrncEstadoService
    {
        public IEnumerable<RncEstado> GetRncEstados();
        public IEnumerable<RncEstado> GetRncEstadosBy(string rnc, int AmbienteID, int CanalID);

        IActionResult UpdaterncEstado(string rnc, RncEstado updateDelegaciones);
    }
}
