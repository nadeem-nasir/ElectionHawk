using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectionHawk.Common.Entities
{
    [Table("VoterListDetail")]
    public class VoterListDetailEntity:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VoterId { get; set; }
        public int VoterListId { get; set; }
        public string VoterName { get; set; }
        public string NIC { get; set; }
        public string FamilyNumber { get; set; }
        public string VoterListType { get; set; }
        public int TargetCommunityId { get; set; }
    }
}
