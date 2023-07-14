using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
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

<<<<<<< HEAD
        //hola esto es prueba de branch
        // Probando el branch ...
=======
        //hola esto es prueba de branch2 ya tu sabe.
>>>>>>> origin/prueba2

        public IEnumerable<RncEstado> GetRncEstadosBy(string rnc, int AmbienteID, int CanalID)
        {
            var response = rncEstado.FindAll(data => data.rnc == rnc && data.AmbienteID == AmbienteID && data.CanalID == CanalID);
            return response;
        }

        

    }
}
