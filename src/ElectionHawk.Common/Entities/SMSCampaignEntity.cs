using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectionHawk.Common.Entities
{
    [Table("SMSCampaign")]
    public class SMSCampaignEntity:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SMSCampaignId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
