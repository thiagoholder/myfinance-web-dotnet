using MyFinance.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MyFinance.Infrastructure;

public class MyFinanceDbContext : DbContext
{
    public MyFinanceDbContext(DbContextOptions<MyFinanceDbContext> options) : base(options)
    {
    }

    public DbSet<PlanoConta> PlanoContas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<PlanoConta>(x =>
        {
            x.ToTable("PlanoConta");
            x.HasKey(p => p.Id);
            x.Property(p => p.Descricao).IsRequired().HasMaxLength(100);
            x.Property(p => p.Tipo)
                .HasConversion<int>();
        });
    }
}