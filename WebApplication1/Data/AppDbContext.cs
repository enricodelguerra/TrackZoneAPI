using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Moto> Motos { get; set; }
        public DbSet<StatusMoto> StatusMotos { get; set; }
        public DbSet<Operacao> Operacoes { get; set; }
        public DbSet<Localizacao> Localizacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplicar configurações se tiver mapeamentos separados (opcional)
            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            // Constraints únicas conforme Oracle
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Cnpj)
                .IsUnique();

            modelBuilder.Entity<Moto>()
                .HasIndex(m => m.Placa)
                .IsUnique();

            modelBuilder.Entity<Moto>()
                .HasIndex(m => m.Chassi)
                .IsUnique();

            // Datas com valor padrão
            modelBuilder.Entity<Usuario>()
                .Property(u => u.DataCriacao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Moto>()
                .Property(m => m.DataCriacao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<StatusMoto>()
                .Property(s => s.DataCriacao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Operacao>()
                .Property(o => o.DataCriacao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Localizacao>()
                .Property(l => l.DataRegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            base.OnModelCreating(modelBuilder);
        }
    }
}
