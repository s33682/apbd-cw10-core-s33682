using Microsoft.EntityFrameworkCore;
using CoreApp.Models;

namespace CoreApp.Context;

public class AppDbContext : DbContext
{
    public DbSet<PC>  PCs { get; set; }
    public DbSet<PCComponents>  PcComponents { get; set; }
    public DbSet<ComponentTypes>   ComponentTypes { get; set; }
    public DbSet<Components>  Components { get; set; }
    public DbSet<ComponentManufacturers> ComponentManufacturers { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}