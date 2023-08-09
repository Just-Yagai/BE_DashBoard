using PB_Dashboard.Models;

namespace BE_DashBoard.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(LoginUser _loginUser);
    }
}
