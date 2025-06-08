using Cashly.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cashly.Infrastructure.Mappings
{
    public class GoalMap : IEntityTypeConfiguration<Goal>
    {
        public void Configure(EntityTypeBuilder<Goal> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id")
                .UseIdentityColumn();

            builder.OwnsOne(x => x.Value, c =>
            {
                c.Property(v => v.Value)
                .HasColumnName("value") 
                .HasColumnType("NUMERIC(12,2)")
                .IsRequired();
            });

            builder.Property(x => x.StartDate)
                .HasColumnName("start_date")
                .HasColumnType("TIMESTAMPTZ")
                .IsRequired();

            builder.Property(x => x.CashflowId)
                    .HasColumnName("cashflow_id");

            builder.OwnsOne(x => x.Deadline, d =>
            {
                d.Property(v => v.Date)
                .HasColumnName("deadline_goal")
                .HasColumnType("TIMESTAMPTZ")
                .IsRequired();
            });

            builder.HasOne(x => x.Cashflow)
                .WithOne(c => c.Goal)
                .HasForeignKey<Goal>(x => x.CashflowId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
