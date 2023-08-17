using BE_DashBoard.Models;
using System.Linq.Expressions;

namespace BE_DashBoard.Interfaces
{
    public interface IContribuyentesService
    {
        IQueryable<Contribuyente> GetAllContribuyentes();
        Task<IEnumerable<Contribuyente>> GetContribuyente(Expression<Func<Contribuyente, bool>> expresion);
    }
}
