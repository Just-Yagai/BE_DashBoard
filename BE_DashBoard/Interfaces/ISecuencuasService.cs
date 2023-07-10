using BE_DashBoard.Models;

namespace BE_DashBoard.Interfaces
{
    public interface ISecuencuasService
    {
        IEnumerable<Secuencias> GetSecuencias();
        IEnumerable<Secuencias> GetSecuenciasRnc(string rnc, int AmbienteID, int CanalID, int TipoECF);
    }
}
