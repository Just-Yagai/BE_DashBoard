using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using PB_Dashboard.Models;
using System.Text.Json;

namespace BE_DashBoard.Services
{
    public class CredencialesServices : ICredenciales
    {

        private readonly List<UsersModel> user;
        public CredencialesServices()
        {
            user = new List<UsersModel>();

            string jsonFilePath = "Data/autenticacion.json";
            string jsonString = System.IO.File.ReadAllText(jsonFilePath);
            user = JsonSerializer.Deserialize<List<UsersModel>>(jsonString);
        }

        public IEnumerable<UsersModel> GetUsers()
        {
            return user;
        }
    }
}
