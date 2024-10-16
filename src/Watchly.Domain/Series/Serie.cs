using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Watchly.Series;

namespace Whatchly.Series
{
    public class Serie : AggregateRoot<int> //Clave de la serie ID de tipo entero 
    {
        public string Title { get; set; }
        public string Gender { get; set; }
        public string Actors { get; set; }
        public string Director { get; set; }
        public string Duration { get; set; }

        public string Synopsis { get; set; }
        public  DateTime ReleaseDate { get; set; }
        public string Poster { get; set; }
        public string Country { get; set; }
        public string Ratings { get; set; }

        public int TotalSeasons { get; set; }

        public ICollection<Season> Seasons {  get; set; }
    }
}
