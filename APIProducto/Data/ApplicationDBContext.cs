using APIProducto.Models;
using Microsoft.EntityFrameworkCore;

namespace APIProducto.Data
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext( DbContextOptions<ApplicationDBContext> options ) : base( options ) { }


         public DbSet<Producto> Producto {  get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    IdProducto=5,
                    Nombre="Producto 1",
                    Descripcion="Descripcion 1",
                    Cantidad=12
                }
                );
        }
    }
}
