using BE_DashBoard.ClaseEnumerable;
using BE_DashBoard.Context;
using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using Microsoft.EntityFrameworkCore;
using static BE_DashBoard.ClaseEnumerable.AmbienteEnum;


namespace BE_DashBoard.Services
{
    public class MarcasService : IMarcasService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AplicacionDbContext _dbcontext;
        private readonly AplicacionDbContextBlue _dbcontextBlue;

        public MarcasService(IUnitOfWork unitOfWork, AplicacionDbContext dbcontext, AplicacionDbContextBlue dbcontextBlue)
        {
            _unitOfWork = unitOfWork;
            _dbcontext = dbcontext;
            _dbcontextBlue = dbcontextBlue;
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
        public async Task<Marcas> ActualizarMarcas(string Rnc, Marcas updateMarcas, int ambiente)
        {
            try
            {
                if (ambiente == (int)DbType.Produccion)
                {
                    string claveBusqueda = Rnc + "" + updateMarcas.Tipo;

                    if (Rnc != updateMarcas.Rnc)
                    {
                        return null;
                    }

                    // Buscar la entidad por la clave primaria
                    var MarcaUpdate = await _dbcontext.Marcas.FirstOrDefaultAsync(r => (r.Rnc + "" + r.Tipo) == claveBusqueda);

                    if (MarcaUpdate == null)
                    {
                        return null;
                    }

                    MarcaUpdate.Estado = updateMarcas.Estado;

                    await _dbcontext.SaveChangesAsync();

                    return MarcaUpdate;
                }
                else if (ambiente == (int)DbType.PreCertificacion)
                {
                    string claveBusqueda = Rnc + "" + updateMarcas.Tipo;

                    if (Rnc != updateMarcas.Rnc)
                    {
                        return null;
                    }

                    // Buscar la entidad por la clave primaria
                    var MarcaUpdate = await _dbcontextBlue.Marcas.FirstOrDefaultAsync(r => (r.Rnc + "" + r.Tipo) == claveBusqueda);

                    if (MarcaUpdate == null)
                    {
                        return null;
                    }

                    MarcaUpdate.Estado = updateMarcas.Estado;

                    await _dbcontextBlue.SaveChangesAsync();

                    return MarcaUpdate;
                }
                else if (ambiente == (int)DbType.Certificacion)
                {
                    string claveBusqueda = Rnc + "" + updateMarcas.Tipo;

                    if (Rnc != updateMarcas.Rnc)
                    {
                        return null;
                    }

                    // Buscar la entidad por la clave primaria
                    var MarcaUpdate = await _dbcontext.Marcas.FirstOrDefaultAsync(r => (r.Rnc + "" + r.Tipo) == claveBusqueda);

                    if (MarcaUpdate == null)
                    {
                        return null;
                    }

                    MarcaUpdate.Estado = updateMarcas.Estado;

                    await _dbcontext.SaveChangesAsync();

                    return MarcaUpdate;
                }
                else
                {
                    // Lógica para otros ambientes si es necesario
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}

