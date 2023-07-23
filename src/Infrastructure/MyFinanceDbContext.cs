using Microsoft.EntityFrameworkCore;
using MyFinance.Domain.Models;

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
            x.Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(100);
            x.Property(p => p.Tipo)
                .HasConversion<int>();
        });

        modelBuilder.Entity<Transacao>(x =>
        {
            x.ToTable("Transacao");
            x.HasKey(p => p.Id);
            x.Property(p => p.Historico)
                .IsRequired()
                .HasMaxLength(250);
            x.Property(p => p.Data)
                .IsRequired();
            x.Property(p => p.Valor)
                .IsRequired();
            x.HasOne<PlanoConta>(x => x.ItemPlanoConta)
                .WithMany()
                .HasForeignKey("planoconta_id")
                .IsRequired();
        });
    }
}