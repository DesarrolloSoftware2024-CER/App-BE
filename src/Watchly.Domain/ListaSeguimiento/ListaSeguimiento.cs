using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Whatchly.Series;

namespace Watchly.ListaSeguimiento
{
    public class ListaSeguimiento : AggregateRoot<int>
    {
        public List<Serie> Series { get; set; }
        public DateTime FechaAgregada { get; set; }
        public ListaSeguimiento()
        {
            Series = new List<Serie>();
            FechaAgregada = DateTime.Now; // Inicia con la fecha actual por defecto
        }

        // Método para agregar una serie a la lista
        public void AgregarSerie(Serie serie)
        {
            Series.Add(serie);
        }

        // Método para remover una serie de la lista
        public void RemoverSerie(Serie serie)
        {
            Series.Remove(serie);
        }
    }
}
