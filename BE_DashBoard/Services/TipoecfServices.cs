using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using System.Text.Json;

namespace BE_DashBoard.Services
{
    public class TipoecfServices : ITipoecfService
    {

        private readonly List<TipoEcf> tipo;
        public TipoecfServices()
        {
            tipo = new List<TipoEcf>();

            string jsonFilePath = "Data/tipoecf.json";
            string jsonString = System.IO.File.ReadAllText(jsonFilePath);
            tipo = JsonSerializer.Deserialize<List<TipoEcf>>(jsonString);
        }
        public IEnumerable<TipoEcf> GetTipoEcf()
        {
            return tipo;
        }
    }
}
