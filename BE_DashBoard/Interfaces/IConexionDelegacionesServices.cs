using BE_DashBoard.ClaseEnumerable;
using BE_DashBoard.Models;


namespace BE_DashBoard.Interfaces
{
    public interface IConexionDelegacionesServices
    {
        Task<IEnumerable<Delegacion>> GetDelegaciones(AmbienteEnum.DbType ambiente, string rnc, int canal);
    }
}
