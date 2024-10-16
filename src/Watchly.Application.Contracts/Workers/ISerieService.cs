using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchly.Workers
{
    public interface ISerieService
    {
            Task VerificarCambiosSeriesAsync(int ClientId);

    }
}
