using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Watchly.Series;
using Volo.Abp.DependencyInjection;



namespace Watchly.Series
{
    public class OmdbService : ISeriesApiService
    {
        private static readonly string apiKey = "1504665a"; 
        private static readonly string baseUrl = "http://www.omdbapi.com/";

        public async Task<ICollection<SerieDTO>> GetSeriesAsync(string title)
        {
            using HttpClient client = new HttpClient();

            List<SerieDTO> series = new List<SerieDTO>();

            string url = $"{baseUrl}?s={title}&apikey={apiKey}&type=series";

            try
            {
                // Hacer la solicitud HTTP y obtener la respuesta como string
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();
                // Imprimir la respuesta JSON para depurar
            

                // Deserializar la respuesta JSON a un objeto SearchResponse
                var searchResponse = JsonConvert.DeserializeObject<SearchResponse>(jsonResponse);

                // Retornar la lista de series si existen
                var seriesOmdb = searchResponse?.Search ?? new List<SerieOmdb>();

                foreach (var serieOmdb in seriesOmdb)
                {
                    series.Add(new SerieDTO { Title = serieOmdb.Title });
                }

                return series;
            }
            catch (HttpRequestException e)
            {
                throw new Exception("Se ha producido un error en la búsqueda de la serie", e);
            }
        }
        //Agregado para solucionar errores
        Task<ICollection<SerieDTO>> ISeriesApiService.GetSeriesAsync(string title)
       {
          throw new NotImplementedException();
       }

        private class SearchResponse
        {
            [JsonProperty("Search")]
            public List<SerieOmdb> Search { get; set; }
        }
        private class SerieOmdb
        {
            [JsonProperty("Title")]
            public string Title { get; set; }

            [JsonProperty("Released")]
            public DateTime  ReleaseDate { get; set; }
          //  public string Director { get; set; }
         //   public string Actors { get; set; }
        }
    }
}
