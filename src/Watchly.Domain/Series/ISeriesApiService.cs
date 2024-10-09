using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchly.Series
{
    public interface ISeriesApiService
    {
        Task<ICollection<SerieDTO>> GetSeriesAsync(string title);
    }
}
