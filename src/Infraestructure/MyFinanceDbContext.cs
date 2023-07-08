using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure;
public class MyFinanceDbContext : DbContext
{
    public MyFinanceDbContext(DbContextOptions<MyFinanceDbContext> options) : base(options)
    {
    }

    public DbSet<PlanoConta> PlanoContas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PlanoConta>().ToTable("planoconta");
        modelBuilder.Entity<PlanoConta>().HasKey(p => p.Id);
        modelBuilder.Entity<PlanoConta>().Property(p => p.Descricao).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<PlanoConta>().Property(p => p.Tipo).IsRequired();
    }
}