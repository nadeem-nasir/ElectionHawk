using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectionHawk.Common.Entities
{
    [Table("PollingStationTokenAgent")]
    public class PollingStationTokenAgentEntity:BaseEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PollingStationId { get; set; }
        public int PollingBoothId { get; set; }
        public int AgentProfileId { get; set; }
        public string Type { get; set; }
        public int Token { get; set; }
    }
}
