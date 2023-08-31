using BE_DashBoard.ClaseEnumerable;
using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using static BE_DashBoard.ClaseEnumerable.AmbienteEnum;


namespace BE_DashBoard.Services
{
    public class MarcasService : IMarcasService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MarcasService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Marcas>> GetMarcasBy(AmbienteEnum.DbType ambiente, string rnc, int canal)
        {

            switch (ambiente)
            {
                case DbType.Produccion:
                    return await this._unitOfWork.PruebaRepositorio.GetMarcas(a => a.Rnc == rnc && a.CanalID == canal && a.AmbienteID == (int)ambiente);
                case DbType.PreCertificacion:
                    return await this._unitOfWork.PruebaRepositorioBlue.GetMarcas(a => a.Rnc == rnc && a.CanalID == canal && a.AmbienteID == (int)ambiente);
                default:
                    return await this._unitOfWork.PruebaRepositorio.GetMarcas(a => a.Rnc == rnc && a.CanalID == canal && a.AmbienteID == (int)ambiente);
            }

        }

        /*private readonly List<Marcas> marcas;
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

        }*/

    }
}

