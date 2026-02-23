using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ElectionHawk.Common.Entities
{
    [Table("City")]
    public class CityEntity:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CityId { get; set; }
        public string Name { get; set; }
        public int ProvinceId { get; set; }
        public long Population { get; set; }
    }
}
