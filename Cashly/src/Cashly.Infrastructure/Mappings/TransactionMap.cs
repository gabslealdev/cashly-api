using Cashly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cashly.Infrastructure.Mappings
{
    public class TransactionMap : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id)
                .HasColumnName("id")
                .UseIdentityColumn();

            builder.OwnsOne(t => t.Amount, c =>
            {
                c.Property(v => v.Value)
                .HasColumnName("amount")
                .HasColumnType("NUMERIC(12,2)")
                .IsRequired();
            });

            builder.Property(t => t.Date)
                .HasColumnName(@"date")
                .HasColumnType("TIMESTAMPTZ")
                .IsRequired();

            builder.Property(t => t.Description)
                .HasColumnName("description") 
                .HasMaxLength(100);
             
            builder.Property(t => t.Type)
                .HasColumnName(@"type")
                .HasColumnType("transaction_type");

            builder.Property(t => t.Status)
                .HasColumnName("status")
                .HasColumnType("transaction_status");

            builder.Property(t => t.CategoryId)
                .HasColumnName("category_id");

            builder.Property(t => t.CashflowId)
                .HasColumnName("cashflow_id");

            builder.HasOne(t => t.Category)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(t => t.Cashflow)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CashflowId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
