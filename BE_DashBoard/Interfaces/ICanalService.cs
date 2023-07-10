using BE_DashBoard.Models;

namespace BE_DashBoard.Interfaces
{
    public interface ICanalService
    {
        IEnumerable<Canal> GetCanal();
    }
}
