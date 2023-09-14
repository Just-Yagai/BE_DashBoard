using BE_DashBoard.Models;

namespace BE_DashBoard.Interfaces
{
    public interface ITipoecfService
    {
        IEnumerable<TipoEcf> GetTipoEcf();
    }
}
