using BE_DashBoard.Context;
using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BE_DashBoard.Repositorio
{
    public class PruebaRepositorioBlue : IPruebaRepositorio
    {
        private readonly AplicacionDbContextBlue _dbcontextblue;

        public PruebaRepositorioBlue(AplicacionDbContextBlue dbcontextblue)
        {
            this._dbcontextblue = dbcontextblue;
        }
        public async Task<IEnumerable<Delegacion>> GetDelegaciones(Expression<Func<Delegacion, bool>> expresion)
        {
            var ListarDatos = await _dbcontextblue.Delegaciones.Where(expresion).AsNoTracking().ToListAsync();
            return ListarDatos;
        }
    }
}

