using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ElectionHawk.Common.Entities
{
    [Table("CandidateEvent")]
    public class CandidateEventEntity:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CandidateEventId { get; set; }
        public int CandidateId { get; set; }
        public int EventId { get; set; }
        public string Remarks { get; set; }
        public int ExpenseId { get; set; }
        
    }
}
