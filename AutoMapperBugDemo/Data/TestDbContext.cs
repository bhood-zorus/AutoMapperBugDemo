using Microsoft.EntityFrameworkCore;

namespace AutoMapperBugDemo.Data;

public class TestDbContext : DbContext
{
    public TestDbContext(){}

    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<TestEntity> Entities { get; private set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TestEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
        });
    }
}
