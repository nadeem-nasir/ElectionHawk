using System;
using System.Collections.Generic;
using System.Text;

namespace ElectionHawk.Common.Models
{
    public class EventCreateModel
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AreaId { get; set; }
        public string Venue { get; set; }
        public DateTime HeldOn { get; set; }
        public int AgendaId { get; set; }
        public int OrganizerProfileId { get; set; }
        public int ChiefGuestProfileId { get; set; }
    }


    public class EventUpdateModel
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AreaId { get; set; }
        public string Venue { get; set; }
        public DateTime HeldOn { get; set; }
        public int AgendaId { get; set; }
        public int OrganizerProfileId { get; set; }
        public int ChiefGuestProfileId { get; set; }
    }

    public class EventViewModel
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AreaId { get; set; }
        public string Venue { get; set; }
        public DateTime HeldOn { get; set; }
        public int AgendaId { get; set; }
        public int OrganizerProfileId { get; set; }
        public int ChiefGuestProfileId { get; set; }
    }

}
