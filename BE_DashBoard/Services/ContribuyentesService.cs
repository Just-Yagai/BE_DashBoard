using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using System.Text.Json;

namespace BE_DashBoard.Services
{
    public class ContribuyentesService : IContribuyentesService
    {
        private readonly List<Contribuyentes> contribuyentes;

        public ContribuyentesService()
        {
            contribuyentes = new List<Contribuyentes>();

            string jsonFilePath = "Data/contribuyentes.json";
            string jsonString = System.IO.File.ReadAllText(jsonFilePath);
            contribuyentes = JsonSerializer.Deserialize<List<Contribuyentes>>(jsonString);
        }

        public IEnumerable<Contribuyentes> GetContribuyentesByRnc(string rnc)
        {
            var response = contribuyentes.FindAll(data => data.rnc == rnc);
            return response;
        }
    }
}
