using facturi_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace facturi_backend.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Factura> Facturi { get; set; }
        public DbSet<DetaliiFactura> DetaliiFacturi { get; set; }
        public DatabaseContext(DbContextOptions <DatabaseContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Factura>()
                .HasKey(factura => new { factura.IdFactura, factura.IdLocatie });
            modelBuilder.Entity<DetaliiFactura>()
                .HasKey(detaliiFactura => new { detaliiFactura.IdDetaliiFactura, detaliiFactura.IdLocatie });

            modelBuilder.Entity<Factura>()
                .HasOne(factura => factura.DetaliiFactura)
                .WithOne(detaliiFactura => detaliiFactura.Factura)
                .HasForeignKey<DetaliiFactura>(detaliiFactura => new { detaliiFactura.IdFactura, detaliiFactura.IdLocatie });

            base.OnModelCreating(modelBuilder);
        }
    }
}
