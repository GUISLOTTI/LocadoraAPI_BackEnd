using LocadoraApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace LocadoraApi.Infrastructure.Data;

public class LocadoraContext : DbContext
{
    public LocadoraContext(DbContextOptions<LocadoraContext> options) : base(options)
    {
    }

    public DbSet<Marca> Marcas { get; set; }
    public DbSet<Modelo> Modelos { get; set; }
    public DbSet<Carro> Carros { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Locacao> Locacoes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Modelo>()
            .HasOne(m => m.ReferenciaMarca)
            .WithMany()
            .HasForeignKey(m => m.ReferenciaMarcaId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Carro>()
            .HasOne(c => c.ReferenciaModelo)
            .WithMany()
            .HasForeignKey(c => c.ReferenciaModeloId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Locacao>()
            .HasOne(l => l.IdentificadorCarro)
            .WithMany()
            .HasForeignKey(l => l.IdentificadorCarroId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Locacao>()
            .HasOne(l => l.IdentificadorUsuario)
            .WithMany()
            .HasForeignKey(l => l.IdentificadorUsuarioId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.Email)
            .IsUnique(); // GARANTE QUE O EMAIL SEJA UNICO

        modelBuilder.Entity<Carro>()
            .Property(c => c.Ano)
            .IsRequired();

        modelBuilder.Entity<Marca>()
            .Property(m => m.NomeMarca)
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<Modelo>()
            .Property(m => m.NomeModelo)
            .HasMaxLength(100)
            .IsRequired();
        modelBuilder.Entity<Locacao>()
            .Property(l => l.Valor)
            .HasColumnType("decimal(18,2)"); // NÃO SEI MUITO BEM O QUE FAZ, MAS VI QUE É UMA BOA PRATICA.
    }
}