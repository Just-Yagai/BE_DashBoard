using PB_Dashboard.Models;

namespace BE_DashBoard.Interfaces
{
    public interface ICredenciales
    {
        IEnumerable<UsersModel>GetUsers();
    }
}
