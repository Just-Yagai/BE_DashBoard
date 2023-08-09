using BE_DashBoard.Models;

namespace BE_DashBoard.Interfaces
{
    public interface IContribuyentesService
    {
        IEnumerable<Contribuyente> GetContribuyentesByRnc(string rnc);
    }
}
