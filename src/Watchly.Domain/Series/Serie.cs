using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Whatchly.Series
{
    public class Serie : AggregateRoot<int> //Clave de la serie ID de tipo entero 
    {
        public string Title { get; set; }
        public string Gender { get; set; }
        public string Team { get; set; }
        public string Duration { get; set; }
        public  DateTime ReleaseDate { get; set; }
        public string Photo { get; set; }
        public string Country { get; set; }
        public string Rating { get; set; }
    }
}
