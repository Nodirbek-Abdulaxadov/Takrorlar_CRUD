using AutoMapper;
using BusinessLogicLayer.Extended;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using BusinessLogicLayer.Extended;
using BusinessLogicLayer.Dtos.Computer;

namespace BusinessLogicLayer.Services;
public class ComputerService(IUnitOfWork unitOfWork,
                             IMapper mapper)
    : IComputerService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task AddAsync(AddComputerDto dto)
    {
        if (!dto.IsValid())
        {
            throw new ComputerException("All field must be valid!");
        }

        var list = await _unitOfWork.ComputerInterface.GetAllAsync();
        var computer = _mapper.Map<Computer>(dto);
        
        if (list.Any(list => list.Name == computer.Name && 
                             list.Description == computer.Description && 
                             list.Price == computer.Price && 
                             list.ImageUrl == computer.ImageUrl && 
                             list.Brand == computer.Brand))
        {
            throw new ComputerException("Computer is already exist!");
        }

        await _unitOfWork.ComputerInterface.AddAsync(computer);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var computer = await _unitOfWork.ComputerInterface.GetByIdAsync(id);
        if (computer == null)
        {
            throw new ComputerException("Computer not found");
        }

        await _unitOfWork.ComputerInterface.DeleteAsync(computer);
        await _unitOfWork.SaveAsync();
    }

    public async Task<List<ComputerDto>> GetAllAsync()
    {
        var list = await _unitOfWork.ComputerInterface.GetAllAsync();
        return list.Select(c => _mapper.Map<ComputerDto>(c))
                   .ToList();
    }

    public async Task<ComputerDto> GetByIdAsync(int id)
    {
        var computer = await _unitOfWork.ComputerInterface.GetByIdAsync(id);
        if (computer == null)
        {
            throw new ComputerException("Computer not found");
        }

        return _mapper.Map<ComputerDto>(computer);
    }

    public async Task<PagedList<ComputerDto>> GetPagedListAsync(int pageNumber, int pageSize)
    {
        var list = await _unitOfWork.ComputerInterface.GetAllAsync();
        var pagedList = new PagedList<ComputerDto>(list.Select(c => _mapper.Map<ComputerDto>(c)).ToList(), 
                                                   list.Count(), pageNumber, pageSize);

        return pagedList.ToPagedList(pagedList.Data, 
                                     pageSize, 
                                     pageNumber); 
    }

    public async Task UpdateAsync(ComputerDto dto)
    {
        var list = await _unitOfWork.ComputerInterface.GetAllAsync();
        var computer = _mapper.Map<Computer>(dto);
        if (list.Any(c => c.Equals(computer) && c.Id != computer.Id))
        {
            throw new ComputerException("Computer is already exist!");
        }

        await _unitOfWork.ComputerInterface.UpdateAsync(computer);
        await _unitOfWork.SaveAsync();
    }
}