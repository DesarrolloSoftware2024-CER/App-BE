using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Watchly.Notifications;


namespace Watchly.Notifications
{
    public interface INotificationRepository : IRepository<Notification, int>
    {
        Task<List<Notification>> GetNotificationsNoLeidasAsync(int ClienteId);
    }
}

//Este código define una interfaz llamada INotificacionRepository que extiende IRepository de ABP Framework.
//La interfaz está diseñada para trabajar con entidades de tipo Notificacion y utiliza un repositorio genérico 