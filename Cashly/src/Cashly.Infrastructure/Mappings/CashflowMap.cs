using Cashly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cashly.Infrastructure.Mappings
{
    public class CashflowMap : IEntityTypeConfiguration<Cashflow>
    {
        public void Configure(EntityTypeBuilder<Cashflow> builder)
        {
            builder.ToTable("cashflows"); 

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id")
                .UseIdentityColumn();

            builder.Property(x => x.CurrentBalance)
                .HasColumnName("current_balance")
                .HasColumnType("NUMERIC(12,2)")
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnName("status")
                .HasColumnType("cashflow_status");

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("TIMESTAMPTZ")
                .IsRequired();

            builder.Property(x => x.UserId)
                .HasColumnName("user_id");

            builder.HasOne(x => x.User)
                .WithOne(u => u.Cashflow)
                .HasForeignKey<Cashflow>(x => x.UserId)
                .IsRequired();

            builder.Navigation(c => c.Transactions).AutoInclude(false);

        }
    }
}
