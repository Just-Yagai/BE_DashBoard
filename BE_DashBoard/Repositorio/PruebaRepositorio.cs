using BE_DashBoard.Context;
using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public async Task<PageResult<Secuencias>> Getsecuencia(Expression<Func<Secuencias, bool>> expresion, int pagesNumber, int pagesSize)
        {
            var offsellrow = (pagesNumber - 1) * pagesSize;
            var cantidad = await _dbcontext.Secuencias.CountAsync(expresion);

            var ListarDatos = await _dbcontext.Secuencias
                .Where(expresion)
                .Skip(offsellrow)
                .Take(pagesSize)
                .AsNoTracking()
                .ToListAsync();

            return new PageResult<Secuencias>
            {
                Result = ListarDatos,
                Paginacion = new Paginacion
                {
                    NumeroPagina = pagesNumber,
                    SizePagina = pagesSize,
                    TotalElementos = cantidad
                }
            };
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

        public async Task<IEnumerable<Marcas>> GetMarcas(Expression<Func<Marcas, bool>> expresion)
        {
            var ListarDatos = await _dbcontext.Marcas.Where(expresion).AsNoTracking().ToListAsync();
            return ListarDatos;
        }

    }
}
