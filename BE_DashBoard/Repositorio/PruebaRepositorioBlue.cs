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

        public async Task<IEnumerable<Secuencias>> Getsecuencia(Expression<Func<Secuencias, bool>> expresion)
        {
            var ListarDatos = await _dbcontextblue.Secuencias.Where(expresion).AsNoTracking().ToListAsync();
            return ListarDatos;
        }

        public async Task<IEnumerable<RncEstado>> GetRncEstado(Expression<Func<RncEstado, bool>> expresion)
        {
            var ListarDatos = await _dbcontextblue.RncEstados.Where(expresion).AsNoTracking().ToListAsync();
            return ListarDatos;
        }

        public async Task<IEnumerable<Contribuyente>> GetContribuyente(Expression<Func<Contribuyente, bool>> expresion)
        {
            var ListarDatos = await _dbcontextblue.Contribuyente.Include(c => c.TiposCertificacion).Where(expresion).AsNoTracking().ToListAsync();
            return ListarDatos;
        }

        public IQueryable<Contribuyente> GetAllContribuyentes()
        {
            return _dbcontextblue.Contribuyente.Include(c => c.TiposCertificacion);
        }
    }
}

