using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BE_DashBoard.Services
{
    public class RncEstadosService: IrncEstado
    {

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
        }
    }
}
