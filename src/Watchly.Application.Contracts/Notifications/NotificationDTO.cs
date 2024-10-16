using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchly.Notifications
{
    public class NotificationDTO
    {
        public int ClientId { get; set; }
        public DateTime CreateDate { get; set; }
        public string State { get; set; }
        public string Message { get; set; }

        public TypeNotification Type { get; set; }
    }
}
