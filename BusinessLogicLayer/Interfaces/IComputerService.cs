using BusinessLogicLayer.Dtos.Computer;
using BusinessLogicLayer.Extended;

namespace BusinessLogicLayer.Interfaces;
public interface IComputerService
{
    Task<PagedList<ComputerDto>> GetPagedListAsync(int pageNumber, 
                                                   int pageSize);
    Task<List<ComputerDto>> GetAllAsync();
    Task<ComputerDto> GetByIdAsync(int id);
    Task AddAsync(AddComputerDto dto);
    Task UpdateAsync(ComputerDto dto);
    Task DeleteAsync(int id);
}
