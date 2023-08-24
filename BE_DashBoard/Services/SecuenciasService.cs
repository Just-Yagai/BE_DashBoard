using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using System.Text.Json;

namespace BE_DashBoard.Services
{
    public class SecuenciasService : ISecuencuasService

    {
        private readonly IUnitOfWork _unitOfWork;

        public SecuenciasService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Secuencias>> GetSecuencias(DbType1 ambiente, string rnc, int CanalID, int TipoECF)
        {
            switch (ambiente)
            {
                case DbType1.Produccion:
                    return await this._unitOfWork.PruebaRepositorio.Getsecuencia(a => a.Rnc == rnc && a.CanalID == CanalID && a.AmbienteID == (int)ambiente && (TipoECF != 0 ? a.TipoECF == TipoECF : true));
                case DbType1.PreCertificacion:
                    return await this._unitOfWork.PruebaRepositorioBlue.Getsecuencia(a => a.Rnc == rnc && a.CanalID == CanalID && a.AmbienteID == (int)ambiente && (TipoECF != 0 ? a.TipoECF == TipoECF : true));
                default:
                    return await this._unitOfWork.PruebaRepositorio.Getsecuencia(a => a.Rnc == rnc && a.CanalID == CanalID && a.AmbienteID == (int)ambiente && (TipoECF != 0 ? a.TipoECF == TipoECF : true));
            }
        }
    }
    public enum DbType1
    {
        Produccion = 1,
        PreCertificacion = 2,
        Certificacion = 3,
    }
}

