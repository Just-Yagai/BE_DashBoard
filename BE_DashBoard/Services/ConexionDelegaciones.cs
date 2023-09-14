using BE_DashBoard.ClaseEnumerable;
using BE_DashBoard.Context;
using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using Microsoft.EntityFrameworkCore;
using static BE_DashBoard.ClaseEnumerable.AmbienteEnum;

namespace BE_DashBoard.Services
{
    public class ConexionDelegaciones : IConexionDelegacionesServices
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly AplicacionDbContext _dbcontext;
        private readonly AplicacionDbContextBlue _dbcontextBlue;

        public ConexionDelegaciones(IUnitOfWork unitOfWork, AplicacionDbContext dbcontext, AplicacionDbContextBlue dbcontextBlue)
        {
            _unitOfWork = unitOfWork;
            _dbcontext = dbcontext;
            _dbcontextBlue = dbcontextBlue;
        }

        public async Task<IEnumerable<Delegacion>> GetDelegaciones(AmbienteEnum.DbType ambiente, string rnc, int canal)
        {
            switch (ambiente)
            {
                case DbType.Produccion:
                    return await this._unitOfWork.PruebaRepositorio.GetDelegaciones(a => a.Rnc == rnc && a.CanalID == canal && a.AmbienteID == (int)ambiente);
                case DbType.PreCertificacion:
                    return await this._unitOfWork.PruebaRepositorioBlue.GetDelegaciones(a => a.Rnc == rnc && a.CanalID == canal && a.AmbienteID == (int)ambiente);
                default:
                    return await this._unitOfWork.PruebaRepositorio.GetDelegaciones(a => a.Rnc == rnc && a.CanalID == canal && a.AmbienteID == (int)ambiente);
            }
        }
        public async Task<Delegacion> ActualizarDelegaciones(string Rnc, Delegacion updatedelegaciones, int ambiente)
        {
            try
            {
                if (ambiente == (int)DbType.Produccion)
                {
                    var DelegacionUpdate = await _dbcontext.Delegaciones.FirstOrDefaultAsync(r => r.Rnc == Rnc);

                    if (DelegacionUpdate == null)
                    {
                        return null; // Devuelve null si no se encuentra
                    }

                    DelegacionUpdate.FirmanteAutorizado = updatedelegaciones.FirmanteAutorizado;
                    DelegacionUpdate.SolicitanteAutorizado = updatedelegaciones.SolicitanteAutorizado;
                    DelegacionUpdate.AprobadorComercial = updatedelegaciones.AprobadorComercial;
                    DelegacionUpdate.Administrador = updatedelegaciones.Administrador;
                    DelegacionUpdate.Estado = updatedelegaciones.Estado;

                    await _dbcontext.SaveChangesAsync();
                    return DelegacionUpdate;
                }
                else if (ambiente == (int)DbType.PreCertificacion)
                {
                    var DelegacionUpdate = await _dbcontextBlue.Delegaciones.FirstOrDefaultAsync(r => r.Rnc == Rnc);

                    if (DelegacionUpdate == null)
                    {
                        return null; // Devuelve null si no se encuentra
                    }

                    DelegacionUpdate.FirmanteAutorizado = updatedelegaciones.FirmanteAutorizado;
                    DelegacionUpdate.SolicitanteAutorizado = updatedelegaciones.SolicitanteAutorizado;
                    DelegacionUpdate.AprobadorComercial = updatedelegaciones.AprobadorComercial;
                    DelegacionUpdate.Administrador = updatedelegaciones.Administrador;
                    DelegacionUpdate.Estado = updatedelegaciones.Estado;

                    await _dbcontextBlue.SaveChangesAsync();
                    return DelegacionUpdate;
                }
                else if (ambiente == (int)DbType.Certificacion)
                {
                    var DelegacionUpdate = await _dbcontext.Delegaciones.FirstOrDefaultAsync(r => r.Rnc == Rnc);

                    if (DelegacionUpdate == null)
                    {
                        return null; // Devuelve null si no se encuentra
                    }

                    DelegacionUpdate.FirmanteAutorizado = updatedelegaciones.FirmanteAutorizado;
                    DelegacionUpdate.SolicitanteAutorizado = updatedelegaciones.SolicitanteAutorizado;
                    DelegacionUpdate.AprobadorComercial = updatedelegaciones.AprobadorComercial;
                    DelegacionUpdate.Administrador = updatedelegaciones.Administrador;
                    DelegacionUpdate.Estado = updatedelegaciones.Estado;

                    await _dbcontext.SaveChangesAsync();
                    return DelegacionUpdate;
                }
                else
                {
                    return null; // Devuelve null si el ambiente no es válido
                }
            }
            catch (Exception ex)
            {
                // Maneja la excepción según tus necesidades.
                throw ex;
            }
        }

    }

}



