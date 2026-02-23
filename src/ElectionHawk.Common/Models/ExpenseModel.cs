using System;
using System.Collections.Generic;
using System.Text;

namespace ElectionHawk.Common.Models
{
    public class ExpenseCreateModel
    {
        public int ExpenseId { get; set; }
        public int EventId { get; set; }
        public double AmountUtilized { get; set; }
        public double TotalBudget { get; set; }
        public double Balance { get; set; }
        public int ExpenseType { get; set; }
        public string Description { get; set; }
        public int ManagerProfileId { get; set; }
    }


    public class ExpenseUpdateModel
    {
        public int ExpenseId { get; set; }
        public int EventId { get; set; }
        public double AmountUtilized { get; set; }
        public double TotalBudget { get; set; }
        public double Balance { get; set; }
        public int ExpenseType { get; set; }
        public string Description { get; set; }
        public int ManagerProfileId { get; set; }
    }

    public class ExpenseViewModel
    {
        public int ExpenseId { get; set; }
        public string Event { get; set; }
        public double AmountUtilized { get; set; }
        public double TotalBudget { get; set; }
        public double Balance { get; set; }
        public int ExpenseType { get; set; }
        public string Description { get; set; }
        public string Manager { get; set; }
    }

}
