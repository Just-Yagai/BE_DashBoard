using BE_DashBoard.Models;

namespace BE_DashBoard.Services
{
    public interface ISecuencuasService
    {
        IEnumerable<Secuencias> GetContribuyentesByRnc(string rnc, int AmbienteID, int CanalID, int TipoECF);
    }
}
