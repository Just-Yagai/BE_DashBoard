using BE_DashBoard.ClaseEnumerable;
using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using static BE_DashBoard.ClaseEnumerable.AmbienteEnum;

namespace BE_DashBoard.Services
{
    public class RncEstadosService : IrncEstadoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RncEstadosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<RncEstado>> GetRncEstado(AmbienteEnum.DbType ambiente, string rnc, int canal)
        {
            switch (ambiente)
            {
                case DbType.Produccion:
                    return await this._unitOfWork.PruebaRepositorio.GetRncEstado(a => a.Rnc == rnc && a.CanalID == canal && a.AmbienteID == (int)ambiente);
                case DbType.PreCertificacion:
                    return await this._unitOfWork.PruebaRepositorioBlue.GetRncEstado(a => a.Rnc == rnc && a.CanalID == canal && a.AmbienteID == (int)ambiente);
                default:
                    return await this._unitOfWork.PruebaRepositorio.GetRncEstado(a => a.Rnc == rnc && a.CanalID == canal && a.AmbienteID == (int)ambiente);
            }
        }

        /*
        public readonly List<RncEstado> rncEstado;


        public RncEstadosService()
        {
            rncEstado = new List<RncEstado>();

            var jsonpath = "Data/rnc-estado.json";
            var conver = System.IO.File.ReadAllText(jsonpath);
            rncEstado = JsonSerializer.Deserialize<List<RncEstado>>(conver);

        }
        public IEnumerable<RncEstado> GetRncEstados()
        {
            return rncEstado;
        }

        public IEnumerable<RncEstado> GetRncEstadosBy(string rnc, int AmbienteID, int CanalID)
        {
            var response = rncEstado.FindAll(data => data.rnc == rnc && data.AmbienteID == AmbienteID && data.CanalID == CanalID);
            return response;
        }

        public IActionResult UpdaterncEstado(string rnc, RncEstado updaterncEstado)
        {
            var rncEstadoUpdate = rncEstado.FirstOrDefault(data => data.rnc == rnc);

            if (rncEstadoUpdate == null)
            {
                return new NoContentResult();
            }

            rncEstadoUpdate.estado = updaterncEstado.estado;
            rncEstadoUpdate.autorizadoAFacturar = updaterncEstado.autorizadoAFacturar;
            rncEstadoUpdate.autorizadoSolicitarSecuencia = updaterncEstado.autorizadoSolicitarSecuencia;
            rncEstadoUpdate.esGrandeContribuyente = updaterncEstado.esGrandeContribuyente;
            

            string jsonFilePath = "Data/rnc-estado.json";
            string jsonString = JsonSerializer.Serialize(rncEstado);
            System.IO.File.WriteAllText(jsonFilePath, jsonString);

            return new OkResult();
        }*/

    }
}
