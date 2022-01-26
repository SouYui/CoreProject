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
        }

        public DbSet<Administrador> Administrador { get; set; }
    }
}