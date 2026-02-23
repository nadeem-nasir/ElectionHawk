using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ElectionHawk.Common.Entities
{
    [Table("CandidateCampaignVehicle")]
    public class CandidateCampaignVehicleEntity : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CandidateCampaignId { get; set; }
        public int CandidateProfileId { get; set; }
        public int? CampaignId { get; set; }
        public string DriverName { get; set; }
        public string DriverPhone { get; set; }
        public string VehicleNumber { get; set; }

    }
}
