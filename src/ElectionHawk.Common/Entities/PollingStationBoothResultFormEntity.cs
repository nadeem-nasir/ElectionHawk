using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ElectionHawk.Common.Entities
{
    [Table("PollingStationBoothResultForm")]
    public class PollingStationBoothResultFormEntity:BaseEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PollingBoothResultFormId { get; set; }
        public int PollingBoothId { get; set; }
        public int StationId { get; set; }
        public int CandidateProfileId { get; set; }
        public int AgentId { get; set; }
        public int Form14Picture { get; set; }
        public int Form15Picture { get; set; }
    }
}
