using BE_DashBoard.Models;

namespace BE_DashBoard.Interfaces
{
    public interface IrncEstado
    {
        public IEnumerable<RncEstado> GetRncEstados();
        public IEnumerable<RncEstado> GetRncEstadosBy(string rnc, int AmbienteID, int CanalID);
    }
}
