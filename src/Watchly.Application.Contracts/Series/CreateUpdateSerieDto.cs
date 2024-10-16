using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchly.Series
{
    public class CreateUpdateSerieDto
    {
        public string Title { get; set; }
        public string Gender { get; set; }
        public string Actors { get; set; }
        public string Director { get; set; }

        public string Writer { get; set; }//ddbcontext
        public string Duration { get; set; }

        public string Synopsis { get; set; }//DB CONTEXT
        public DateTime ReleaseDate { get; set; }
        public string Poster { get; set; }
        public string Country { get; set; }
        public string Ratings { get; set; } //puntaje
        public int TotalSeasons { get; set; } //totalTemporadas 
        public ICollection<SeasonDTO> Seasons { get; set; }//lista de temporadas 
    }
}
