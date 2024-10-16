using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Watchly.Series
{
    public class SeasonDTO : EntityDto<int>
    {
        public string Title { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public int NumberSeason { get; set; }

        //Foreign key
        public int SerieID { get; set; }

        //Relación uno a muchos con Episodio
        public ICollection<EpisodeDTO> Episodes { get; set; }//lista de episodios

    }
}
