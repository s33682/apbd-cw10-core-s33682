using Microsoft.EntityFrameworkCore;
using CoreApp.Models;

namespace CoreApp.Context;

public class AppDbContext : DbContext
{
    public DbSet<PC> PCs { get; set; }
    public DbSet<PCComponents> PcComponents { get; set; }
    public DbSet<ComponentTypes> ComponentTypes { get; set; }
    public DbSet<Components> Components { get; set; }
    public DbSet<ComponentManufacturers> ComponentManufacturers { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ComponentManufacturers>().HasData(
            new ComponentManufacturers { Id = 1, Abbreviation = "INTC", FullName = "Intel Corporation", FoundationDate = new DateOnly(1968, 7, 18) },
            new ComponentManufacturers { Id = 2, Abbreviation = "AMD", FullName = "Advanced Micro Devices", FoundationDate = new DateOnly(1969, 5, 1) },
            new ComponentManufacturers { Id = 3, Abbreviation = "NVDA", FullName = "NVIDIA Corporation", FoundationDate = new DateOnly(1993, 4, 5) }
        );

        modelBuilder.Entity<ComponentTypes>().HasData(
            new ComponentTypes { Id = 1, Abbreviation = "CPU", Name = "Central Processing Unit" },
            new ComponentTypes { Id = 2, Abbreviation = "GPU", Name = "Graphics Processing Unit" },
            new ComponentTypes { Id = 3, Abbreviation = "RAM", Name = "Random Access Memory" }
        );

        modelBuilder.Entity<PC>().HasData(
            new PC { Id = 1, Name = "Gaming Beast X", Weight = 12.5f, Warranty = 36, CreatedAt = new DateTime(2026, 5, 8, 9, 0, 0), Stock = 5 },
            new PC { Id = 2, Name = "Office Mini Pro", Weight = 4.2f, Warranty = 24, CreatedAt = new DateTime(2026, 4, 15, 13, 30, 0), Stock = 12 },
            new PC { Id = 3, Name = "Home Media PC", Weight = 6.0f, Warranty = 12, CreatedAt = new DateTime(2026, 5, 10, 10, 0, 0), Stock = 2 }
        );

        modelBuilder.Entity<Components>().HasData(
            new Components { Code = "CPU001", Name = "Core i9-14900K", Description = "24 cores", ComponentManufacturersId = 1, ComponentTypesId = 1 },
            new Components { Code = "GPU001", Name = "RTX 5080", Description = "High-end graphics", ComponentManufacturersId = 3, ComponentTypesId = 2 },
            new Components { Code = "RAM001", Name = "32GB DDR5", Description = "Fast memory", ComponentManufacturersId = 1, ComponentTypesId = 3 }
        );

        modelBuilder.Entity<PCComponents>().HasData(
            new PCComponents { PcId = 1, ComponentCode = "CPU001", Amount = 1 },
            new PCComponents { PcId = 1, ComponentCode = "GPU001", Amount = 1 },
            new PCComponents { PcId = 2, ComponentCode = "RAM001", Amount = 2 }
        );
    }
}