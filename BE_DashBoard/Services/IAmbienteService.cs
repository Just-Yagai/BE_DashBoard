using BE_DashBoard.Models;

namespace BE_DashBoard.Services
{
    public interface IAmbienteService
    {
        IEnumerable<Ambiente> GetAmbiente();
    }
}
