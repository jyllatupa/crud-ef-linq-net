using CRUD_EF_LINQ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CRUD_EF_LINQ.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly VentasDbContext _dbVentasContext;

        public HomeController(VentasDbContext _dbContext)
        {
            _dbVentasContext = _dbContext;
        }

        public IActionResult Index()
        {
            var listado = (from p in _dbVentasContext.Productos
                           select new { p.CodProducto, p.Descripcion, p.Precio, p.Stock }).ToList();

            Producto producto = new Producto();
            List<Producto> lista = new List<Producto>();

            foreach (var item in listado)
            {
                producto = new Producto();
                producto.CodProducto = item.CodProducto;
                producto.Descripcion = item.Descripcion;
                producto.Precio = item.Precio;
                producto.Stock = item.Stock;
                lista.Add(producto);
            }

            ProductsViewModel productoViewModel = new ProductsViewModel();
            productoViewModel.listProductoVM = new List<Producto>();
            productoViewModel.listProductoVM = lista;

            return View(productoViewModel);
        }

        
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Descripcion,Precio,Stock")] Producto producto)
        {
            _dbVentasContext.Productos.Add(producto);
            await _dbVentasContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Editar(int? codproducto)
        {
            var producto = await _dbVentasContext.Productos.FindAsync(codproducto);

            Producto producto_ = new Producto();
            
            if (producto != null)
            {
                producto_.CodProducto = producto.CodProducto;
                producto_.Descripcion = producto.Descripcion;
                producto_.Precio = producto.Precio;
                producto_.Stock = producto.Stock;
            }

            ProductsViewModel productsView = new ProductsViewModel();
            productsView.productoVM = new Producto();
            productsView.productoVM = producto_;

            return View(productsView);
        }

        [HttpPost]
        public async Task<IActionResult> Update([Bind("CodProducto,Descripcion,Precio,Stock")] Producto producto)
        {
            _dbVentasContext.Productos.Update(producto);
            await _dbVentasContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? CodProducto)
        {
            var producto = await _dbVentasContext.Productos.FindAsync(CodProducto);

            Producto producto_ = new Producto();

            if (producto != null)
            {
                producto_.CodProducto = producto.CodProducto;
                producto_.Descripcion = producto.Descripcion;
                producto_.Precio = producto.Precio;
                producto_.Stock = producto.Stock;
            }

            ProductsViewModel productsView = new ProductsViewModel();
            productsView.productoVM = new Producto();
            productsView.productoVM = producto_;

            return View(productsView);
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar([Bind("CodProducto,Descripcion,Precio,Stock")] Producto producto)
        {

            _dbVentasContext.Productos.Remove(producto);
            await _dbVentasContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
