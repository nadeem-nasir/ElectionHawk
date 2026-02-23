using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ElectionHawk.Common.Entities
{
    [Table("PollingScheme")]
    public class PollingSchemeEntity:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PollingSchemeId { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public int ElectionId { get; set; }
        public int ConstituencyId { get; set; }

    }
}


    