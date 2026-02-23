using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectionHawk.Common.Entities
{
    [Table("ConstituencyVoterList")]
    public class ConstituencyVoterListEntity:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VoterListId { get; set; }
        public int ConstituencyId { get; set; }
        public  int ElectionId { get; set; }
    }
}
