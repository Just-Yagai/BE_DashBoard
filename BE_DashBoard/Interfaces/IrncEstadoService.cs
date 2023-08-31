using BE_DashBoard.ClaseEnumerable;
using BE_DashBoard.Models;

namespace BE_DashBoard.Interfaces
{
    public interface IrncEstadoService
    {
        //  public IEnumerable<RncEstado> GetRncEstados();
        // public IEnumerable<RncEstado> GetRncEstadosBy(string rnc, int AmbienteID, int CanalID);
        //IActionResult UpdaterncEstado(string rnc, RncEstado updateDelegaciones);

        Task<IEnumerable<RncEstado>> GetRncEstado(AmbienteEnum.DbType ambiente, string rnc, int canal);
    }
}
