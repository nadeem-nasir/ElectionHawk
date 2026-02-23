using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ElectionHawk.Common.Entities
{
    [Table("Constituency")]
    public class ConstituencyEntity:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ConstituencyId { get; set; }
        public int ConstituencyTypeId { get; set; }
        public string ConstituencyTitle { get; set; }
        //public string ConstituencyNumber { get; set; }
        public string ConstituencyName { get; set; }
        public int? MapId { get; set; }
        public int? AreaId { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
        public int? ProvinceId { get; set; }
        public int? ECPConstCode { get; set; }
    }
}

