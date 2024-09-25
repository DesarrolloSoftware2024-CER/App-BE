using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Whatchly.Series;

namespace Watchly.Series
{
    public class SerieAppService : CrudAppService<Serie, SerieDTO, int, PagedAndSortedResultRequestDto, CreateUpdateSerieDto, CreateUpdateSerieDto>, ISerieAppService
    {
        public SerieAppService(IRepository<Serie, int> repository) : base(repository)
        {
        }
    }
}
