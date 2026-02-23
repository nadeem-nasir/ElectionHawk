using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ElectionHawk.Common.Entities
{
    [Table("PollingStationBoothAgent")]
    public class PollingStationBoothAgentEntity:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PollingBoothAgentId { get; set; }
        public int PollingStationId { get; set; }
        public int AgentProfileId { get; set; }
        public string Type { get; set; }
    }
}
