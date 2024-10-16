using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Watchly.Notifications;
using Watchly.Workers;
using Whatchly.Series;
using Watchly.WatchLists;
using Watchly.Workers;
using Volo.Abp.Domain.Services;
using Watchly.Series;
using Polly;
using System.Drawing;

namespace Watchly.Service
{
    public class SerieService :DomainService, ISerieService
    {
        private readonly IRepository<Serie, int> _serieRepository;
        private readonly IRepository<WatchList, int> _watchListRepository;
        private readonly IRepository<Notification, int> _notificacionRepository;
        private readonly IRepository<Season, int> _seasonRepository;

        public SerieService(
            IRepository<Serie, int> serieRepository,
            IRepository<WatchList, int> watchListRepository,
            IRepository<Notification, int> notificacionRepository,
            IRepository<Season, int> seasonRepository)
        {
            _serieRepository = serieRepository;
            _watchListRepository = watchListRepository;
            _notificacionRepository = notificacionRepository;
            _seasonRepository = seasonRepository;
            }

        public async Task VerificarCambiosSeriesAsync(int ClientId)
        {
            // Obtener el WatchList del cliente por su ClientId
            var watchList = await _watchListRepository.FirstOrDefaultAsync(w => w.ClientId == ClientId);

            if (watchList == null)
            {
                // Si no se encuentra el WatchList del cliente, retorna o lanza una excepción
                return;
            }

            // Iterar sobre las series en la lista de seguimiento
            foreach (var serie in watchList.Series)
            {
                // Aquí accedes al ID de la serie
                int serieId = serie.Id;
                string title =serie.Title;

                // Lógica para comparar estados y episodios
               // var estadoPrevio = ObtenerEstadoPrevio(serieId); // Obtener estado anterior de la serie
                var episodiosPrevios =ObtenerEpisodiosPreviosAsync(serieId); // Obtener episodios previos
                var episodiosApi = ObtenerEpisodiosApi(title);

                /* Comparar si el estado cambió
                if (estadoPrevio != serie.State)
                {
                    await GenerarNotificacionAsync(clienteId, serieId, $"La serie '{serie.Nombre}' ha cambiado de estado a '{serie.Estado}'");
                }
                */
                // Comparar si se han lanzado nuevos episodios
                if (await episodiosPrevios < episodiosApi)
                {
                    // actualizarSerie(serieId);

                    string message = $"Se ha lanzado un nuevo episodio de la serie '{serie.Title}'";
                    await GenerarNotificacionAsync(ClientId, serieId,message);
                }
            }
        }


        private async Task GenerarNotificacionAsync(int clientId, int serieId, string message)
        {
            var notificacion = new Notification
            {
                ClientId = clientId,
                SerieId = serieId,
                Message = message,
                CreateDate = DateTime.Now
            };

            await _notificacionRepository.InsertAsync(notificacion);
        }


        private async Task<int> ObtenerEpisodiosPreviosAsync(int serieId)
        {  // Obtener todas las temporadas de la serie
            var temporadas = await _seasonRepository.GetListAsync(s => s.SerieID == serieId);

            int totalEpisodios = 0;

            // Iterar sobre cada temporada y contar los episodios
            foreach (var temporada in temporadas)
            {
                totalEpisodios += temporada.Episodes.Count() ;  // Sumar al total
            }

            return totalEpisodios;
        }

        private int ObtenerEpisodiosApi(string title)
        {
            //Implementacion
        }

       
    }

}
