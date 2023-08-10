using BE_DashBoard.Models;

namespace BE_DashBoard.Services
{
    public interface IDelegacionesService
    {
        Task<IEnumerable<Delegacion>> GetDelegaciones();
    }
}