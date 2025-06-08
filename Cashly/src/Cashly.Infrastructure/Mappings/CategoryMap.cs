using Cashly.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Cashly.Infrastructure.Mappings;


public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("categories");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .UseIdentityColumn();

        builder.OwnsOne(c => c.Name, n =>
        {
            n.Property(v => v.Value)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(30);

            n.HasIndex(v => v.Value)
            .IsUnique()
            .HasDatabaseName("ix_categories_name");
        });

        builder.Property(c => c.Description)
            .HasMaxLength(100);

    }
}
