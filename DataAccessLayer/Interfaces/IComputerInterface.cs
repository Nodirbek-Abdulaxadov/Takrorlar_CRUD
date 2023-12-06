using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces;
public interface IComputerInterface
{
    Task<IQueryable<Computer>> GetAllAsync();
    Task<Computer?> GetByIdAsync(int id);
    Task AddAsync(Computer computer);
    Task UpdateAsync(Computer computer);
    Task DeleteAsync(Computer computer);
}