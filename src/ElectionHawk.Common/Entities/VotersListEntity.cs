using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectionHawk.Common.Entities
{
    [Table("VotersList")]
    public class VotersListEntity:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VoterListId { get; set; }
        public string VoterListTitle { get; set; }
        public string VoterListType { get; set; }
        public int TargetCommunityId { get; set; }
    }
}
