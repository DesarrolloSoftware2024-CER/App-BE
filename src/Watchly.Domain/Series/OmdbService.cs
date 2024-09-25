using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchly.Series
{
    public class OmdbService: ISeriesApiService
    {
        public async Task<SerieDTO[]> GetSeriesAsync(string title)
        { 
        SerieDTO[] series = new SerieDTO[]
        {
            new SerieDTO
            {
                Title="Breaking Bad"
            }
        };
            return await Task.FromResult(series);
        }
    }
}
