namespace DataAccessLayer.Interfaces;
public interface IUnitOfWork : IDisposable
{
    IComputerInterface ComputerInterface { get; }
    Task SaveAsync();
}