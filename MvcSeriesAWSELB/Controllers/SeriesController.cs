using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcSeriesAWSELB.Models;
using MvcSeriesAWSELB.Repositories;

namespace MvcSeriesAWSELB.Controllers
{
    public class SeriesController : Controller
    {
        private RepositorySeries repo;

        public SeriesController(RepositorySeries repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Serie> series = this.repo.GetSeries();
            return View(series);
        }

        public IActionResult Details(int id)
        {
            Serie serie = this.repo.FindSerie(id);
            return View(serie);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Serie serie)
        {
            this.repo.InsertSerie(serie.Nombre, serie.Imagen, serie.Puntuacion
                , serie.Anyo);
            return RedirectToAction("Index");
        }

    }
}
