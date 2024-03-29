﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetApplication.Models
{
    [Table("Transaction")]
    public class Transaction
    {
        public int Id { get; set; }
        public string Memo { get; set; }
        public double Cost { get; set; }

        [ForeignKey("BudgetItemId")]
        public virtual BudgetItem BudgetItem { get; set; }
    }
}
