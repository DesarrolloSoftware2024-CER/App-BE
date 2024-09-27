using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Watchly.Series
{
    public interface ISerieAppService: ICrudAppService<SerieDTO,int,PagedAndSortedResultRequestDto, CreateUpdateSerieDto>
    {
        Task<ICollection<SerieDTO>> SearchAsync(string title, string gender);
    }
}
