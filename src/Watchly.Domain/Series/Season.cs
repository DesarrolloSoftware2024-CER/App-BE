using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Whatchly.Series;

namespace Watchly.Series
{
    public class Season : Entity<int>
    {
        public string Title { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public int NumberSeason { get; set; }

        //Foreign key
        public int SerieID { get; set; }
        public Serie Serie { get; set; }

        //Relación uno a muchos con Episodio
        public ICollection<Episode> Episodes { get; set; }//lista de episodios

    }
}
