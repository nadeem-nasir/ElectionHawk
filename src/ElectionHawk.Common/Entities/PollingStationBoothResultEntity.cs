using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ElectionHawk.Common.Entities
{
    [Table("PollingStationBoothResult")]
    public class PollingStationBoothResultEntity:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PollingBoothResultId { get; set; }
        public int PollingBoothId { get; set; }
        public int PolledVoteCount { get; set; }
        public int StationId { get; set; }
        public int CandidateProfileId { get; set; }

        public int ResultReportingAgentId { get; set; }

        public DateTime ReportingTime { get; set; }
    }
}
