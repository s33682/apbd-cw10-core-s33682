using Microsoft.AspNetCore.Mvc;
using CoreApp.Exceptions;
using CoreApp.Services;

namespace CoreApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PCsController : ControllerBase
{
    private readonly IDbService _dbService;

    public PCsController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetPCs()
    {
        try
        {
            var result = await _dbService.GetPCsAsync();
            return Ok(result);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpGet]
    [Route("{pcId:int}/components")]
    public async Task<IActionResult> GetPcById(int pcId)
    {
        try
        {
            var result = await _dbService.GetPcByIdsAsync(pcId);
            return Ok(result);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}