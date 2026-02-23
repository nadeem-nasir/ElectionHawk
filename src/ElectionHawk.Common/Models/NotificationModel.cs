using System;
using System.Collections.Generic;
using System.Text;

namespace ElectionHawk.Common.Models
{
    public class NotificationCreateModel
    {
        public int NotificationId { get; set; }
        public string Description { get; set; }

    }


    public class NotificationUpdateModel
    {
        public int NotificationId { get; set; }
        public string Description { get; set; }

    }

    public class NotificationViewModel
    {
        public int NotificationId { get; set; }
        public string Description { get; set; }

    }

}
