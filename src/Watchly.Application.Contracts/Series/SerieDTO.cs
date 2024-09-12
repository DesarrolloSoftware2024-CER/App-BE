using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Watchly.Series
{
    public class SerieDTO: EntityDto<int>
    {
        public string Title { get; set; }
    }
}
