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

namespace Watchly.Service
{
    public class SerieService :DomainService, ISerieService
    {
        private readonly IRepository<Serie, int> _serieRepository;
        private readonly IRepository<WatchList, int> _watchListRepository;
        private readonly IRepository<Notification, int> _notificacionRepository;

        public SerieService(
        IRepository<Serie, int> serieRepository,
            IRepository<WatchList, int> watchListRepository,
            IRepository<Notification, int> notificacionRepository)
        {
            _serieRepository = serieRepository;
            _watchListRepository = watchListRepository;
            _notificacionRepository = notificacionRepository;
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
                var episodiosPrevios = ObtenerEpisodiosPrevios(serieId); // Obtener episodios previos
                var episodiosApi = ObtenerEpisodiosApi(title);

                /* Comparar si el estado cambió
                if (estadoPrevio != serie.State)
                {
                    await GenerarNotificacionAsync(clienteId, serieId, $"La serie '{serie.Nombre}' ha cambiado de estado a '{serie.Estado}'");
                }
                */
                // Comparar si se han lanzado nuevos episodios
                if (episodiosPrevios < episodiosApi)
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



        private int ObtenerEpisodiosPrevios(int serieId)
        {
            // Implementar lógica para obtener la cantidad de episodios previos desde la base de datos
            // Placeholder
        }

        private int ObtenerEpisodiosApi(string title)
        {
            //Implementacion
        }

       
    }

}
