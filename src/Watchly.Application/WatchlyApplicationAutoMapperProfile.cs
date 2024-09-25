using AutoMapper;
using Watchly.Series;
using Whatchly.Series;

namespace Watchly;

public class WatchlyApplicationAutoMapperProfile : Profile
{
    public WatchlyApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Serie,SerieDTO>();
        CreateMap<CreateUpdateSerieDto, Serie>();
    }
}
