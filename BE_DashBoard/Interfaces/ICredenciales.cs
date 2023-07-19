using PB_Dashboard.Models;

namespace BE_DashBoard.Interfaces
{
    public interface ICredenciales
    {
        IEnumerable<LoginUser> GetUsers();
        IEnumerable<LoginUser>GetAutentication(string username, string password);   
    }
}
