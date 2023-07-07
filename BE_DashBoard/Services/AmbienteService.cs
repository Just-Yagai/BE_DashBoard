using BE_DashBoard.Models;
using System.Text.Json;

namespace BE_DashBoard.Services
{
    public class AmbienteService : IAmbienteService
    {
        public readonly List<Ambiente> ambiente;
        

        public AmbienteService()
        {
            ambiente = new List<Ambiente>();

            string jsonFilePath = "Data/ambiente.json";
            string jsonString = System.IO.File.ReadAllText(jsonFilePath);
            ambiente = JsonSerializer.Deserialize<List<Ambiente>>(jsonString);
        }

        public IEnumerable<Ambiente> GetAmbiente()
        {
            return ambiente;
        }
    }
}
