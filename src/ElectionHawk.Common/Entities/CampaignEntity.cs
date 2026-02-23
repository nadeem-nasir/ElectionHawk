using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ElectionHawk.Common.Entities
{
    [Table("Campaign")]
    public class CampaignEntity:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CampaignId { get; set; }
        public string Title { get; set; }
        public string Media { get; set; }
        public string MediumofPropagation { get; set; }
       
        public string Forum { get; set; }

       // [ForeignKey("AgendaItemEnity")]
        public int agendaId { set; get; }
        public virtual AgendaItemEntity agendaItemEntity { get; set; }
    }
}
