using BE_DashBoard.Context;
using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BE_DashBoard.Repositorio
{
    public class PruebaRepositorio : IPruebaRepositorio
    {
        private readonly AplicacionDbContext _dbcontext;
    
        public PruebaRepositorio(AplicacionDbContext context)
        {
            _dbcontext = context;
        }

        public async Task<IEnumerable<Delegacion>> GetDelegaciones(Expression<Func<Delegacion, bool>> expresion)
        {
            var ListarDatos = await _dbcontext.Delegaciones.Where(expresion).AsNoTracking().ToListAsync();
            return ListarDatos;
        }

       
    }
}
