using BE_DashBoard.ClaseEnumerable;
using BE_DashBoard.Models;
using Microsoft.AspNetCore.Mvc;

namespace BE_DashBoard.Interfaces
{
    public interface IrncEstadoService
    {
        //  public IEnumerable<RncEstado> GetRncEstados();
        // public IEnumerable<RncEstado> GetRncEstadosBy(string rnc, int AmbienteID, int CanalID);
        //Task<IActionResult> put(string rnc, RncEstado updateDelegaciones);

        Task<IEnumerable<RncEstado>> GetRncEstado(AmbienteEnum.DbType ambiente, string rnc, int canal);
         Task<RncEstado> ActualizarRncEstado(string rnc, RncEstado updaterncEstado, int ambiente);
    }
}
