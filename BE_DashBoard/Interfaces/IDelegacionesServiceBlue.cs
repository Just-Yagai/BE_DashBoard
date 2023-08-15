using BE_DashBoard.Models;

namespace BE_DashBoard.Interfaces
{
    public interface IDelegacionesServiceBlue
    {
        Task<IEnumerable<Delegacion>> GetDelegacionesBlue();
    }
}
