using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ElectionHawk.Common.Entities
{
    [Table("CandidateCampaign")]
    public class CandidateCampaignEntity : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CandidateCampaignId { get; set; }
        public string CandidateName { get; set; }
        public int? CampaignId { get; set; }
        public int? CandidateProfileId { get; set; }

    }
}