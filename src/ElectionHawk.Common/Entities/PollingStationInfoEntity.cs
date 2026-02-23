using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectionHawk.Common.Entities
{
    [Table("PollingStationInfo")]
    public class PollingStationInfoEntity:BaseEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PollingStationId { get; set; }
        public string PollingStationName { get; set; }
        public int PollingStationNumber { get; set; }
        public int AreaId { get; set; }
        public int ConstituencyId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int ProvinceId { get; set; }
        public int PartyRepresentativeId { get; set; }

    }
}
