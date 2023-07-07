using BE_DashBoard.Models;

namespace BE_DashBoard.Services
{
    public interface ICanalService
    {
        IEnumerable<Canal> GetCanal();
    }
}
