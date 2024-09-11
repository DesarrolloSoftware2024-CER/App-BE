using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Whatchly.Series
{
    public class Serie : AggregateRoot<int>
    {
        public string Title { get; set; }
        public string Genero { get; set; }
        public string Equipo { get; set; }
        public string Duracion { get; set; }
        public  DateOnly FechaLanzamiento { get; set; }
        public string FotoPortada { get; set; }
        public string PaisOrigen { get; set; }
        public string Calificacion { get; set; }
    }
}
