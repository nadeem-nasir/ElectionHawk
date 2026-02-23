using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ElectionHawk.Common.Entities
{
    [Table("PartyOffice")]
    public class PartyOfficeEntity:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PartyOfficeId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int KeyPersonProfileId { get; set; }
        public int PartyId { get; set; }
    }
}
