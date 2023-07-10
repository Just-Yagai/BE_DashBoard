using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using System.Text.Json;

namespace BE_DashBoard.Services
{
    public class DelegacionesService : IDelegaciones
    {
        public readonly List<Delegaciones> delegaciones;

        public DelegacionesService()
        {
            delegaciones = new List<Delegaciones>();

            string jsonFilePath = "Data/delegaciones.json";
            string jsonString = System.IO.File.ReadAllText(jsonFilePath);
            delegaciones = JsonSerializer.Deserialize<List<Delegaciones>>(jsonString);

        }

        public IEnumerable<Delegaciones> GetDelegaciones()
        {
            return delegaciones;
        }

        public IEnumerable<Delegaciones> GetDelegacionesBy(string rnc, int AmbienteID, int CanalID)
        {
            var response = delegaciones.FindAll(data => data.rnc == rnc && data.AmbienteID == AmbienteID && data.CanalID == CanalID);
            return response;
        }
    }
}
