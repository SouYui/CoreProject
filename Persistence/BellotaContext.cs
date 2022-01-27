using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class BellotaContext : DbContext
    {
        public BellotaContext(DbContextOptions options) : base(options) {} // Migraciones

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            // Archivo de migracion
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Administrador>().HasKey( be => new { be.administradorId } );
            modelBuilder.Entity<Sucursal>().HasKey(be => new { be.sucursalId });
            modelBuilder.Entity<Proveedor>().HasKey(be => new { be.proveedorId });
            modelBuilder.Entity<Inventario>().HasKey(be => new { be.inventarioId });
        }

        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<Sucursal> Sucursal { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
    }
}