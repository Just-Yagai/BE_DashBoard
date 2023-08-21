using BE_DashBoard.Interfaces;
using BE_DashBoard.Models;
using BE_DashBoard.UnitOfWork;
using System.Text.Json;

namespace BE_DashBoard.Services
{
    public class ContribuyentesService : IConexionContribuyenteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContribuyentesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<IEnumerable<Contribuyente>> GetContribuyente(string rnc)
        {
            var response = _unitOfWork.PruebaRepositorioBlue.GetContribuyente(a => a.RNC == rnc);
            return response;

        }

        public IQueryable<Contribuyente> GetAllContribuyentes()
        {
            return _unitOfWork.PruebaRepositorioBlue.GetAllContribuyentes();
        }


        /*private readonly IContribuyentesService _contribuyenteRepositorio;

        public ContribuyentesService(IContribuyentesService contribuyenteRepositorio)
        {
            _contribuyenteRepositorio = contribuyenteRepositorio;   
        }
        public Task<IEnumerable<Contribuyente>> GetContribuyente(string rnc)
        {
            var response = _contribuyenteRepositorio.GetContribuyente(a => a.RNC == rnc);
            return response;

        }

        public IQueryable<Contribuyente> GetAllContribuyentes()
        {
            return _contribuyenteRepositorio.GetAllContribuyentes();
        }*/

    }
}
