using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ElectionHawk.Common.Entities
{
    [Table("TeamTask")]
    public class TeamTaskEntity : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamTaskId { get; set; }
        public int TeamId { get; set; }
        public int TaskId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AccomplishmentPercent { get; set; }
        public string Remarks { get; set; }
    }
}
