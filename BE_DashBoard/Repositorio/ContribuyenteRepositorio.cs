using BE_DashBoard.Context;
using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace BE_DashBoard.Repositorio
{
    public class ContribuyenteRepositorio : IContribuyentesService
    {
        private readonly AplicacionDbContext _dbcontext;

        public ContribuyenteRepositorio(AplicacionDbContext context)
        {
            _dbcontext = context;
        }

        public async Task<IEnumerable<Contribuyente>> GetContribuyente(Expression<Func<Contribuyente, bool>> expresion)
        {
            var ListarDatos = await _dbcontext.Contribuyentes.Where(expresion).AsNoTracking().ToListAsync();
            return ListarDatos;
        }

        public IQueryable<Contribuyente> GetAllContribuyentes()
        {
            return _dbcontext.Contribuyentes.Include(c => c.TiposCertificacion);
        }
    }
}
