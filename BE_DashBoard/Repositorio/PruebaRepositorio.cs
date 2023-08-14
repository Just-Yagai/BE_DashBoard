using BE_DashBoard.Context;
using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_DashBoard.Repositorio
{
    public class PruebaRepositorio : IPruebaRepositorio
    {
        private readonly AplicacionDbContext _dbcontext;
    
        public PruebaRepositorio(AplicacionDbContext context )
        {
            _dbcontext = context;
        }

        public async Task<IEnumerable<Delegacion>> GetDelegaciones()
        {
            var ListarDatos = await _dbcontext.Delegaciones.AsNoTracking().ToListAsync();
            return ListarDatos;
        }
    }
}
