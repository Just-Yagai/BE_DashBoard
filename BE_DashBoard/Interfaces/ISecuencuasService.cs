using BE_DashBoard.Models;
using BE_DashBoard.Services;
using System.Data;

namespace BE_DashBoard.Interfaces
{
    public interface ISecuencuasService
    {
        //IEnumerable<Secuencias> GetSecuenciasRnc(string rnc, int AmbienteID, int CanalID, int TipoECF);

        Task<IEnumerable<Secuencias>> GetSecuencias(DbType1 ambiente, string rnc, int CanalID, int TipoECF);
    }
}
