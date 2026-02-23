using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ElectionHawk.Common.Entities
{
    [Table("CandidateCampaignOffice")]
    public class CandidateCampaignOfficeEntity:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CampaignOfficeId { get; set; }
        public int CandidateId { get; set; }
        public int AreaId { get; set; }
        public string Address { get; set; }
        public int OfficeHolderId { get; set; }
        public int MapId { get; set; }
    }
}
