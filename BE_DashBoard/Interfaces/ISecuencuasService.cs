using BE_DashBoard.ClaseEnumerable;
using BE_DashBoard.Models;

namespace BE_DashBoard.Interfaces
{
    public interface ISecuencuasService
    {
        Task<PageResult<Secuencias>> GetSecuencias(AmbienteEnum.DbType ambiente, string rnc, int CanalID, int TipoECF, int pageNumber, int pageSize);
    }
}
