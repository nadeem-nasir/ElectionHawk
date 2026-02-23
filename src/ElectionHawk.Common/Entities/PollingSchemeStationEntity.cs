using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ElectionHawk.Common.Entities
{
    [Table("PollingSchemeStation")]
    public class PollingSchemeStationEntity:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StationId { get; set; }
        public string StationName { get; set; }
        public int? MaleBooths { get; set; }
        public int? FemaleBooths { get; set; }
        public int? TotalBooths { get; set; }
        public int? MaleVoters { get; set; }
        public int? FemaleVoters { get; set; }
        public int? TotalVoters { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string PollingStationImageUrl { get; set; }
        public string PollingStationMapUrl { get; set; }     
        public int? ECPPSNo { get; set; }
    }
}


