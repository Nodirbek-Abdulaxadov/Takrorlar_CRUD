using BusinessLogicLayer.Dtos.Computer;
using BusinessLogicLayer.Extended;
using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ComputerController(IComputerService computerService)
    : ControllerBase
{
    private readonly IComputerService _computerService = computerService;

    [HttpGet("[action]")]
    public async Task<IActionResult> Get()
    {
        var list = await _computerService.GetAllAsync();
        return Ok(list);
    }

    [HttpGet("[action]/paged")]
    public async Task<IActionResult> Get(int pageSize = 10, int pageNumber = 1)
    {
        var list = await _computerService.GetPagedListAsync(pageNumber, pageSize);
        var metaData = new
        {
            list.TotalCount,
            list.PageSize,
            list.CurrentPage,
            list.HasNext,
            list.HasPrevious
        };

        Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metaData));
        return Ok(list.Data);
    }

    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var computer = await _computerService.GetByIdAsync(id);
            return Ok(computer);
        }
        catch(ComputerException ex) 
        {
            return NotFound(ex.ErrorMessage);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Post(AddComputerDto dto)
    {
        try
        {
            await _computerService.AddAsync(dto);
            return Ok();
        }
        catch (ComputerException ex)
        {
            return BadRequest(ex.ErrorMessage);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Put(ComputerDto dto)
    {
        try
        {
            await _computerService.UpdateAsync(dto);
            return Ok();
        }
        catch (ComputerException ex)
        {
            return BadRequest(ex.ErrorMessage);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _computerService.DeleteAsync(id);
            return Ok();
        }
        catch (ComputerException ex)
        {
            return BadRequest(ex.ErrorMessage);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}