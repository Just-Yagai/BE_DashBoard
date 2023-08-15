using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using BE_DashBoard.Repositorio;

namespace BE_DashBoard.Services
{
    public class DelegacionesServiceBlue : IDelegacionesServiceBlue
    {
        private readonly IPruebaRepositorioBlue _pruebaRepositorioBlue;

        public DelegacionesServiceBlue()
        {
            //_pruebaRepositorioBlue = pruebaRepositorioblue;
        }
        public async Task<IEnumerable<Delegacion>> GetDelegacionesBlue()
        {
            //var lista2 = await _pruebaRepositorioBlue.GetDelegaciones();
            //return lista2;
            return null;
        }
    }
}
