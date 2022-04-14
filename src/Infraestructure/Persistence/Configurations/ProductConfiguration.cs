using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Persistence.Configurations;

public class TodoItemConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.ProductId);
        builder.Property(o => o.Name)
            .IsRequired();
        builder.Property(o => o.Description)
            .IsRequired();
        builder.Property(o => o.Status)
            .IsRequired();
        builder.Property(o => o.Price)
            .IsRequired();
        builder.Property(o => o.Stock)
            .IsRequired();
    }
}