using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ElectionHawk.Common.Entities
{
    [Table("Expense")]
    public class ExpenseEntity:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExpenseId { get; set; }
        
        public double AmountUtilized { get; set; }
        public double TotalBudget { get; set; }
        public double Balance { get; set; }
        public string ExpenseType { get; set; }
        public string Description { get; set; }
        [ForeignKey("event")]
        public int EventId { get; set; }
        public virtual EventEntity evt { get; set; }
        [ForeignKey("profile")]
        public int ManagerProfileId { get; set; }
        public virtual ProfileEntity Profile { get; set; }
    }
}
