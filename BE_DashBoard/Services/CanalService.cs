using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using System.Text.Json;

namespace BE_DashBoard.Services
{
    public class CanalService : ICanalService
    {

        private readonly List<Canal> canal;
        public CanalService()
        {
            canal = new List<Canal>();

            string jsonFilePath = "Data/canal.json";
            string jsonString = System.IO.File.ReadAllText(jsonFilePath);
            canal = JsonSerializer.Deserialize<List<Canal>>(jsonString);
        }

        public IEnumerable<Canal> GetCanal()
        {
            return canal;
        }
    }
}
