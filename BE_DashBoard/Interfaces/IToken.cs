using PB_Dashboard.Models;

namespace BE_DashBoard.Interfaces
{
    public interface IToken
    {
        public string GenerateToken(LoginUser _loginUser);
    }
}
