using FCA.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FCA.Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base (options)
    { }

    public DbSet<Proprietario>? Proprietarios { get; set; }
    public DbSet<Veiculo>? Veiculos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
