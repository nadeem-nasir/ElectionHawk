using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ElectionHawk.Common.Entities
{
    [Table("District")]
    public class DistrictEntity:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DistrictId { get; set; }
        public string Name { get; set; }
        public int ProvinceId { get; set; }
    }
}
