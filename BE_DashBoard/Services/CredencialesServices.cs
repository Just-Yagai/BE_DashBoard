using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using PB_Dashboard.Models;
using System.Text.Json;

namespace BE_DashBoard.Services
{
    public class CredencialesServices : ICredenciales
    {

        private readonly List<LoginUser> user;
        public CredencialesServices()
        {
            user = new List<LoginUser>();

            string jsonFilePath = "Data/autenticacion.json";
            string jsonString = System.IO.File.ReadAllText(jsonFilePath);
            user = JsonSerializer.Deserialize<List<LoginUser>>(jsonString);
        }

        public IEnumerable<LoginUser> GetUsers()
        {
            return user;
        }

        public IEnumerable<LoginUser> GetAutentication(string username, string password)
        {
           var response = user.FindAll(data => data.Username == username && data.Password == password);
            return response;
        }
    }
}
