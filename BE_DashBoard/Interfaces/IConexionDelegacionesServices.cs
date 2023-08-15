using BE_DashBoard.Models;
using BE_DashBoard.Services;

namespace BE_DashBoard.Interfaces
{
    public interface IConexionDelegacionesServices
    {
        Task<IEnumerable<Delegacion>> GetDelegaciones(DbType ambiente, string rnc, int canal);
    }
}
