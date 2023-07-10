using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using System.Text.Json;

namespace BE_DashBoard.Services
{
    public class SecuenciasService : ISecuencuasService
    {

        public readonly List<Secuencias> Secuencias;

        public SecuenciasService()
        {
            Secuencias = new List<Secuencias>();

            var jsonFilePath = "Data/secuencias.json";
            var jsonString = System.IO.File.ReadAllText(jsonFilePath);
            Secuencias = JsonSerializer.Deserialize<List<Secuencias>>(jsonString);

        }

        public IEnumerable<Secuencias> GetSecuencias() {    

            return Secuencias;
 
        }

        public IEnumerable<Secuencias> GetSecuenciasRnc(string rnc, int AmbienteID, int CanalID, int TipoECF)
        {
            var response = Secuencias.FindAll(data => data.rnc == rnc && data.AmbienteID == AmbienteID && data.CanalID == CanalID && (TipoECF != 0 ? data.TipoECF == TipoECF: true));
            return response;
        }
    }
}
