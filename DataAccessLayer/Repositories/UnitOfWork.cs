using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repositories;
public class UnitOfWork(IComputerInterface computerInterface,
                        AppDBContext dBContext) 
    : IUnitOfWork
{
    public IComputerInterface ComputerInterface { get; }
        = computerInterface;
    private readonly AppDBContext _dbContext = dBContext;

    public void Dispose()
        => GC.SuppressFinalize(this);

    public async Task SaveAsync()
        => await _dbContext.SaveChangesAsync();
}
