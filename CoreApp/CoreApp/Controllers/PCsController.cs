using Microsoft.AspNetCore.Mvc;
using CoreApp.Exceptions;
using CoreApp.Services;
using CoreApp.DTOs;

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

    [HttpPost]
    public async Task<IActionResult> AddPc(PostPcDto postPc)
    {
        try
        {
            var result = await _dbService.AddPcAsync(postPc);
            return Created("", result);
        }
        catch (DatabaseException e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPut]
    [Route("{pcId:int}")]
    public async Task<IActionResult> UpdatePc(int pcId, PostPcDto postPc)
    {
        try
        {
            var result = await _dbService.UpdatePcAsync(pcId, postPc);
            return Ok(result);
        }
        catch(NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete]
    [Route("{pcId:int}")]
    public async Task<IActionResult> DeletePc(int pcId)
    {
        try
        {
            await _dbService.DeletePcAsync(pcId);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}