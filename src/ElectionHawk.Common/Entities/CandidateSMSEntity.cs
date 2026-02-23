using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ElectionHawk.Common.Entities
{
    [Table("CandidateSMS")]
    public class CandidateSMSEntity : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CandidateSMSId { get; set; }
        public string Description { get; set; }
        public int? CandidateProfileId { get; set; }
        public int? TargetCommunityId { get; set; }
    
    }
}
