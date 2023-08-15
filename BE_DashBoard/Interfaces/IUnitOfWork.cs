namespace BE_DashBoard.Interfaces
{
    public interface IUnitOfWork
    {
        IPruebaRepositorio PruebaRepositorio { get; }
        IPruebaRepositorio PruebaRepositorioBlue { get; }
    }
}
