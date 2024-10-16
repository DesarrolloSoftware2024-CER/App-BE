using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Watchly.Notifications;

namespace Watchly.Notifications
{
    public class Notification: Entity<int>  //Creamos la clase Notificacion
    {
        public int ClientId { get; set; }
        public DateTime CreateDate {  get; set; }
        public string State {  get; set; }
        public string Message { get; set; }

        public TypeNotification Type { get; set; }

        public int SerieId { get; set; }
    }
}
