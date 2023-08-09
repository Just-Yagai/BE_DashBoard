using BE_DashBoard.Interfaces;
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

        public IEnumerable<Marcas> GetMarcas() 
        {
            return marcas;
        }

        public IEnumerable <Marcas> GetMarcasBy(string rnc, int AmbienteID, int CanalID) 
        {
            var response = marcas.FindAll(data => data.rnc == rnc && data.AmbienteID == AmbienteID && data.CanalID == CanalID);
            return response;
        }

        public IActionResult UpdateMarcas(string rnc, Marcas updateMarcas)
        {
            string claveBusqueda = rnc + "" + updateMarcas.tipo;

            var marcaUpdate = marcas.FirstOrDefault(data => (data.rnc + "" + data.tipo) == claveBusqueda);

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
