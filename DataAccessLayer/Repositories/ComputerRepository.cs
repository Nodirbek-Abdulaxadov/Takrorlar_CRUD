using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories;
public class ComputerRepository(AppDBContext dBContext) 
    : IComputerInterface
{
    private readonly AppDBContext _dBContext = dBContext;

    public Task AddAsync(Computer computer)
    {
        _dBContext.Computers.Add(computer);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Computer computer)
    {
        _dBContext.Computers.Remove(computer);
        return Task.CompletedTask;
    }

    public Task<IQueryable<Computer>> GetAllAsync()
    {
        var list = _dBContext.Computers.AsQueryable();
        return Task.FromResult(list);
    }

    public async Task<Computer?> GetByIdAsync(int id)
    {
        var computer = await _dBContext.Computers
                                       .FirstOrDefaultAsync(x => x.Id == id);
        return computer;
    }

    public Task UpdateAsync(Computer computer)
    {
        _dBContext.Computers.Update(computer);
        return Task.CompletedTask;
    }
}