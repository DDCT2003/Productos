using Productos.Models;

namespace Productos.NewFolder
{
    public class Utils
    {

        public static List<Producto> ListaProducto = new List<Producto>()
        {
            new Producto()
            {
                IdProducto = 1,
                Nombre = "Producto 1",
                Descripcion = "Des",
                Cantidad = 1 
            },
              new Producto()
            {
                IdProducto = 2,
                Nombre = "Producto 2",
                Descripcion = "Des",
                Cantidad = 1
            }
        };
    }
}
