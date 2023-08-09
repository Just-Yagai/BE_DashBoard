using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using System.Text.Json;

namespace BE_DashBoard.Services
{
    public class ContribuyentesService : IContribuyentesService
    {
        private readonly List<Contribuyente> contribuyentes;

        public ContribuyentesService()
        {
            contribuyentes = new List<Contribuyente>();

            string jsonFilePath = "Data/contribuyentes.json";
            string jsonString = System.IO.File.ReadAllText(jsonFilePath);
            contribuyentes = JsonSerializer.Deserialize<List<Contribuyente>>(jsonString);
        }

        public IEnumerable<Contribuyente> GetContribuyentesByRnc(string rnc)
        {
            var response = contribuyentes.FindAll(data => data.rnc == rnc);
            return response;
        }
    }
}
