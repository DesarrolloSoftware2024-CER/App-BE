using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchly.Series
{
    public interface ISeriesApiService
    {
        Task<SerieDTO[]> GetSeriesAsync(string title, string gender);
        // Task<ICollection<SerieDto>> GetSeriesAsync(string title, string gender);
    }
}
