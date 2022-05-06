using Microsoft.AspNetCore.Mvc;
using MvcCacheRedisAWS.Models;
using MvcCacheRedisAWS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCacheRedisAWS.Controllers
{

    public class ProductosController : Controller
    {
        private RepositoryProductos repo;

        public ProductosController(RepositoryProductos repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Producto> productos = this.repo.GetProductos();
            return View(productos);
        }

        public IActionResult Details(int id)
        {
            Producto producto = this.repo.FindProducto(id);
            return View(producto);
        }
    }

}
