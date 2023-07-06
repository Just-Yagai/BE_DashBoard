using BE_DashBoard.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BE_DashBoard.Services
{
    public class MarcasService : IMarcasService
    {
        private readonly List<Marcas> marcas;
        public MarcasService()
        {
            marcas = new List<Marcas>();

            string jsonFilePath = "Data/marcas.json";
            string jsonString = System.IO.File.ReadAllText(jsonFilePath);
            marcas = JsonSerializer.Deserialize<List<Marcas>>(jsonString);
        }

        // Metodo Obtener Todas las marcas
        public IEnumerable<Marcas> GetMarcas()
        {
            // string jsonFilePath = "Data/marcas.json";
            // string jsonString = System.IO.File.ReadAllText(jsonFilePath);

            // var marcas = JsonSerializer.Deserialize<IEnumerable<Marcas>>(jsonString);
            return marcas;
        }

        // Metodo Obtener por RNC, AmbienteID , CanalID
        public IEnumerable <Marcas> GetMarcasBy(string rnc, int AmbienteID, int CanalID) 
        {
            var response = marcas.FindAll(data => data.rnc == rnc && data.AmbienteID == AmbienteID && data.CanalID == CanalID);
            return response;
        }

        // Metodo Actualizar Marcas Por Estado
        public IActionResult UpdateMarcas(string rnc, [FromBody]Marcas updateMarcas)
        {
            var marcaUpdate = marcas.FirstOrDefault(data => data.rnc == rnc);
            
            if (marcaUpdate == null)
            {
                return new NotFoundResult();
            }

            marcaUpdate.estado = updateMarcas.estado;

            string jsonFilePath = "Data/marcas.json";
            string jsonString = JsonSerializer.Serialize(marcas);
            System.IO.File.WriteAllText(jsonFilePath, jsonString);

            return new OkResult();
        }
    }
}
