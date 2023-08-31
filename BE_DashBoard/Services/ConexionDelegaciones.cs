using BE_DashBoard.ClaseEnumerable;
using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using static BE_DashBoard.ClaseEnumerable.AmbienteEnum;

namespace BE_DashBoard.Services
{
    public class ConexionDelegaciones : IConexionDelegacionesServices
    {

        private readonly IUnitOfWork _unitOfWork;

        public ConexionDelegaciones(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

    }
}


