using BE_DashBoard.Models;
using System.Linq.Expressions;

namespace BE_DashBoard.Interfaces
{
    public interface IPruebaRepositorio
    {
        Task<IEnumerable<Delegacion>> GetDelegaciones(Expression<Func<Delegacion, bool>> expresion);
        Task<IEnumerable<Secuencias>> Getsecuencia(Expression<Func<Secuencias, bool>> expresion);
        Task<IEnumerable<RncEstado>> GetRncEstado(Expression<Func<RncEstado, bool>> expresion);
        IQueryable<Contribuyente> GetAllContribuyentes();
        Task<IEnumerable<Contribuyente>> GetContribuyente(Expression<Func<Contribuyente, bool>> expresion);
    }
}
