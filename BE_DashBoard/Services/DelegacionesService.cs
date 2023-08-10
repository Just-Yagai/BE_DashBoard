using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BE_DashBoard.Services
{
    public class DelegacionesService : IDelegacionesService
    {
        private readonly IPruebaRepositorio _pruebarepositorio;

        public DelegacionesService(IPruebaRepositorio pruebaRepositorio)
        {
            _pruebarepositorio = pruebaRepositorio;
        }
  
        public async Task <IEnumerable<Delegacion>> GetDelegaciones()
        {
            var lista  =  await _pruebarepositorio.GetDelegaciones();
            return lista;
        }

        /* public IEnumerable<Delegacion> GetDelegacionesBy(string rnc, int AmbienteID, int CanalID)
         {
             var response = delegaciones.FindAll(data => data.Rnc == rnc && data.AmbienteID == AmbienteID && data.CanalID == CanalID);
             return response;
         }

         public IActionResult UpdateDelegaciones(string rnc, Delegacion updateDelegaciones)
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
