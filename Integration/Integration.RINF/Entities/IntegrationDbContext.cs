using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Integration.RINF.Entities;

public class IntegrationDbContext:DbContext
{
    public DbSet<OperationalPoint> OperationalPoints { get; init; }
    
    public IntegrationDbContext(DbContextOptions options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<OperationalPoint>().ToCollection("OperationalPoint");
    }
}
