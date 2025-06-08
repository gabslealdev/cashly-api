using Cashly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cashly.Infrastructure.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .HasColumnName("id")
                .UseIdentityColumn();

            builder.OwnsOne(u => u.Name, n => 
            {
                n.Property(v => v.Value)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(30);
            });

            builder.OwnsOne(u => u.Email, e =>
            {
                e.Property(v => v.Value)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(80);

                e.HasIndex(v => v.Value)
                .IsUnique()
                .HasDatabaseName("ix_users_email");

            });

            builder.Property(u => u.PasswordHash)
                .HasColumnName("password")
                .IsRequired()
                .HasMaxLength(160);

            builder.Property(u => u.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("TIMESTAMPTZ")
                .IsRequired();

            builder.Property(u => u.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("TIMESTAMPTZ")
                .IsRequired();

            

        }
    }
}
