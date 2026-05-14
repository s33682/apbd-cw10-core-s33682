namespace CoreApp.Services;

using CoreApp.Context;
using CoreApp.DTOs;
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
}