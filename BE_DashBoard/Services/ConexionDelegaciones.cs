using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;

namespace BE_DashBoard.Services
{
    public class ConexionDelegaciones : IConexionDelegacionesServices
    {

        private readonly IUnitOfWork _unitOfWork;

        public ConexionDelegaciones(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Delegacion>> GetDelegaciones(DbType ambiente, string rnc, int canal)
        {
            switch (ambiente)
            {
                case DbType.Produccion:
                    return await this._unitOfWork.PruebaRepositorio.GetDelegaciones(a => a.Rnc == rnc && a.CanalID == canal);
                case DbType.PreCertificacion:
                    return await this._unitOfWork.PruebaRepositorioBlue.GetDelegaciones(a => a.Rnc == rnc && a.CanalID == canal);
                default:
                    return await this._unitOfWork.PruebaRepositorioBlue.GetDelegaciones(a => a.Rnc == rnc && a.CanalID == canal);
            }
        }

        public Task<IEnumerable<Delegacion>> GetDelegaciones(int ambiente, string rnc, int canal)
        {
            throw new NotImplementedException();
        }
    }
    public enum DbType
    {
        Produccion = 1,
        PreCertificacion = 2,
        Certificacion = 3,
    }
}


