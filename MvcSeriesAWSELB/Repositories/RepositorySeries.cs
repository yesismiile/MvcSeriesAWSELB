using MvcSeriesAWSELB.Data;
using MvcSeriesAWSELB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSeriesAWSELB.Repositories
{
    public class RepositorySeries
    {
        private SeriesContext context;

        public RepositorySeries(SeriesContext context)
        {
            this.context = context;
        }

        public List<Serie> GetSeries()
        {
            return this.context.Series.ToList();
        }

        public Serie FindSerie(int id)
        {
            return this.context.Series.FirstOrDefault(z => z.IdSerie == id);
        }

        private int GetMaxIdSerie()
        {
            if (this.context.Series.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Series.Max(x => x.IdSerie) + 1;
            }
        }

        public void InsertSerie(string nombre, string imagen
            , double puntuacion, int anyo)
        {
            Serie serie = new Serie
            {
                IdSerie = this.GetMaxIdSerie()
                ,Nombre = nombre
                ,Imagen = imagen
                ,Puntuacion = puntuacion
                ,Anyo = anyo
            };
            this.context.Series.Add(serie);
            this.context.SaveChanges();
        }
    }
}
