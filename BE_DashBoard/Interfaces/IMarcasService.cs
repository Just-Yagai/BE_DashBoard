using BE_DashBoard.ClaseEnumerable;
using BE_DashBoard.Models;


namespace BE_DashBoard.Interfaces
{
    public interface IMarcasService
    {
        //IEnumerable<Marcas> GetMarcas();
        Task<IEnumerable<Marcas>> GetMarcasBy(AmbienteEnum.DbType ambiente, string rnc, int CanalID);
        Task<Marcas> ActualizarMarcas(string Rnc, Marcas updateMarcas, int ambiente);
    }
}
