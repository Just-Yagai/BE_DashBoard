using BE_DashBoard.Models;

namespace BE_DashBoard.Interfaces
{
    public interface IDelegaciones
    {
        IEnumerable<Delegaciones> GetDelegaciones();
        IEnumerable<Delegaciones> GetDelegacionesBy(string rnc, int AmbienteID, int CanalID);
    }
}
