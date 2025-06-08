using Cashly.Domain.Entities;
using Cashly.Domain.Enums;
using Cashly.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Cashly.Infrastructure.DataContext;

public class CashlyDbContext : DbContext
{
    public CashlyDbContext(DbContextOptions<CashlyDbContext> options) : base(options)
    {
    }

    public DbSet<Cashflow> Cashflows { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Goal> Goals { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .RegisterPostgresEnum<CashflowStatus>("cashflow_status")
            .RegisterPostgresEnum<TransactionStatus>("transaction_status")
            .RegisterPostgresEnum<TransactionType>("transaction_type");

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
