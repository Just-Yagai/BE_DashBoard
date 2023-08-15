using BE_DashBoard.Context;
using BE_DashBoard.Interfaces;
using BE_DashBoard.Repositorio;

namespace BE_DashBoard.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly AplicacionDbContext _dbcontext;
        private readonly AplicacionDbContextBlue _dbcontextBlue;
        public UnitOfWork(AplicacionDbContext dbcontext, AplicacionDbContextBlue dbcontextBlue) 
        { 
            this._dbcontext = dbcontext;
            this._dbcontextBlue = dbcontextBlue;
        }

        public IPruebaRepositorio PruebaRepositorio => new PruebaRepositorio(_dbcontext);

        public IPruebaRepositorio PruebaRepositorioBlue => new PruebaRepositorioBlue(_dbcontextBlue);
    }
}
