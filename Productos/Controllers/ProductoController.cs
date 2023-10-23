using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Productos.Models;
using Productos.NewFolder;
using System.Net.Http.Json;

namespace Productos.Controllers
{
    public class ProductoController : Controller
    {
        readonly HttpClient _client;
        readonly string direccion = "http://localhost:5267/api/Producto";

        public ProductoController()
        {
            _client = new HttpClient();
        }



        // GET: ProductoController
        public async Task<IActionResult> Index()
        {
            List<Producto> products = await _client.GetFromJsonAsync<List<Producto>>(direccion);
            return View(products);
        }

        // GET: ProductoController/Details/5
        public async Task<IActionResult> Details(int IdProducto)
        {
            Producto product = await _client.GetFromJsonAsync<Producto>(direccion + "/" + IdProducto);
            if (product != null)
            {
                return View(product);

            }
            return RedirectToAction("Index");
        }


        // GET: ProductoController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            await _client.PostAsJsonAsync(direccion, producto);
            return RedirectToAction("Index");
        }

 

        public async Task<IActionResult> Edit(int IdProducto)
        {
            Producto producto = await _client.GetFromJsonAsync<Producto>(direccion + "/" + IdProducto);
            if (producto != null)
            {
                return View(producto);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]

        public async Task<IActionResult> Edit(Producto producto)
        {
            Producto producto2 = await _client.GetFromJsonAsync<Producto>(direccion + "/" + producto.IdProducto);

            if (producto2 != null)
            {
               
                producto2.Nombre = producto.Nombre;
                producto2.Descripcion= producto.Descripcion;
                producto2.Cantidad= producto.Cantidad;
               // await _client.PutAsJsonAsync(direccion, producto2);
                await _client.PutAsJsonAsync(direccion + "/" + producto.IdProducto, producto2);

                return RedirectToAction("Index");
            }
            return View();
        }


        // GET: ProductoController/Delete/5
        public async Task<IActionResult> Delete(int IdProducto)
        {   
            Producto producto = await _client.DeleteFromJsonAsync<Producto>(direccion + "/" + IdProducto);
            if (producto != null)
            {
                Utils.ListaProducto.Remove(producto);
            }
            return RedirectToAction("Index");
        }

    }
}
