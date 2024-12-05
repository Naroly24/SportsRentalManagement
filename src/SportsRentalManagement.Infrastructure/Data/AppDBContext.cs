using Microsoft.EntityFrameworkCore;
using SportsRentalManagement.Models;
using SportsRentalManagement.Data;

namespace SportsRentalManagement.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Facturacion> Facturaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Equipo>()
                .Property(e => e.PrecioPorDia)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Reserva>()
                .Property(r => r.TotalReserva)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Pago>()
                .Property(p => p.Monto)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Facturacion>()
                .Property(f => f.Total)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Usuario)
                .WithMany()
                .HasForeignKey(r => r.UsuarioId);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Equipo)
                .WithMany()
                .HasForeignKey(r => r.EquipoId);

            modelBuilder.Entity<Pago>()
                .HasOne(p => p.Reserva)
                .WithMany()
                .HasForeignKey(p => p.ReservaId);

            modelBuilder.Entity<Facturacion>()
                .HasOne(f => f.Reserva)
                .WithMany()
                .HasForeignKey(f => f.ReservaId);
        }
    }
}
