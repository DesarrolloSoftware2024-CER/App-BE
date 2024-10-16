using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchly.Series
{
    public class EpisodeDTO
    {
        public int NumberEpisode { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Duration { get; set; }
        public string Synopsis { get; set; }

        //Foreign key
        public int SeasonID { get; set; }
    }
}
