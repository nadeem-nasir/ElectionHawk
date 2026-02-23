using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectionHawk.Common.Entities
{
    [Table("ElectionResult")]
    public class ElectionResultEntity:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResultId { get; set; }
        public int ConstituencyId { get; set; }
        public int CandidateProfileId { get; set; }
        public int WinnerProfileId { get; set; }
        public int WinnerVoteCount { get; set; }
        public int RunnerUpProfileId { get; set; }
        public int RunnerUpVoteCount { get; set; }
        public int TotalVoters { get; set; }
        public int VotesCast { get; set; }
        public string Remarks { get; set; }
    }
}
