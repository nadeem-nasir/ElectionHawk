using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ElectionHawk.Common.Entities
{
    [Table("CandidateGroups")]
    public class CandidateGroupsEntity:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CandidateGroupId { get; set; }
        public int CandidateProfileId { get; set; }
        public string GroupName { get; set; }
        
    }
}
