using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;

namespace BE_DashBoard.Services
{
    public class DelegacionesService : IDelegacionesService
    {
        private readonly IPruebaRepositorio _pruebarepositorio;
      //  private readonly IPruebaRepositorioBlue _pruebaRepositorioBlue;

        public DelegacionesService()
        {
            //_pruebarepositorio = pruebaRepositorio;
            //_pruebaRepositorioBlue = pruebaRepositorioBlue;
        }
  
        public async Task <IEnumerable<Delegacion>> GetDelegaciones()
        {
            //var lista  =  await _pruebarepositorio.GetDelegaciones();
            //return lista;
            return null;
        }

       /* public async Task<IEnumerable<Delegacion>> GetDelegacionesBlue()
        {
            var lista2 = await _pruebaRepositorioBlue.GetDelegaciones();
            return lista2;
        }*/

        /* public IEnumerable<Delegaciones> GetDelegacionesBy(string rnc, int AmbienteID, int CanalID)
         {
             var response = delegaciones.FindAll(data => data.Rnc == rnc && data.AmbienteID == AmbienteID && data.CanalID == CanalID);
             return response;
         }

         public IActionResult UpdateDelegaciones(string rnc, Delegaciones updateDelegaciones)
             {
                 var DelegacionesUpdate = delegaciones.FirstOrDefault(data => data.Rnc == rnc);

                 if (DelegacionesUpdate == null)
                 {
                     return new NoContentResult();
                 }

             DelegacionesUpdate.FirmanteAutorizado = updateDelegaciones.FirmanteAutorizado;
             DelegacionesUpdate.SolicitanteAutorizado = updateDelegaciones.SolicitanteAutorizado;
             DelegacionesUpdate.AprobadorComercial = updateDelegaciones.AprobadorComercial;
             DelegacionesUpdate.Administrador = updateDelegaciones.Administrador;
             DelegacionesUpdate.Estado = updateDelegaciones.Estado;

                 string jsonFilePath = "Data/delegaciones.json";
                 string jsonString = JsonSerializer.Serialize(delegaciones);
                 System.IO.File.WriteAllText(jsonFilePath, jsonString);

                 return new OkResult();
             }*/
    }
}
