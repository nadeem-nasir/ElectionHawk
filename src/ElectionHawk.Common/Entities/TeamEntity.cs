using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectionHawk.Common.Entities
{
    [Table("Team")]
    public class TeamEntity : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }
        public string TeamTitle { get; set; }
        public int AreaId { get; set; }
        public int TaskId { get; set; }
    }
}
