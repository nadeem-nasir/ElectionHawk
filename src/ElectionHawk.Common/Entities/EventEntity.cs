using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectionHawk.Common.Entities
{
    [Table("Event")]

    public class EventEntity:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AreaId { get; set; }
        public string Venue { get; set; }
        public DateTime HeldOn { get; set; }
        
        

        [ForeignKey("AgendaItem")]
        public int ItemId { get; set; }
        public string agenda { get; set; }
        [ForeignKey("Profile")]
        public int OrganizerProfileId { get; set; }
        public string Organizer { get; set; }
        [ForeignKey("Profile")]
        public int ChiefGuestProfileId { get; set; }
        public string Guest { get; set; }
    }
}
