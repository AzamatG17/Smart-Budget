using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartBudget.Api.Models.Entities;

namespace SmartBudget.Api.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable(nameof(Category));
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(c => c.TransactionType)
            .IsRequired();

        builder.HasMany(c => c.Transactions)
            .WithOne(t => t.Category)
            .HasForeignKey(t => t.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
