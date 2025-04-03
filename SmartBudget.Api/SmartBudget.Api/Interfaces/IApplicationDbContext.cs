using Microsoft.EntityFrameworkCore;
using SmartBudget.Api.Models.Entities;

namespace SmartBudget.Api.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Category> Categories { get; set; }
    DbSet<Transaction> Transactions { get; set; }

    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
