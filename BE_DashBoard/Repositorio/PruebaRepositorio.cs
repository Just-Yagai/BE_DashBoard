using BE_DashBoard.Context;
using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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

        public async Task<IEnumerable<Secuencias>> Getsecuencia(Expression<Func<Secuencias, bool>> expresion)
        {
            var ListarDatos = await _dbcontext.Secuencias.Where(expresion).AsNoTracking().ToListAsync();
            return ListarDatos;
        }

        public async Task<IEnumerable<RncEstado>> GetRncEstado(Expression<Func<RncEstado, bool>> expresion)
        {
            var ListarDatos = await _dbcontext.RncEstados.Where(expresion).AsNoTracking().ToListAsync();
            return ListarDatos;
        }

        public async Task<IEnumerable<Contribuyente>> GetContribuyente(Expression<Func<Contribuyente, bool>> expresion)
        {
            var ListarDatos = await _dbcontext.Contribuyente.Where(expresion).AsNoTracking().ToListAsync();
            return ListarDatos;
        }

        public IQueryable<Contribuyente> GetAllContribuyentes()
        {
            return _dbcontext.Contribuyente.Include(c => c.TiposCertificacion);
        }
    }
}
