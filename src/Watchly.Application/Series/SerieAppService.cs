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
    public class SerieAppService : CrudAppService<Serie, SerieDTO, int, PagedAndSortedResultRequestDto, CreateUpdateSerieDto, CreateUpdateSerieDto>,  ISerieAppService
    {
        private readonly ISeriesApiService _seriesService;
        public SerieAppService(IRepository<Serie, int> repository, ISeriesApiService seriesService) : base(repository)
        {
            _seriesService = seriesService;
        }

        public async Task<ICollection<SerieDTO>> SearchAsync(string title, string gender)
        {
           return await _seriesService.GetSeriesAsync(title, gender);
        }
    }
}
