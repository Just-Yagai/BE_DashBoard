using BE_DashBoard.Models;
using System.Linq.Expressions;

namespace BE_DashBoard.Interfaces
{
    public interface IPruebaRepositorio
    {
        Task<IEnumerable<Delegacion>> GetDelegaciones(Expression<Func<Delegacion, bool>> expresion);

    }
}
