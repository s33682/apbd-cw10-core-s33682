using CoreApp.Exceptions;

namespace CoreApp.Services;

using CoreApp.Context;
using CoreApp.DTOs;
using CoreApp.Models;
using Microsoft.EntityFrameworkCore;

public class DbService : IDbService
{
    private readonly AppDbContext _context;

    public DbService(AppDbContext context)
    {
        _context = context;
    }
    
    
    public async Task<IEnumerable<GetPcDto>> GetPCsAsync()
    {
        return await _context.PCs.Select( p=> new GetPcDto
        {
            Id = p.Id,
            Name = p.Name,
            Weight = p.Weight,
            Warranty =  p.Warranty,
            CreatedAt = p.CreatedAt,
            Stock = p.Stock
        }).ToListAsync();
    }

    public async Task<GetPcByIdDto> GetPcByIdsAsync(int pcId)
    {
        var pc = await _context.PCs
            .Include(p=>p.PcComponents).ThenInclude(pc=>pc.Components).ThenInclude(c=>c.ComponentManufacturers)
            .Include(p=>p.PcComponents).ThenInclude(pc=>pc.Components).ThenInclude(c=>c.ComponentTypes)
            .FirstOrDefaultAsync(p => p.Id == pcId);

        if (pc == null)
        {
            throw new NotFoundException($"PC not found with id {pcId}!");
        }

        return new GetPcByIdDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock,
            Components = pc.PcComponents.Select(pcc => new GetPcComponentsDto
            {
              Amount  = pcc.Amount,
              Component = new GetComponentDto
              {
                  Code = pcc.Components.Code,
                  Name = pcc.Components.Name,
                  Description = pcc.Components.Description,
                  Manufacturer = new GetManufacturerDto
                  {
                      Id = pcc.Components.ComponentManufacturers.Id,
                      Abbreviation = pcc.Components.ComponentManufacturers.Abbreviation,
                      FullName = pcc.Components.ComponentManufacturers.FullName,
                      FoundationDate = pcc.Components.ComponentManufacturers.FoundationDate
                  },
                  Type = new GetTypeDto
                  {
                      Id = pcc.Components.ComponentTypes.Id,
                      Abbreviation = pcc.Components.ComponentTypes.Abbreviation,
                      Name = pcc.Components.ComponentTypes.Name
                  }
              }
            }).ToList()
        };
    }
    public async Task<GetPcDto> AddPcAsync(PostPcDto postPc)
    {
        var newPc = new PC
        {
            Name = postPc.Name,
            Weight =  postPc.Weight,
            Warranty =  postPc.Warranty,
            CreatedAt =  postPc.CreatedAt,
            Stock =  postPc.Stock
        };
        
        _context.PCs.Add(newPc);
        await _context.SaveChangesAsync();

        return new GetPcDto
        {
            Id = newPc.Id,
            Name = newPc.Name,
            Weight = newPc.Weight,
            Warranty = newPc.Warranty,
            CreatedAt = newPc.CreatedAt,
            Stock = newPc.Stock
        };
    }
}