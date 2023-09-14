using BE_DashBoard.ClaseEnumerable;
using BE_DashBoard.Context;
using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static BE_DashBoard.ClaseEnumerable.AmbienteEnum;

namespace BE_DashBoard.Services
{
    public class RncEstadosService : IrncEstadoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AplicacionDbContext _dbcontext;
        private readonly AplicacionDbContextBlue _dbcontextBlue;
            
        public RncEstadosService(IUnitOfWork unitOfWork, AplicacionDbContext dbcontext, AplicacionDbContextBlue dbcontextBlue)
        {
            _unitOfWork = unitOfWork;
            _dbcontext = dbcontext;
            _dbcontextBlue = dbcontextBlue;
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


        public async Task<RncEstado> ActualizarRncEstado(string Rnc, RncEstado updaterncEstado, int ambiente)
        {
            try
            {
                if (ambiente == (int)DbType.Produccion)
                {
                    var rncEstadoUpdate = await _dbcontext.RncEstados.FirstOrDefaultAsync(r => r.Rnc == Rnc);

                    if (rncEstadoUpdate == null)
                    {
                        return null; // Devuelve null si no se encuentra
                    }

                    rncEstadoUpdate.Estado = updaterncEstado.Estado;
                    rncEstadoUpdate.AutorizadoAFacturar = updaterncEstado.AutorizadoAFacturar;
                    rncEstadoUpdate.AutorizadoSolicitarSecuencia = updaterncEstado.AutorizadoSolicitarSecuencia;
                    rncEstadoUpdate.EsGrandeContribuyente = updaterncEstado.EsGrandeContribuyente;

                    await _dbcontext.SaveChangesAsync();
                    return rncEstadoUpdate;
                }
                else if (ambiente == (int)DbType.PreCertificacion)
                {
                    var rncEstadoUpdate = await _dbcontextBlue.RncEstados.FirstOrDefaultAsync(r => r.Rnc == Rnc);

                    if (rncEstadoUpdate == null)
                    {
                        return null; // Devuelve null si no se encuentra
                    }

                    rncEstadoUpdate.Estado = updaterncEstado.Estado;
                    rncEstadoUpdate.AutorizadoAFacturar = updaterncEstado.AutorizadoAFacturar;
                    rncEstadoUpdate.AutorizadoSolicitarSecuencia = updaterncEstado.AutorizadoSolicitarSecuencia;
                    rncEstadoUpdate.EsGrandeContribuyente = updaterncEstado.EsGrandeContribuyente;

                    await _dbcontextBlue.SaveChangesAsync();
                    return rncEstadoUpdate;
                }
                else if (ambiente == (int)DbType.Certificacion)
                {
                    var rncEstadoUpdate = await _dbcontext.RncEstados.FirstOrDefaultAsync(r => r.Rnc == Rnc);

                    if (rncEstadoUpdate == null)
                    {
                        return null; // Devuelve null si no se encuentra
                    }

                    rncEstadoUpdate.Estado = updaterncEstado.Estado;
                    rncEstadoUpdate.AutorizadoAFacturar = updaterncEstado.AutorizadoAFacturar;
                    rncEstadoUpdate.AutorizadoSolicitarSecuencia = updaterncEstado.AutorizadoSolicitarSecuencia;
                    rncEstadoUpdate.EsGrandeContribuyente = updaterncEstado.EsGrandeContribuyente;

                    await _dbcontext.SaveChangesAsync();
                    return rncEstadoUpdate;
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

