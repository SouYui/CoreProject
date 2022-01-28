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
            modelBuilder.Entity<AreasExhibicion>().HasKey(be => new { be.exhibicionId });
            modelBuilder.Entity<Producto>().HasKey(be => new { be.productoId });
            modelBuilder.Entity<Inventario>().HasKey(be => new { be.inventarioId });
            modelBuilder.Entity<Menu>().HasKey(be => new { be.menuId });
            modelBuilder.Entity<MenuItem>().HasKey(be => new { be.itemId });
            modelBuilder.Entity<Usuario>().HasKey(be => new { be.usuarioId });
            modelBuilder.Entity<Venta>().HasKey(be => new { be.ventaId });
            modelBuilder.Entity<ProductoVenta>().HasKey(be => new { be.prdVentaId });
        }

        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<Sucursal> Sucursal { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Venta> Venta { get; set; }
        public DbSet<ProductoVenta> ProductoVenta { get; set; }
    }
}