using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ElectionHawk.Common.Entities
{
    [Table("CandidateSupporter")]
    public  class CandidateSupporterEntity:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CandidateSupporterId { get; set; }
        public int ProfileId { get; set; }
        public int AffiliatedPartyId { get; set; }
        public int Description { get; set; }
    }
}
