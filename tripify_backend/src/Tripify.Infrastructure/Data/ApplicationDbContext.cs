using Microsoft.EntityFrameworkCore;
using Tripify.Application.Common.Interfaces;
using Tripify.Domain.Entities;

namespace Tripify.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Trip> Trips => Set<Trip>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Destination).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Budget).HasColumnType("decimal(18,2)");
        });
    }
}
