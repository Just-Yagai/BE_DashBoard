using BE_DashBoard.Models;

namespace BE_DashBoard.Interfaces
{
    public interface IConexionContribuyenteService
    {
        IQueryable<Contribuyente> GetAllContribuyentes();
        Task<IEnumerable<Contribuyente>> GetContribuyente(string rnc);
    }
}
