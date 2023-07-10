using BE_DashBoard.Models;

namespace BE_DashBoard.Interfaces
{
    public interface IAmbienteService
    {
        IEnumerable<Ambiente> GetAmbiente();
    }
}
