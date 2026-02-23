using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectionHawk.Common.Entities
{
    [Table("DistrictConstituency")]
    public class DistrictConstituencyEntity:BaseEntity
    {
         //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DistrictId { get; set; }
        public int ConstituencyId { get; set; }
    }
}
