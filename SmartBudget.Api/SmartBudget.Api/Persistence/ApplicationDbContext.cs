using Microsoft.EntityFrameworkCore;
using SmartBudget.Api.Interfaces;
using SmartBudget.Api.Models.Entities;

namespace SmartBudget.Api.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        //Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
